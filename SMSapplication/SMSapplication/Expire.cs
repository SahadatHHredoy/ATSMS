using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSapplication
{
    public static class Expire
    {
    
        public static string AppVersion()
        {
            return "2.1.1";
        }
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
        public static OutgoingSmsPdu[] GetPdus(this string number, string text)
        {
            OutgoingSmsPdu[] pdus = null;
            text = text.Replace("\r", "");
            text = text.Replace("\n", "");
            pdus = SmartMessageFactory.CreateConcatTextMessage(text, true, number);
            return pdus;
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
        public string[] pdu { get; set; }
    }
    

}
