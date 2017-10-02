using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CRMSystem.Utilities
{
    public class Log
    {
        public static void LogText(string text)
        {
            using (StreamWriter writer = new StreamWriter("D:/University/Web Development sep2017/Semester I/Backend/C# Exercises/CRMSystem Solution/CRMSystem/Logs/logfile.txt", true))
            {
                writer.WriteLine("--------------------");
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine("--------------------");
                writer.WriteLine(text);
                writer.Flush();
                writer.Close();
            }
        }

        public static void LogException(Exception ex)
        {
            LogText(ex.ToString());
        }
    }
}