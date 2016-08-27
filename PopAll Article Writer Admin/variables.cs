using System;
using System.Text;

namespace PopAll_Article_Writer_Admin
{
    class variables
    {
        public const string hostIP = "112.175.184.60";
        public const string hostID = "eogh1439";
        public const string hostPW = "eogh0508";
        public const string hostURI = "http://eogh1439.dothome.co.kr/webftp/php/connector.php?";
        public static string reqtxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/RequestUsers.txt"));
        public static string oktxtDirec = Convert.ToBase64String(Encoding.Default.GetBytes("html/OkUsers.txt"));

        public static string OkSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + oktxtDirec + "&content=";
        public static string OkViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + oktxtDirec;
        public static string ReqSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + reqtxtDirec + "&content=";
        public static string ReqViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + reqtxtDirec;
    }
}
