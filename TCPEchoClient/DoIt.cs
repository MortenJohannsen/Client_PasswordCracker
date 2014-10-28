﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoClient
{
    public class DoIt
    {
        private string[] dictionaryArray = new string[50000];

        public void DoItMethod(string sendPW, string ip)
        {
            TcpClient clientSocket = new TcpClient(ip, 65080);
            Stream ns = clientSocket.GetStream(); //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            

            string message = sendPW;
            sw.WriteLine(message);


            Task<string> reading = sr.ReadLineAsync();
            reading.Wait();
            Console.WriteLine("result: " + reading.Result);


            Console.ReadLine();

            ns.Close();
            clientSocket.Close();
        }//End of DoItMethod

        public void GetAndSplitDictionary()
        {

            string dictionary = File.ReadAllText("webster-dictionary.txt");
            dictionaryArray = dictionary.Split(' ');
            Console.Write("Dictionary Total Length:");
            Console.WriteLine(dictionaryArray.Count() + "   -----   " + dictionaryArray.Length);


            //Create Dictionary 1
            string[] array1 = new string[30000];
            for (int i = 0; i <= (dictionaryArray.Length / 2); i++) { array1.SetValue(dictionaryArray.GetValue(i).ToString(), i); }

            Console.Write("Dictionary 1 Length:");
            Console.WriteLine(array1.Count() + "   -----   " + array1.Length);
            File.WriteAllLines("webster1.txt", array1);

            //Create Dictionary 2
            Array.Reverse(dictionaryArray);
            string[] array2 = new string[30000];
            for (int i = 0; i <= (dictionaryArray.Length / 2); i++) { array2.SetValue(dictionaryArray.GetValue(i).ToString(), i); }

            Console.Write("Dictionary 2 Length:");
            Console.WriteLine(array2.Count() + "   -----   " + array2.Length);
            File.WriteAllLines("webster2.txt", array2);


        }//End of GetAndSplitDictionary



    }//End of class
}//End of namespace
