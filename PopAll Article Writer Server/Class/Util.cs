using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PopAll_Article_Writer_Server
{
    class Util
    {
        public void SetDirectory(TextBox tb_id, TextBox tb_vpn, TextBox tb_article)
        {
            StringBuilder sb = new StringBuilder();
            FileStream fs = new FileStream("Setting.dat", FileMode.Create, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(new AES().Encrypt(string.Format("{0}", tb_id.Text), "Life Is Egg"));
                sw.WriteLine(new AES().Encrypt(string.Format("{0}", tb_vpn.Text), "Life Is Egg"));
                sw.WriteLine(new AES().Encrypt(string.Format("{0}", tb_article.Text), "Life Is Egg"));
            }
            //sw.WriteLine(new AES().Encrypt(string.Format("{0}={1}", item, hash[item]), "Life Is Egg"));
            fs.Dispose();
            fs.Close();
        }

        public void GetDirectory(TextBox tb_id, TextBox tb_vpn, TextBox tb_article)
        {
            using (StreamReader sr = new StreamReader("Setting.dat"))
            {
                string[] str = new string[3];
                int i = 0;
                while (sr.Peek() > -1)
                {
                    str[i] = new AES().Decrypt(sr.ReadLine(), "Life Is Egg").Split('\n')[0];
                    i++;
                }
                tb_id.Text = str[0].Trim();
                tb_vpn.Text = str[1].Trim();
                tb_article.Text = str[2].Trim();
            }
        }

        public void GetTxt(ListView lv, string filename, int option)
        {
            lv.Items.Clear();
            using (StreamReader sr = new StreamReader(filename))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                    if (str.IndexOf("/") > 0)
                    {
                        if (option.Equals(0))
                        {
                            ListViewItem item = new ListViewItem(Regex.Split(str, "/")[1], 0);
                            item.Text = Regex.Split(str, "/")[0];
                            item.SubItems.Add(Regex.Split(str, "/")[1]);
                            lv.Items.Add(item);
                        }
                        else if (option.Equals(1))
                        {
                            ListViewItem item = new ListViewItem(Regex.Split(str, " ")[0]);
                            item.SubItems.Add(Regex.Split(str, " ")[1].Split('/')[0]);
                            item.SubItems.Add(Regex.Split(str, "/")[1]);
                            lv.Items.Add(item);
                        }
                    }
            }
        }

        public void SetTxt(ListView lv, string filename, int option)
        {
            using (StreamWriter sw = new StreamWriter("web/" + filename, false, Encoding.UTF8))
            {
                foreach (ListViewItem item in lv.Items)
                {
                    if (option.Equals(0))
                        sw.WriteLine(string.Format("{0}/{1}<br>", item.SubItems[0].Text, item.SubItems[1].Text));
                    else if (option.Equals(1))
                        sw.WriteLine(string.Format("{0}/{1}/{2}<br>", item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text));
                    else if (option.Equals(2)) { sw.WriteLine("ON"); break; }
                    else if (option.Equals(3)) { sw.WriteLine("OFF"); break; }
                }
            }
        }
    }
}
