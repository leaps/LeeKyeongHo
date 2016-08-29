using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAll_Article_Writer_Admin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lv_request.ItemSelectionChanged += SelectingUser;
        }
        public string[] Rusers;
        public string SelectingItem;

        private void SelectingUser(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectingItem = e.Item.Text + e.Item.SubItems.ToString();
        }

        void GetRequestUsers()
        {
            lv_request.Items.Clear();
            HttpWebRequest wReq;
            HttpWebResponse wRes;
            wReq = (HttpWebRequest)WebRequest.Create(variables.hostURI + variables.ReqViewValue);
            wReq.Method = "GET";
            wReq.Timeout = 2000;
            wRes = (HttpWebResponse)wReq.GetResponse();
            if (wRes.StatusCode == HttpStatusCode.OK)
            {
                string buff = null;
                Rusers = null;
                using (StreamReader SR = new StreamReader(wRes.GetResponseStream(), Encoding.UTF8))
                {
                    buff = SR.ReadToEnd();
                    Rusers = new string[buff.Split(new string[] { "|" }, StringSplitOptions.None).GetUpperBound(0)];
                    Rusers = buff.Split(new string[] { "|" }, StringSplitOptions.None);
                }
                DrawReqUsers(Rusers, Rusers.GetUpperBound(0));
            }
        }

        void GetOkUsers()
        {
            //lv_ok.Items.Clear();
            //WebClient WC = new WebClient();
            //Stream strm = WC.OpenRead(variables.hostURI + variables.OkViewValue);
            //StreamReader sr = new StreamReader(strm);
            //while (sr.Peek() != -1)
            //    lv_ok.Items.Add(sr.ReadLine());
            lv_ok.Items.Clear();
            HttpWebRequest wReq;
            HttpWebResponse wRes;
            wReq = (HttpWebRequest)WebRequest.Create(variables.hostURI + variables.OkViewValue);
            wReq.Method = "GET";
            wReq.Timeout = 2000;
            wRes = (HttpWebResponse)wReq.GetResponse();
            if (wRes.StatusCode == HttpStatusCode.OK)
            {
                string buff = null;
                Rusers = null;
                using (StreamReader SR = new StreamReader(wRes.GetResponseStream(), Encoding.UTF8))
                {
                    buff = SR.ReadToEnd();
                    Rusers = new string[buff.Split(new string[] { "|" }, StringSplitOptions.None).GetUpperBound(0)];
                    Rusers = buff.Split(new string[] { "|" }, StringSplitOptions.None);
                }
                DrawOkUsers(Rusers, Rusers.GetUpperBound(0));
            }
        }

        void DrawReqUsers(string[] Rusers, int userCount)
        {
            for (int i = 0; i < userCount; i++)
            {
                string UserName = Regex.Split(Rusers[i], "ㅥ")[0];
                string Serial = Regex.Split(Rusers[i], "ㅥ")[1];
                lv_request.Items.Add(UserName);
                lv_request.Items[i].SubItems.Add(Serial);
            }
        }

        void DrawOkUsers(string[] Rusers, int userCount)
        {
            for (int i = 0; i < userCount; i++)
            {
                string UserName = Regex.Split(Rusers[i], "ㅥ")[0];
                string Serial = Regex.Split(Rusers[i], "ㅥ")[1].Split('|')[0];
                lv_ok.Items.Add(UserName);
                lv_ok.Items[i].SubItems.Add(Serial);
            }
        }

        void AddOkUser(string Name, string Serial)
        {
            WinHttp.WinHttpRequest add = new WinHttp.WinHttpRequest();
            string addString = AllUser(variables.hostURI, variables.OkViewValue) + Name + "ㅥ" + Serial + "|";
            //인증된 모든 사용자를 불러온 후 그 뒤에 새로 추가
            try
            {
                add.Open("GET", variables.hostURI + variables.OkSendValue + addString);
                add.Send();
                MessageBox.Show("요청을 수락했습니다.");
                DelReqUser(lv_request.FocusedItem.Text + "ㅥ" + lv_request.FocusedItem.SubItems[1].Text + "|", variables.ReqSendValue);
                GetRequestUsers(); //리스트 새로고침
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void DelReqUser(string del_user, string sendValue)
        {
            WinHttp.WinHttpRequest delete = new WinHttp.WinHttpRequest();
            string users = AllUser(variables.hostURI, variables.ReqViewValue);
            string re_users = users.Replace(del_user, string.Empty);
            try
            {
                delete.Open("GET", variables.hostURI + sendValue + re_users);
                delete.Send();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void DelOkUser(string del_user, string Value)
        {
            WinHttp.WinHttpRequest http = new WinHttp.WinHttpRequest();
            string users = AllUser(variables.hostURI, variables.OkViewValue);
            string re_users = users.Replace(del_user, string.Empty);
            try
            {
                http.Open("GET", variables.hostURI + Value + re_users);
                http.Send();
            }
            catch { }
        }

        string AllUser(string URI, string sendValue)
        {
            HttpWebRequest wReq;
            HttpWebResponse wRes;
            wReq = (HttpWebRequest)WebRequest.Create(URI + sendValue);
            wReq.Method = "GET";
            wRes = (HttpWebResponse)wReq.GetResponse();
            if (wRes.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader SR = new StreamReader(wRes.GetResponseStream(), Encoding.UTF8))
                {
                    return SR.ReadToEnd();
                }
            }
            return null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetRequestUsers();
            GetOkUsers();
        }

        private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOkUser(lv_request.FocusedItem.SubItems[0].Text, lv_request.FocusedItem.SubItems[1].Text);
        }

        private void refusalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelReqUser(lv_request.FocusedItem.Text + "ㅥ" + lv_request.FocusedItem.SubItems[1].Text + "|", variables.ReqSendValue);
            MessageBox.Show("요청을 거절했습니다.");
            GetRequestUsers();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelOkUser(lv_ok.FocusedItem.Text + "ㅥ" + lv_ok.FocusedItem.SubItems[1].Text + "|", variables.OkSendValue);
            MessageBox.Show("삭제하였습니다.");
            GetOkUsers();
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            GetRequestUsers();
            GetOkUsers();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}