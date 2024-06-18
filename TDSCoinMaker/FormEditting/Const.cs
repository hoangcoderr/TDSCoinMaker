using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TDSCoinMaker.FormEditting
{
    public class Const
    {
        public static string ACCOUNT_PATH = "config\\account.ini";
        public static string CLIENT_PATH = "config\\client.ini";
        public static string GETTING_TDS_JOB = "Getting TDS Job";
        public static string GETTING_TDS_COMPLETE = "Get TDS Job Complete!";
        public static string FACEBOOK_URL = "https://www.facebook.com/";
        public static string DOING_JOB = "Doing Job ";
        public static string DONE_JOB = "Done Job ";
        public static string FAIL_JOB = "Fail Job ";
        public static string DO_NEXT_JOB_IN = "Do next job in ";
        public static string DO_ENOUGH_JOB = "Do enough job, do next job at ";
        public static string[] LIST_TYPE_JOB = { "like", "reaction", "reaction", "like"};
        public static int[] LIST_XU_CLAIM_BY_JOB = { 300, 400, 400, 300 };
        public static int TDS_XU_INDEX = 7;
        public static int FB_TOKEN_INDEX = 1;
        public static int TDS_TOKEN_INDEX = 2;
        public static int LOGGER_INDEX = 9;
        public static int ACTION_INDEX = 8;
        public static int PROXY_INDEX = 5;
        public static string NO_INTERNET_CONNECTION = "No internet connection";
        public static int LIKE_BUTTON_INDEX = 0;
        public static int LOVE_BUTTON_INDEX = 1;
        public static int CARE_BUTTON_INDEX = 2;
        public static int HAHA_BUTTON_INDEX = 3;
        public static int WOW_BUTTON_INDEX = 4;
        public static int SAD_BUTTON_INDEX = 5;
        public static int ANGRY_BUTTON_INDEX = 6;
    }
}
