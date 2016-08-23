using System.IO;

namespace PopAll_Article_Writer_Client
{
    class ImageDecaptcher
    {
        public ImageDecaptcher(ref string str)
        {
            uint p_pict_to = 0;
            uint p_pict_type = 0;
            uint major_id = 0;
            uint minor_id = 0;
            uint port = 3500;
            uint load = 0;
            string host = "api.decaptcher.com";
            string name = "wnsgus1437";
            string pass = "tkfkdgo11";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string answer_captcha;
            double balance;
            FileStream fs = new FileStream(path + @"\pic.png", FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            DecaptcherLib.Decaptcher.Balance(host, port, name, pass, out balance);
            DecaptcherLib.Decaptcher.SystemDecaptcherLoad(host, port, name, pass, out load);
            DecaptcherLib.Decaptcher.RecognizePicture(host, port, name, pass, buffer, out p_pict_to, out p_pict_type, out answer_captcha, out major_id, out minor_id);
            str = answer_captcha;
        }
    }
}
