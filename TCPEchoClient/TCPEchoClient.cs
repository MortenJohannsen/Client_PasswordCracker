using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPEchoClient
{
    class TCPEchoClient
    {

       
        static void Main(string[] args)
        {
            DoIt doit = new DoIt();

            

            const string sendPW = "per:AXPaVO/3DmqNsW2uPJw9ZJxf9lc=";
            string[] ipArray = new string[5];

            ipArray.SetValue("10.154.2.115", 0);
            ipArray.SetValue("10.154.1.217", 1);

            Console.WriteLine("Client-Server Chat Application");
            Console.Write("Choose chat name: ");


            Console.Write("\nChoose the destination IP address: localhost\n");
            //String ip = Console.ReadLine();
            //String ip = "10.154.1.247";

            Console.WriteLine(" --- Press Enter to open connection ---");
            Console.ReadLine();


            Thread thread1 = new Thread(() => doit.GetAndSplitDictionary(ipArray.GetValue(0).ToString(), 1));
            //Thread thread2 = new Thread(() => doit.GetAndSplitDictionary(ipArray.GetValue(1).ToString(), 2));
            thread1.Start();
            //thread2.Start();
            thread1.Join();
            //thread2.Join();

            Console.WriteLine(" --- Dictionaries Sent\n ---");
            Console.WriteLine(" --- Press Enter to Crack Passwords ---");
            Console.ReadLine();

            Thread thread3 = new Thread(() => doit.DoItMethod(sendPW, ipArray.GetValue(0).ToString()));
            //Thread thread4 = new Thread(() => doit.DoItMethod(sendPW, ipArray.GetValue(1).ToString()));
            thread3.Start();
            //thread4.Start();
            thread3.Join();
            //thread4.Join();

            Console.WriteLine("...Done...");
            Console.ReadLine();

        }//End of main
    
    }//End of class
}//End of namespace
