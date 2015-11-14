using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsTcpApp
{
    public class SocketConfiguration
    {
        public string IPAdress { get; set; }
        public int Port { get; set; }
        public int ServerClient { get; set; }
        public int SendDelay { get; set; }
        public int MaxInfoTextLen { get; set; }
        public int PacketSize { get; set; }
    }
}
