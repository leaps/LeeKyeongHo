using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PopAll_Article_Writer_Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        void SendPacket(string ID, string Reason)
        {
            udpSocket.SendTo(Encoding.UTF8.GetBytes(ID + "|" + Reason), remoteEP);
        }
        private void bt_id_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog op = new OpenFileDialog())
                    if (op.ShowDialog() == DialogResult.OK)
                        tb_id.Text = op.FileName;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void bt_vpn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog op = new OpenFileDialog())
                    if (op.ShowDialog() == DialogResult.OK)
                        tb_vpn.Text = op.FileName;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void bt_article_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog op = new OpenFileDialog())
                    if (op.ShowDialog() == DialogResult.OK)
                        tb_article.Text = op.FileName;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            Util util = new Util();
            util.SetDirectory(tb_id, tb_vpn, tb_article);
            util.GetTxt(lv_login, tb_id.Text, 0);
            util.GetTxt(lv_vpn, tb_vpn.Text, 1);
            util.GetTxt(lv_article, tb_article.Text, 0);

            util.SetTxt(lv_login, "ID.html", 0);
            util.SetTxt(lv_vpn, "VPN.html", 1);
            util.SetTxt(lv_article, "ARTICLE.html", 0);
        }
        private void bt_reset_Click(object sender, EventArgs e)
        {
            Util util = new Util();
            util.GetDirectory(tb_id, tb_vpn, tb_article);
            util.GetTxt(lv_login, tb_id.Text, 0);
            util.GetTxt(lv_vpn, tb_vpn.Text, 1);
            util.GetTxt(lv_article, tb_article.Text, 0);
        }
        private void bt_start_Click(object sender, EventArgs e)
        {
            new Util().SetTxt(lv_article, "index.html", 2);
        }
        private void bt_stop_Click(object sender, EventArgs e)
        {
            new Util().SetTxt(lv_article, "index.html", 3);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //new Thread(new ThreadStart(new Web().Webs)).Start();
            //Util util = new Util();
            //util.GetDirectory(tb_id, tb_vpn, tb_article);
            //util.GetTxt(lv_login, tb_id.Text, 0);
            //util.GetTxt(lv_vpn, tb_vpn.Text, 1);
            //util.GetTxt(lv_article, tb_article.Text, 0);
            new Thread(StartServer).Start();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //new Util().SetTxt(lv_article, "index.html", 3);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(ClientState).Start();
            //ClientState();

            //string Time = string.Format("{0:yyyyMMdd}", DateTime.Now);
            //string[] IPs = new System.Net.WebClient().DownloadString("http://limejellys.dothome.co.kr/IP" + Time + ".html").Split('\n');
            //for (int i = 0; i < IPs.Length; i++)
            //{
            //    foreach (string IP in IPs)
            //    {
            //        if (IPs[i].IndexOf(IP) >= 1)
            //        {
            //            MessageBox.Show(IPs[i]);
            //            break;
            //        }
            //    }
            //}
        }

        Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint localEP = new IPEndPoint(IPAddress.Any, 2048);
        EndPoint remoteEP = new IPEndPoint(IPAddress.None, 204);
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
                    ModifyItem(lv_login, remoteIP, rcv);

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
                foreach (ListViewItem item in lv_login.Items)
                {
                    if ((DateTime.Parse(item.SubItems[4].Text).AddMinutes(1)).CompareTo(DateTime.Now) < 0)
                    {
                        Console.WriteLine("제거");
                        lv_login.Items.Remove(item);
                    }
                }
                Thread.Sleep(10000);
            }
        }

        void ModifyItem(ListView lv, string remoteIP, string rcv)
        {
            bool Modify = false;
            foreach (ListViewItem item in lv.Items)
            {
                if (item.SubItems[0].Text.Equals(remoteIP))
                {
                    if (rcv.Equals("연결시도"))
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
                if (rcv.Contains("등록성공"))
                {
                    ListViewItem lvi = new ListViewItem(remoteIP);
                    lvi.SubItems.Add(rcv.Split('|')[0]);
                    lvi.SubItems.Add(rcv.Split('|')[1]);
                    lvi.SubItems.Add("Article " + rcv.Split('|')[2] + ", IP " + rcv.Split('|')[3]);
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv_login.Items.Add(lvi);
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(remoteIP);
                    lvi.SubItems.Add(rcv.Split('|')[0]);
                    lvi.SubItems.Add(rcv.Split('|')[1]);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    lv_login.Items.Add(lvi);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), remoteEP);
            
            foreach (ListViewItem item in lv_login.Items)
            {
                //EndPoint remoteEP = new IPEndPoint(IPAddress.Parse(item.SubItems[0].Text), 2040);
                udpSocket.SendTo(Encoding.UTF8.GetBytes("작성시작"), new IPEndPoint(IPAddress.Parse(item.SubItems[0].Text), 2040));
            }
        }
    }
}
