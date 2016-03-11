using System;
using System.IO;
using System.Net;
using System.Text;

namespace Examples.System.Net
{
    public class WebRequestPostExample
    {
        public static string Mainnn(string postData)
        {
            string result = string.Empty;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            WebRequest request = WebRequest.Create("http://tagger.jensenlab.org/GetEntities");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                dataStream.Dispose();
                dataStream.Close();
            }

            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        result = reader.ReadToEnd();

                        reader.Dispose();
                        reader.Close();
                    }

                    dataStream.Dispose();
                    dataStream.Close();
                }

                response.Dispose();
                response.Close();
            }

            return result;
        }
    }
}