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

        void StartServer()
        {
            udpSocket.Bind(localEP);
            Console.WriteLine("UDP 에코 서버를 시작합니다");
            while (true)
            {
                try
                {
                    int receivedSize = udpSocket.ReceiveFrom(receiveBuffer, ref remoteEP);
                    string rcv = Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize);
                    string remoteIP = ((IPEndPoint)remoteEP).Address.ToString();

                    Console.Write("IP : " + remoteIP);
                    Console.Write(DateTime.Now.ToShortTimeString() + " / 메세지 : ");
                    Console.WriteLine(Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize));
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
            while (true)
            {
                foreach (ListViewItem item in lv_list.Items)
                {
                    if ((DateTime.Parse(item.SubItems[4].Text).AddMinutes(1)).CompareTo(DateTime.Now) < 0)
                    {
                        Console.WriteLine("제거");
                        lv_list.Items.Remove(item);
                    }
                }
                Thread.Sleep(10000);
            }
        }

        void ModifyItem(ListView lv, string remoteIP, string rcv)
        {
            ListViewItem lvi_item = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi_item.SubItems.Add(remoteIP);
            lvi_item.SubItems.Add(rcv.Split('|')[0]);
            lvi_item.SubItems.Add(rcv.Split('|')[1]);
            lv_log.Items.Add(lvi_item);
            
            bool Modify = false;
            foreach (ListViewItem item in lv.Items)
            {
                if (item.SubItems[0].Text.Equals(remoteIP))
                {
                    if (rcv.Equals("서버접속"))
                    {
                        item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Modify = true;
                        break;
                    }
                    else if (rcv.Contains("등록성공"))
                    {
                        item.SubItems[1].Text = rcv.Split('|')[0];
                        item.SubItems[2].Text = rcv.Split('|')[1];
                        item.SubItems[3].Text = "Article " + rcv.Split('|')[2] + ", IP " + rcv.Split('|')[3];
                        item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Modify = true;
                        break;
                    }
                    else
                    {
                        item.SubItems[1].Text = rcv.Split('|')[0];
                        item.SubItems[2].Text = rcv.Split('|')[1];
                        item.SubItems[4].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Modify = true;
                        break;
                    }
                }
            }
            if (!Modify)
            {
                Modify = false;
                if (rcv.Equals("서버접속"))
                {
                    ListViewItem lvi = new ListViewItem(remoteIP);
                    lvi.SubItems.Add("None");
                    lvi.SubItems.Add("작업대기중");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv_list.Items.Add(lvi);
                }
                else if (rcv.Contains("등록성공"))
                {
                    ListViewItem lvi = new ListViewItem(remoteIP);
                    lvi.SubItems.Add(rcv.Split('|')[0]);
                    lvi.SubItems.Add(rcv.Split('|')[1]);
                    lvi.SubItems.Add("Article " + rcv.Split('|')[2] + ", IP " + rcv.Split('|')[3]);
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv_list.Items.Add(lvi);
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(remoteIP);
                    lvi.SubItems.Add(rcv.Split('|')[0]);
                    lvi.SubItems.Add(rcv.Split('|')[1]);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv_list.Items.Add(lvi);
                }
            }
        }

        void SetArticle(string subject, string body)
        {
            try
            {
                WinHttp.WinHttpRequest http = new WinHttp.WinHttpRequest();
                string Articletxt = string.Format("{0}/{1}", subject, body.Replace("\n", "<br>"));
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
                {
                    str += item.Text + "§";
                }
                http.Open("GET", variables.hostURI + variables.IDSendValue + str);
                http.Send();
            }
            catch { }
        }

        int i = 0;

        void Work()
        {
            //udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), remoteEP);

            //foreach (ListViewItem item in lv_list.Items) //<- for int i <- i++ < 4
            //{
            //    //EndPoint remoteEP = new IPEndPoint(IPAddress.Parse(item.SubItems[0].Text), 2040);
            //    udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), new IPEndPoint(IPAddress.Parse(item.SubItems[0].Text), 2040));
            //}
            int Max = int.Parse(tb_stand.Text);
            for (; i <= lv_list.Items.Count; i += Max)
            {
                bool ready = true;
                for (int j = 0; j < Max; j++)
                {
                    if (lv_list.Items[j].SubItems[2].Text != "등록대기")
                    {
                        Console.WriteLine("로그인 진행중");
                        ready = false;
                        i -= Max;
                        break;
                    }

                    if (ready)
                    {
                        udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), new IPEndPoint(IPAddress.Parse(lv_list.Items[i].SubItems[0].Text), 2040));
                        Thread.Sleep(int.Parse(tb_timer.Text) * 1000);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new Thread(StartServer).Start();
            new Thread(ClientState).Start();
        }


        private void bt_start_Click(object sender, EventArgs e)
        {
            SetID();
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {

        }

        private void 계정불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
