using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Design
{
    class API
    {
        public string SendPost(string url, string postData)
        {
            string webpageContent = string.Empty;

            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = byteArray.Length;

                using (Stream webpageStream = webRequest.GetRequestStream())
                {
                    webpageStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        webpageContent = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw or return an appropriate response/exception
                //MessageBox.Show("" + ex.ToString());
                Console.WriteLine("" + ex.ToString());
            }

            return webpageContent;
        }

        public void onAddLogs(String name, String activity, String user_level)
        {
            String query = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertLogs.php";
            try
            {
                String res = SendPost(query, String.Format("name={0}&activity={1}&user_level={2}", name, activity, user_level));
                var data = JObject.Parse(res);
                string response = data["success"].ToString();
                if (response == "true")
                {
                    Console.WriteLine("Logs Inserted");
                }
                else
                {
                    Console.WriteLine("Request: 500 Internal Error: ");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }


        }
    }
}
