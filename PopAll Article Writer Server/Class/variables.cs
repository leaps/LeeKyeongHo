using System;
using System.Text;

namespace PopAll_Article_Writer_Server
{
    class variables
    {
        public const string hostIP = "112.175.184.60";
        public const string hostID = "eogh1439";
        public const string hostPW = "eogh0508";
        public const string hostURI = "http://eogh1439.dothome.co.kr/webftp/php/connector.php?";
        public static string ArticletxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/Article.txt")); //hdd/RequestUsers.txt
        public static string IDtxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/ID.txt")); //hdd/OkUsers.txt


        //public static string ProcessOnOff = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_&content=";

        public static string ArticleSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + ArticletxtDirec + "&content=";
        //public const string OkViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + oktxtDirec;
        public static string IDSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + IDtxtDirec + "&content=";
        //public const string ReqViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + reqtxtDirec;
    }
}
