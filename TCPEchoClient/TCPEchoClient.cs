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

            //Tester
            doit.GetAndSplitDictionary();

            const string sendPW = "vibeke:EQ91A67FOpjss4uW8kV570lnSa0=";
            string[] ipArray = new string[5];

            ipArray.SetValue("10.154.1.247", 0);
            ipArray.SetValue("10.154.1.254", 1);

            Console.WriteLine("Client-Server Chat Application");
            Console.Write("Choose chat name: ");


            Console.Write("\nChoose the destination IP address: localhost\n");
            //String ip = Console.ReadLine();
            //String ip = "10.154.1.247";

            Console.WriteLine(" --- Press Enter to open connection ---");
            Console.ReadLine();


            Thread thread1 = new Thread(() => doit.DoItMethod(sendPW, ipArray.GetValue(0).ToString()));
            Thread thread2 = new Thread(() => doit.DoItMethod(sendPW, ipArray.GetValue(1).ToString()));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Console.WriteLine("...Done...");
            Console.ReadLine();

        }//End of main
    
    }//End of class
}//End of namespace
