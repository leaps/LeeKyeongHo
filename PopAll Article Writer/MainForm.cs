using System;
using System.Net;
using System.Text;
//User
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Net.Sockets;
using WinHttp;

namespace PopAll_Article_Writer_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        #region Global Variable
        ImageDecaptcher Decaptcher;
        WinHttpRequest http = new WinHttpRequest();
        string Cookie = string.Empty;
        int success;
        int fail;
        int write_cnt = -1;
        int ip_cnt = -1;
        string _subject;
        string _body;
        string Account = "False";
        int LoginFail = 0;
        string Time = string.Format("{0:yyyyMMdd}", DateTime.Now);
        string ID = string.Empty;
        string PW = string.Empty;
        bool WorkState = false;
        Thread write;
        #endregion

        Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint localEP = new IPEndPoint(IPAddress.Any, 2040);
        //EndPoint remoteEP = new IPEndPoint(Dns.GetHostAddresses("popall.0pe.kr")[0], 2048);
        EndPoint remoteEP = new IPEndPoint(Dns.GetHostAddresses("popallwriter.oa.to")[0], 2048);

        void SendPacket(string ID, string Reason)
        {
            udpSocket.SendTo(Encoding.UTF8.GetBytes(ID + "|" + Reason), remoteEP);
        }

        void Work()
        {
            SendPacket("None", "서버접속");
            if (Account.Equals("False"))
            {
                Console.WriteLine("계정 불러오기 실패");
                SendPacket("None", "계정 불러오기 실패");
                GetAccount();
            }
            else
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string Articletxt = wc.DownloadString("http://eogh1439.dothome.co.kr/Article.txt");
                while (write.IsAlive)
                {
                    try
                    {
                        if (LoginFail >= 1)
                        {
                            GetAccount();
                            LoginFail = 0;
                        }
                        if (ip_cnt == 0)
                        {
                            LogAdd(Account, "작업종료 성공 : " + success + " / 실패 : " + fail);
                            SendPacket("None", "작업종료");
                            write.Abort();
                        }

                        ID = Account.Split('/')[0];
                        PW = Account.Split('/')[1];

                        //0. 실패 1. 성공   2. 글쓰기 불가능
                        if (PopLogin(ID, PW))
                        {
                            LogAdd(Account, " - 로그인 성공 / 글 등록대기 60초");
                            while (true)
                            {
                                Console.WriteLine("글작성 패킷 대기");
                                SendPacket(ID, "등록대기");
                                byte[] receiveBuffer = new byte[512];
                                int receivedSize = udpSocket.ReceiveFrom(receiveBuffer, ref remoteEP);
                                string rcv = Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize);
                                if (!rcv.Equals("작성시작"))
                                    continue;
                                if (ip_cnt.Equals(1))
                                    wc.DownloadString("limejellys.dothome.co.kr/usedip.php?ip=" + localEP);
                                while (!ip_cnt.Equals(1))
                                {
                                    Console.WriteLine(Articletxt);
                                    _subject = Articletxt.Split('/')[0];
                                    _body = Articletxt.Split('/')[1].Replace("<br>", "\n");
                                    int num = PopWrite(_subject, _body);
                                    if (num == 1)
                                        success++;
                                    else if (num == 2)
                                        GetAccount();
                                    else
                                        fail++;
                                }
                            }
                        }
                        else
                        {
                            LoginFail++;
                            LogAdd(Account, "로그인 실패 : " + LoginFail.ToString());
                            SendPacket(ID, "로그인 실패");
                            Thread.Sleep(61000);
                        }
                    }
                    catch { }
                }
            }
        }

        int PopWrite(string subject, string body)
        {
            try
            {
                Thread.Sleep(61000);
                http.Open("GET", "http://lin.popall.com/bbs.htm?code=talking&mode=1");
                //http.SetRequestHeader("Referer", "http://lin.popall.com/bbs.htm?code=talking");
                http.SetRequestHeader("Cookie", Cookie);
                http.Send();
                http.WaitForResponse();
                string result = Encoding.Default.GetString((byte[])http.ResponseBody);
                if (result.Contains("실명확인이 되지 않은 회원"))
                    return 0;
                string funny = Regex.Split(result, "funny value='")[1].Split('\'')[0];
                string sobj = Regex.Split(result, "sobj value='")[1].Split('\'')[0];
                string ImageDownloadURL = Regex.Split(result, "<img border=1 src=\"")[1].Split('"')[0];
                LogAdd(Account, "이미지 OCR");
                SendPacket(ID, "이미지 OCR");
                ImageDownload(ImageDownloadURL);
                string str = string.Empty;
                Decaptcher = new ImageDecaptcher(ref str);
                subject = HttpUtility.UrlEncode(subject, Encoding.GetEncoding("euc-kr"));
                body = HttpUtility.UrlEncode(body, Encoding.GetEncoding("euc-kr"));
                http.Open("POST", "http://popall.com/pboard_write_ok.php?code=talking&part=0");
                http.SetRequestHeader("Referer", "http://lin.popall.com/bbs.htm?code=talking&mode=1");
                http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                http.Send("funny=" + funny + "&sobj=" + sobj + "&subject=" + subject + "&comment=" + body + "&imagecode=" + str);
                http.WaitForResponse();
                result = Encoding.Default.GetString((byte[])http.ResponseBody);
                if (result.Contains("글이 등록"))
                {
                    if (result.Contains("글쓰기 횟수"))
                    {
                        write_cnt = int.Parse(Regex.Split(result, "글쓰기 횟수:")[1].Split(',')[0]);
                        ip_cnt = int.Parse(Regex.Split(result, "아이피:")[1].Split(' ')[0]);
                        LogAdd(Account, " 남은 글쓰기 횟수: " + write_cnt + " / IP: " + ip_cnt);
                    }
                    LogAdd(Account, "글쓰기 성공");
                    SendPacket(ID, "등록성공|" + write_cnt + "|" + ip_cnt);
                    return 1;
                }
                else if (result.Contains("금일 글쓰기"))
                {
                    LogAdd(Account, "금일 글쓰기 불가능");
                    SendPacket(ID, "횟수초과");
                    return 2;
                }
                else if (result.Contains("도배방지 코드가"))
                {
                    LogAdd(Account, "도배방지 코드 일치하지 않음, 20초");
                    SendPacket(ID, "코드 불일치");
                    Thread.Sleep(21000);
                    PopWrite(_subject, _body);
                }
                else if (result.Contains("초후에"))
                {
                    LogAdd(Account, "글 쓰기 제한시간, " + result.Split('초')[0] + "초");
                    SendPacket(ID, "제한시간");
                    Thread.Sleep(int.Parse(result.Split('초')[0] + 1000));
                    PopWrite(_subject, _body);
                }
                else
                {
                    if (result.Contains("접근금지된 회원"))
                    {
                        LogAdd(Account, "접근금지된 회원");
                        SendPacket(ID, "접근금지");
                        return 0;
                    }
                    if (result.Contains("비정상적"))
                    {
                        LogAdd(Account, "비정상적 접근");
                        SendPacket(ID, "비정상 접근");
                        return 0;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return 0; }
            return 0;
        }

        bool PopLogin(string id, string pw)
        {
            try
            {
                http.Open("GET", "http://lin.popall.com/", true);
                http.Send();
                http.WaitForResponse();
                string idp = Regex.Split(Encoding.Default.GetString((byte[])http.ResponseBody), "<input type=hidden value=")[1].Split(' ')[0];
                http.Open("POST", "https://popall.com/login2.php");
                http.SetRequestHeader("Referer", "http://popall.com/lin/bbs.htm?code=talking");
                http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                http.Send("popid=" + id + "&idp=" + idp + "&pw=" + pw + "&loginbtn.x=34&loginbtn.y=13");
                http.WaitForResponse();
                this.Cookie = this.http.GetResponseHeader("Set-Cookie");
                string result = Encoding.Default.GetString((byte[])http.ResponseBody);
                if (result.Contains("var todayDate"))
                    return true;
                if (result.Contains("1분이내 같은 장소"))
                {
                    LogAdd(Account, "1분이내 같은 장소 / 1분 후 재시도");
                    SendPacket(ID, "로그인중");
                    Thread.Sleep(61000);
                    return false;
                }
                return false;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
        }

        string GetAccount()
        {
            try
            {
                using (var WC = new WebClient())
                {
                    string[] RawID = WC.DownloadString("http://eogh1439.dothome.co.kr/ID.txt").Split(';');
                    string[] UsedID = WC.DownloadString(string.Format("http://eogh1439.dothome.co.kr/UsedID{0}.html", Time)).Replace("<br>", string.Empty).Split('\n');
                    string[] Accounts = ReplaceStr(RawID, UsedID);
                    Account = Accounts[new Random().Next(0, Accounts.Length)];
                    if (!WC.DownloadString("http://eogh1439.dothome.co.kr/usedid.php?id=" + Account).Contains("/"))
                        return Account;
                    else
                        return "False";
                }
            }
            catch { return "False"; }
        }

        string[] ReplaceStr(string[] RawID, string[] UsedID)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string raw in RawID)
            {
                foreach (string used in UsedID)
                {
                    if (!(raw.Contains("/") && used.Contains("/")))
                    if (!raw.Equals(used))
                    {
                        if (used.Equals(UsedID[UsedID.Length - 1]))
                        { sb.Append(raw + " "); break; }
                    }
                    else
                        break;
                }
            }
            return sb.ToString().Trim().Split(' ');
        }

        void LogAdd(string id, string value)
        {
            new WebClient().DownloadString(string.Format("http://eogh1439.dothome.co.kr/logadd.php?id={0}&log={1}", id, value));
            Console.WriteLine(id + " / " + value);
        }

        void ImageDownload(string URL)
        {
            WebClient WC = new WebClient();
            WC.Headers.Add("Cookie", Cookie);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            WC.DownloadFile(URL, path + @"\pic.png");
        }

        void ProcessState()
        {
            SendPacket("None", "서버접속");
            for (;;)
            {
                Time = string.Format("{0:yyyyMMdd}", DateTime.Now);
                string index = new WebClient().DownloadString("http://eogh1439.dothome.co.kr/index.php").Trim();
                Thread.Sleep(5000);
                if (index.Split('/')[0].Equals("ON") && index.Split('/')[1].Equals(Time))
                {
                    if (WorkState)
                    {
                        //이미작업함
                        SendPacket("None", "서버접속");
                        continue;
                    }
                    else
                    {
                        WorkState = true;
                        Console.WriteLine("작업시작");
                        write = new Thread(new ThreadStart(Work));
                        write.Start();
                        continue;
                    }
                }
                else
                {
                    //날짜지남 ON/OFF
                    SendPacket("None", "서버접속");
                    WorkState = false;
                }
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            //if (key.GetValue("PopAll") == null)
            //    key.SetValue("PopAll", Application.ExecutablePath.ToString());
            new Thread(Kill).Start();
            if (System.Diagnostics.Process.GetProcessesByName("Article").Length > 1)
                System.Diagnostics.Process.GetProcessesByName("Article")[1].Kill();

            if (new WebClient().DownloadString("http://eogh1439.dothome.co.kr/AddIP.php").Contains("Done."))
            {
                udpSocket.Bind(localEP);
                GetAccount();
                new Thread(ProcessState).Start();
                Console.WriteLine("아이피 추가 완료");
            }
        }

        void Kill()
        {
            while (true)
            {
                if (new WebClient().DownloadString("http://limejellys.dothome.co.kr/Kill.txt").Equals("O"))
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                Thread.Sleep(1000);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}