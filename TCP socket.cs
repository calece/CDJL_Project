﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace userTester
{
    public class TCP_socket
    {
        private static Thread rxThread = new Thread(new ThreadStart(rxData));
        private static Thread txThread = new Thread(new ThreadStart(txData));
        private static TcpClient serverSocket = new TcpClient();
        private static Stream stm;
        private static ASCIIEncoding asen = new ASCIIEncoding();
        private const string ADDRESS = "JShikany.asuscomm.com";
        private const int PORT = 27405;

        public TCP_socket()
        {
            initializeSocket();

            rxThread.IsBackground = true;
            rxThread.Start();
            txThread.IsBackground = true;
            txThread.Start();
        }

        ~TCP_socket()
        {
            Console.WriteLine("************************DISPOSED**************************");
            Console.Read();

            serverSocket.Close();
            rxThread.Abort();
        }

        private static int retryCount = 0;

        private static void initializeSocket()
        {
            serverSocket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            try
            {
                serverSocket.Connect(ADDRESS, PORT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Connected");
            stm = serverSocket.GetStream();
            stm.Flush();
            byte[] initialString = asen.GetBytes("!,0,user,#");
            stm.Write(initialString, 0, initialString.Length);
            stm.Flush();
        }

        private static void txData()
        {
            bool bailout = false;
            while (!bailout)
            {
                try
                {
                    if (userTester.Form1.Exchange.queryData)
                    {
                        userTester.Form1.Exchange.queryData = false;
                        byte[] sendData = asen.GetBytes("!,A,Jeff,#");
                        stm.Write(sendData, 0, sendData.Length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Read();
                    if (retryCount > 100)
                        bailout = true;

                    serverSocket.Close();
                    serverSocket.Connect(ADDRESS, PORT);
                    Console.WriteLine("reconnected");
                    stm = serverSocket.GetStream();
                }
                retryCount = 0;

                Thread.Sleep(100);
            }
        }

        private static void rxData()
        {
            bool bailout = false;
            while (!bailout)
            {
                try
                {
                    byte[] receiveBuffer = new byte[512];
                    int k = stm.Read(receiveBuffer, 0, 512);
                    stm.Flush();
                    string temp = formatString(System.Text.Encoding.ASCII.GetString(receiveBuffer));
                    if (temp != null)
                    {
                        string[] tempArr = temp.Split(new Char[] { ',' });
                        string din = string.Empty;
                        for (int i = 0; i < tempArr.Length; i++)
                            din += tempArr[i] + " ";

                        userTester.Form1.Exchange.dataIn = din;
                        userTester.Form1.Exchange.inDataReady = true;
                    }

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Read();
                    if (retryCount > 100)
                        bailout = true;

                    serverSocket.Close();
                    serverSocket.Connect(ADDRESS, PORT);
                    Console.WriteLine("reconnected");
                    stm = serverSocket.GetStream();
                }
                retryCount = 0;

                Thread.Sleep(100);
            }
        }

        private static string formatString(string input)
        {
            string[] split = input.Split(new Char[] { ',' });
            string completedString = string.Empty;
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "!")
                {
                    completedString = string.Empty;
                }
                else if (split[i][0] == '#')
                    return completedString;
                else
                    completedString += split[i] + ",";
            }
            return null;
        }

    }
}