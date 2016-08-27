using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAll_Article_Writer_Server
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        void SendRequest(string Value)
        {
            WinHttp.WinHttpRequest sendReq = new WinHttp.WinHttpRequest();
            string reqString = AllUser(variables.hostURI, variables.ReqViewValue) + tb_name.Text + "ㅥ" + tb_serial.Text + "|";
            Value += reqString;
            try
            {
                sendReq.Open("GET", variables.hostURI + Value);
                sendReq.Send();
                MessageBox.Show("요청을 완료하였습니다.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        bool AccessUser(string Serial)
        {
            if (AllUser(variables.hostURI, variables.OkViewValue).Contains(Serial))
                return true;
            return false;
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            SendRequest(variables.ReqSendValue);
        }

        private void tm_timer_Tick(object sender, EventArgs e)
        {
            if (AccessUser(tb_serial.Text))
            {
                MessageBox.Show("Access");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\CIMV2", "SELECT * FROM Win32_LogicalDisk WHERE Name = 'C:'");
            foreach (ManagementObject obj in searcher.Get())
                tb_serial.Text = obj["VolumeSerialNumber"].ToString();
            if (AccessUser(tb_serial.Text))
            {
                MessageBox.Show("Access");
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
