using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PopAll_Article_Writer_Server
{
    class Web
    {
        public void Webs()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9999);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(20);
            while (true)
            {
                Socket client = server.Accept();
                try
                {
                    String file = Recieve(client);
                    FileInfo FI = new FileInfo(file);
                    client.Send(Header(client, FI));
                }
                catch { }
                finally
                {
                    client.Close();
                }
            }
        }
        public String Recieve(Socket client)
        {
            String _data_str = "";
            byte[] _data = new byte[4096];
            client.Receive(_data);
            String[] _buf = Encoding.UTF8.GetString(_data).Split("\r\n".ToCharArray());
            if (_buf[0].IndexOf("GET") != -1)
            {
                _data_str = _buf[0].Replace("GET ", "").Replace("HTTP/1.1", "").Trim();
            }
            else
            {
                _data_str = _buf[0].Replace("POST ", "").Replace("HTTP/1.1", "").Trim();
            }
            if (_data_str.Trim() == "/")
            {
                _data_str += "index.html";
            }
            int pos = _data_str.IndexOf("?");
            if (pos > 0)
            {
                _data_str = _data_str.Remove(pos);
            }
            return "web" + _data_str;
        }
        public byte[] Header(Socket client, FileInfo FI)
        {
            byte[] _data2 = new byte[FI.Length];
            try
            {
                FileStream FS = new FileStream(FI.FullName, FileMode.Open, FileAccess.Read);
                FS.Read(_data2, 0, _data2.Length);
                FS.Close();

                String _buf = "HTTP/1.0 200 ok\r\n";
                _buf += "Data: " + FI.CreationTime.ToString() + "\r\n";
                _buf += "server: Myung server\r\n";
                _buf += "Content-Length: " + _data2.Length.ToString() + "\r\n";
                _buf += "content-type:text/html\r\n";
                _buf += "\r\n";
                //_buf.Replace("\n", "<br>");
                client.Send(Encoding.UTF8.GetBytes(_buf));
            }
            catch
            {
                String _buf = "HTTP/1.0 100 BedRequest ok\r\n";
                _buf += "server: Myung server\r\n";
                _buf += "content-type:text/html\r\n";
                _buf += "\r\n";
                client.Send(Encoding.UTF8.GetBytes(_buf));
                _data2 = Encoding.UTF8.GetBytes("Bed Request");
            }
            return _data2;
        }
    }
}
