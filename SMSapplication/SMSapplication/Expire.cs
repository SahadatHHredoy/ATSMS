using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSapplication
{
    public static class Expire
    {
    
        public static int GetRandomNumber()
        {
            return new Random().Next(1, 8);
        }
        public static string GetHexa(this string value)
        {
            byte[] ba = Encoding.Default.GetBytes(value);
            var hexString = BitConverter.ToString(ba);
            return hexString.Replace("-", "");
        }
        public static int GetLen(this string value)
        {
            return (value.Length - 2) / 2;
        }
    }
    
    public class Message
    {
        public int id { get; set; }
        public string mobile { get; set; }
        public string text { get; set; }
        public int  sent { get; set; }
        public int  user_Id { get; set; }
        public int  status { get; set; }
    }
    public class PDUMessage
    {
        public int id { get; set; }
        public string pdu { get; set; }
    }
    

}
