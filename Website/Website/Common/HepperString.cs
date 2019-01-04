using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Security.Cryptography;


namespace Common
{
  
    public static class HepperString
    {
      //public static VnailmarketDBContext db = new VnailmarketDBContext();
      //  public static DateTime GetDateServer()
      //  {
      //      return  db.Database.SqlQuery<DateTime> ("spGetSystemDate").SingleOrDefault();
      //  }
       public static  int thisIsMagic(int year, int month, int day)
        {
            if (month < 3)
            {
                year--;
                month += 12;
            }
            return 365 * year + year / 4 - year / 100 + year / 400 + (153 * month - 457) / 5 + day - 306;
        }
      
      
        #region "String function"
        public static string RTESate(string strText)
        {
            string tmString = "";
            tmString = strText.Trim();
            tmString = tmString.Replace(char.ConvertFromUtf32(145), char.ConvertFromUtf32(39));
            tmString = tmString.Replace(char.ConvertFromUtf32(146), char.ConvertFromUtf32(39));
            tmString = tmString.Replace("'", "&#39;");

            tmString = tmString.Replace(char.ConvertFromUtf32(147), char.ConvertFromUtf32(34));
            tmString = tmString.Replace(char.ConvertFromUtf32(148), char.ConvertFromUtf32(34));
            tmString = tmString.Replace(char.ConvertFromUtf32(10), " ");
            tmString = tmString.Replace(char.ConvertFromUtf32(13), " ");

            return tmString;
        }
        /// <summary>
        ///Chuan hoa ho Ten Nguyen Tam Cuong
        /// </summary>
        /// <returns></returns>

        public static string StandardString(string strInput)
        {
            string strResult = "";
            if (strInput.Length > 0)
            {
                strInput = strInput.Trim().ToLower();
                while (strInput.Contains("  "))
                    strInput = strInput.Replace("  ", " ");

                string[] arrResult = strInput.Split(' ');
                foreach (string item in arrResult)
                    strResult += item.Substring(0, 1).ToUpper() + item.Substring(1) + " ";
            }
            return strResult.TrimEnd();
        }
        //Lay danh sach theo key
        public static List<string> GetListByKey(string text, string key)
        {
            List<string> listString = new List<string>();
            if (text != null)
            {
                if (text.Substring(text.Length - 1, 1).Equals(key))
                    text = text.Remove(text.Length - 1);
                while (text.IndexOf(key) != -1)
                {
                    string str = text.Substring(0, text.IndexOf(key));
                    listString.Add(str);
                    text = text.Substring(text.IndexOf(key) + 1);

                }
                listString.Add(text);
            }



            return listString;

        }

        #endregion
     

      

    }
}