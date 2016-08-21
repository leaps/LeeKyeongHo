using System;
using System.Text;

namespace PopAll_Article_Writer_Server
{
    class variables
    {
        public const string hostIP = "112.175.184.61";
        public const string hostID = "limejellys";
        public const string hostPW = "rudgh123";
        public const string hostURI = "http://limejellys.dothome.co.kr/webftp/php/connector.php?";
        public const string ArticletxtDirec = "html/Article.txt"; //hdd/RequestUsers.txt
        public const string IDtxtDirec = "html/ID.txt"; //hdd/OkUsers.txt

        public const string ArticleSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + ArticletxtDirec + "&content=";
        //public static string OkViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + oktxtDirec;
        public const string IDSendValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=put&target=f1_" + IDtxtDirec + "&content=";
        //public static string ReqViewValue = "host=" + hostIP + "&user=" + hostID + "&pass=" + hostPW + "&cmd=file&target=f1_" + reqtxtDirec;
    }
}
