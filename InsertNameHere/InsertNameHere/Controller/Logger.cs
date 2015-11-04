using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace InsertNameHere.Controller
{
    public static class Logger
    {
        public static UdpClient udp = new UdpClient();
        public static IPEndPoint groupEP = new IPEndPoint(IPAddress.Broadcast, 16000);
        public static void Shoot(string str)
        {
            //Console.WriteLine(str);
            byte[] sendBytes = Encoding.ASCII.GetBytes(str);
            var bsent = udp.Send(sendBytes, sendBytes.Length, groupEP);
        }
    }
}
