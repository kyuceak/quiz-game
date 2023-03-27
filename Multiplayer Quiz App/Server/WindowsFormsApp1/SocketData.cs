using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class SocketData
    {
       public string uniqueName { get; set; }
       public string question { get; set; }
       public string answer { get; set; }
       public double score { get; set; }
       public double totalScore { get; set; }
       public double deviation { get; set; }
       public Socket socket { get; set; }
       public bool isInGame { get; set; }
       public bool isAnswered { get; set; }
    }
}
