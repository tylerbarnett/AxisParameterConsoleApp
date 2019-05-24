using System;
using System.IO;
using System.Net;

namespace GetAxisSettings
{
  class Program
  {
    static void Main(string[] args)
    {

      try
      {
        //Enter the VAPIX command. Here we use param.cgi with the list action. 192.168.0.90 is the IP address of the Axis product.
        var ParamList = "http://192.168.0.90/axis-cgi/param.cgi?action=list&responseformat=rfc";
        NetworkCredential networkCredential = new NetworkCredential("root", "password");
        WebRequest request = WebRequest.Create(ParamList);
        request.Credentials = networkCredential;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream streamResponse = response.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse);
        Char[] readBuff = new Char[256000];
        int count = streamRead.Read(readBuff, 0, 256000);
        Console.WriteLine(new string(readBuff, 0, count));
        count = streamRead.Read(readBuff, 0, 256000);
        // Close and release the response.
        streamRead.Close();
        streamResponse.Close();
        response.Close();
      }
      catch (Exception es)
      {
        Console.WriteLine(es.ToString(), "\nError Message");
      }
    }
  }
}
