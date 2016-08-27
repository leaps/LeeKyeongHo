using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace PopAll_Article_Writer_Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint localEP = new IPEndPoint(IPAddress.Any, 2048);
        EndPoint remoteEP = new IPEndPoint(IPAddress.None, 2040);
        byte[] receiveBuffer = new byte[512];
        Thread th;
        int i = 0;
        int WriteCount = 0;

        string GetPCState(ListView lv)
        {
            int SB = 0, R = 0;
            foreach (ListViewItem item in lv_list.Items)
            {
                if (item.SubItems[2].Text.Equals("등록대기"))
                    SB++;
                else
                    R++;
            }
            return string.Format("PC : {0}, 작성성공 : {1}, 등록대기 : {2}, 준비중 : {3}", lv.Items.Count, WriteCount, SB, R);
        }

        void StartServer()
        {
            udpSocket.Bind(localEP);
            Console.WriteLine("UDP 에코 서버를 시작합니다");
            while (true)
            {
                try
                {
                    gb_list.Text = GetPCState(lv_list);
                    int receivedSize = udpSocket.ReceiveFrom(receiveBuffer, ref remoteEP);
                    string rcv = Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize);
                    string remoteIP = ((IPEndPoint)remoteEP).Address.ToString();

                    Console.Write("IP : " + remoteIP);
                    Console.Write(DateTime.Now.ToShortTimeString() + " / 메세지 : ");
                    //Console.WriteLine(Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize));
                    Console.WriteLine(rcv);

                    //if (rcv.Contains("서버연결"))
                    //{
                    //    foreach (ListViewItem item in lv_list.Items)
                    //    {
                    //        if (item.SubItems[0].Text.Equals(remoteIP))
                    //        {
                    //            item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //        }
                    //        else
                    //        {
                    //            ListViewItem lvi = new ListViewItem(remoteIP);
                    //            lvi.SubItems.Add("None");
                    //            lvi.SubItems.Add("작업대기중");
                    //            lvi.SubItems.Add("");
                    //            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //            lv_list.Items.Add(lvi);
                    //        }
                    //    }
                    //}
                    //else
                    ModifyItem(lv_list, remoteIP, rcv);

                    //udpSocket.SendTo(receiveBuffer, receivedSize, SocketFlags.None, remoteEP);

                    //ListViewItem lvi = new ListViewItem(remoteIP);
                    //    lvi.SubItems.Add(rcv.Split('|')[0]);
                    //    lvi.SubItems.Add("Article " + rcv.Split('|')[1] + ", IP " + rcv.Split('|')[2]);
                }
                catch { }
            }
        }

        void ClientState()
        {
            Console.WriteLine("필터링");
            string[] usedip = new WebClient().DownloadString(string.Format("http://eogh1439.dothome.co.kr/UsedIP{0:yyyyMMdd}", DateTime.Now)).Replace("<br>", string.Empty).Split('\n');
            while (true)
            {
                foreach (ListViewItem item in lv_list.Items)
                {
                    if ((DateTime.Parse(item.SubItems[4].Text).AddMinutes(1)).CompareTo(DateTime.Now) < 0)
                    {
                        Console.WriteLine("제거");
                        lv_list.Items.Remove(item);
                    }
                    foreach (string arr in usedip)
                    {
                        if (arr.Equals(item.SubItems[0].Text))
                        {
                            item.Remove();
                            LogAdd(string.Format("Remove IP : {0}", item.SubItems[0].Text));
                        }
                    }
                    //else if (item.SubItems[2].Text.Equals("작업대기중"))
                    //{
                    //    Console.WriteLine("제거");
                    //    lv_list.Items.Remove(item);
                    //}
                }
                Thread.Sleep(10000);
            }
        }

        void ModifyItem(ListView lv, string remoteIP, string rcvs)
        {
            ListViewItem item = lv.FindItemWithText(remoteIP);

            if (item != null)
            {
                if (rcvs.Contains("서버접속"))
                {
                    item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    return;
                }
                else if (rcvs.Contains("등록성공"))
                {
                    WriteCount++;
                    item.SubItems[1].Text = rcvs.Split('|')[0];
                    item.SubItems[2].Text = rcvs.Split('|')[1];
                    item.SubItems[3].Text = "Article " + rcvs.Split('|')[2] + ", IP " + rcvs.Split('|')[3];
                    item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    item.SubItems[1].Text = rcvs.Split('|')[0];
                    item.SubItems[2].Text = rcvs.Split('|')[1];
                    item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            else
            {
                ListViewItem lvi = new ListViewItem(remoteIP);
                lvi.SubItems.Add(rcvs.Split('|')[0]);
                //if (rcvs.Contains("서버접속"))
                //{
                //    lvi.SubItems.Add("작업대기중");
                //    lvi.SubItems.Add("");
                //    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //    lv.Items.Add(lvi);
                //    return;
                //}
                //else if (rcvs.Contains("등록성공"))
                if (rcvs.Contains("등록성공"))
                {
                    WriteCount++;
                    lvi.SubItems.Add(rcvs.Split('|')[1]);
                    lvi.SubItems.Add("Article " + rcvs.Split('|')[2] + ", IP " + rcvs.Split('|')[3]);
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv.Items.Add(lvi);
                }
                else
                {
                    lvi.SubItems.Add(rcvs.Split('|')[1]);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv.Items.Add(lvi);
                }
            }
            ListViewItem lvi_item = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi_item.SubItems.Add(remoteIP);
            lvi_item.SubItems.Add(rcvs.Split('|')[0]);
            lvi_item.SubItems.Add(rcvs.Split('|')[1]);
            lv_log.Items.Add(lvi_item);
            //lv_log.EnsureVisible(lv.Items.Count - 1);
        }

        void SetArticle(string subject, string body)
        {
            try
            {
                WinHttp.WinHttpRequest http = new WinHttp.WinHttpRequest();
                string Articletxt = string.Format("{0}|{1}", subject, body.Replace("\n", "<br>"));
                http.Open("GET", variables.hostURI + variables.ArticleSendValue + Articletxt);
                http.Send();
            }
            catch { }
        }

        void SetID()
        {
            try
            {
                WinHttp.WinHttpRequest http = new WinHttp.WinHttpRequest();
                string str = string.Empty;
                foreach (ListViewItem item in lv_id.Items)
                    str += item.Text + "<br>";
                http.Open("GET", variables.hostURI + variables.IDSendValue + str);
                http.Send();
            }
            catch { }
        }

        void SetIndex(string index)
        {
            try
            {
                WinHttp.WinHttpRequest http = new WinHttp.WinHttpRequest();
                string str = string.Format("<? $Time = date(\"Ymd\"); echo \"{0}/$Time\";?>", index);
                http.Open("GET", variables.hostURI + variables.indexSendValue + str);
                http.Send();
            }
            catch { }
        }

        void Work()
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                int Max = 10;
                int i = 0;

                foreach (ListViewItem item in lv_list.Items)
                {
                    int Delay = int.Parse(tb_timer.Text) * 1000;
                    if (!item.SubItems[2].Text.Equals("등록대기"))
                        continue;
                    if (i <= Max)
                    {
                        udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), new IPEndPoint(IPAddress.Parse(lv_list.Items[i].SubItems[0].Text), 2040));
                        item.SubItems[2].Text = "작성시작";
                        LogAdd("Start IP : " + item.SubItems[0].Text);
                        Console.WriteLine("작성시작");
                        Thread.Sleep(Delay);
                    }
                    else
                    {
                        i = 0;
                        Thread.Sleep(Delay);
                    }
                    i++;
                }
                bt_write.Enabled = true;
            }
            catch { }
        }

        //void Work()
        //{
        //    CheckForIllegalCrossThreadCalls = false;
        //    try
        //    {
        //        int Delay = int.Parse(tb_timer.Text) * 1000;

        //        foreach (ListViewItem item in lv_list.Items)
        //        {
        //            if (item.SubItems[2].Text.Equals("등록대기"))
        //            {
        //                udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), new IPEndPoint(IPAddress.Parse(lv_list.Items[i].SubItems[0].Text), 2040));
        //                item.SubItems[2].Text = "작성시작";
        //                LogAdd("Start IP : " + item.SubItems[0].Text);
        //                Console.WriteLine("작성시작");
        //                Thread.Sleep(Delay);
        //            }
        //        }
        //    }
        //    catch { }
        //}

        void LogAdd(string value)
        {
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("Program Message");
            lvi.SubItems.Add("Program Message");
            lvi.SubItems.Add(value);
            lv_log.Items.Add(lvi);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new Thread(StartServer).Start();
            new Thread(ClientState).Start();
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lv_list.Items)
            {
                udpSocket.SendTo(Encoding.UTF8.GetBytes("작업시작"), new IPEndPoint(IPAddress.Parse(lv_list.Items[i].SubItems[0].Text), 2040));
                item.SubItems[2].Text = "작업대기";
            }
            //SetIndex("ON");
            LogAdd("Work Start");
            bt_start.Enabled = false;
            bt_stop.Enabled = true;
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lv_list.Items)
            {
                udpSocket.SendTo(Encoding.UTF8.GetBytes("작업종료"), new IPEndPoint(IPAddress.Parse(lv_list.Items[i].SubItems[0].Text), 2040));
                item.SubItems[2].Text = "종료대기";
            }
            //SetIndex("OFF");
            th.Abort();
            LogAdd("Work Stop");
            bt_start.Enabled = true;
            bt_stop.Enabled = false;
        }

        private void bt_write_Click(object sender, EventArgs e)
        {
            //SetIndex("WRITE");
            th = new Thread(new ThreadStart(Work));
            th.Start();
            LogAdd("Write Start");
            bt_write.Enabled = false;
        }

        private void bt_article_Click(object sender, EventArgs e)
        {
            SetArticle(tb_subject.Text, tb_body.Text);
        }

        private void bt_id_Click(object sender, EventArgs e)
        {
            SetID();
        }

        private void 계정불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lv_id.Items.Clear();
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(op.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string value = sr.ReadToEnd();

                foreach (string line in System.Text.RegularExpressions.Regex.Split(value, Environment.NewLine))
                {
                    if (line.Length > 0)
                    {
                        ListViewItem item = new ListViewItem(line.Split('\n')[0]);
                        item.BackColor = Color.White;
                        lv_id.Items.Add(item);
                    }
                }
                sr.Close();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv_list.SelectedItems.Count > 0)
                lv_list.SelectedItems[0].Remove();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
