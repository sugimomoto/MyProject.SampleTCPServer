﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyProject.SampleTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ipAdd = IPAddress.Parse("127.0.0.1");

            var port = 2001;
            var listner = new TcpListener(ipAdd, port);

            listner.Start();

            Console.WriteLine($"Listenを開始しました。IP Address : {((IPEndPoint)listner.LocalEndpoint).Address} / Port : {((IPEndPoint)listner.LocalEndpoint).Port}");

            var client = listner.AcceptTcpClient();

            Console.WriteLine($"クライアント {((IPEndPoint)client.Client.RemoteEndPoint).Address}:{((IPEndPoint)client.Client.RemoteEndPoint).Port} と接続しました。");

            var ns = client.GetStream();

            var enc = Encoding.UTF8;
            var disconnected = false;
            var ms = new MemoryStream();

            var resBytes = new byte[256];
            var resSize = 0;

            do
            {
                resSize = ns.Read(resBytes, 0, resBytes.Length);
                if(resSize == 0)
                {
                    disconnected = true;
                    Console.WriteLine("クライアントが切断しました");
                    break;
                }

                ms.Write(resBytes, 0, resSize);

            }



        }
    }
}