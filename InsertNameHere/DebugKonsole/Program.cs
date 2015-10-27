using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DebugKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient();
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 16000);
            udp.Client.Bind(localEp);
            while (true)
            {
                var receiveBytes = udp.Receive(ref localEp);
                string res = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine(GetTimeString() + res);
            }
        }

        static string GetTimeString()
        {
            return "[" + DateTime.Now.ToShortTimeString() + "]";
        }
    }
}
