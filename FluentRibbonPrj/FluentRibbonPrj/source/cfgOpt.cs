using MyAppender;
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace FluentRibbonPrj.source
{

    class cfgOpt
    {
        public static int namecol = 1;
        public static int agecol = 2;


        static string cfgpathname = System.AppDomain.CurrentDomain.BaseDirectory + "cfg.ini";
        public static void read()
        {
            namecol = GetPrivateProfileInt("col", "namecol");
            agecol = GetPrivateProfileInt("col", "agecol");
        }
        public static void write()
        {
            WritePrivateProfileStr("col", "namecol", namecol.ToString());
            WritePrivateProfileStr("col", "agecol", agecol.ToString());
        }


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public static string GetPrivateProfileStr(string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            if (0 == GetPrivateProfileString(section, key, "", temp, 1024, cfgpathname)) return "";
            return temp.ToString();
        }
        public static int GetPrivateProfileInt(string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, cfgpathname);
            string str =  temp.ToString();
            int val = 0;
            try
            {
                val = Convert.ToInt32(str);
            }
            catch(Exception e)
            {
                MyLogger.logger.Error(e);
            }    
            return val;
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static void WritePrivateProfileStr(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, cfgpathname);
        }
    }
}
