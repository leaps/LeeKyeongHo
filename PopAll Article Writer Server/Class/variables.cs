using System;
using System.Text;

namespace PopAll_Article_Writer_Server.Class
{
    class variables
    {
        public static string hostIP = "112.175.184.61";
        public static string hostID = "limejellys";
        public static string hostPW = "rudgh123";
        public static string hostURI = "http://limejellys.dothome.co.kr/webftp/php/connector.php?";
        public static string ArticletxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/Article.txt")); //hdd/RequestUsers.txt
        public static string IDtxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/ID.txt")); //hdd/OkUsers.txt

        public static string ArticleSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + ArticletxtDirec + "&content=";
        //public static string OkViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + oktxtDirec;
        public static string IDSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + IDtxtDirec + "&content=";
        //public static string ReqViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + reqtxtDirec;
    }
}
