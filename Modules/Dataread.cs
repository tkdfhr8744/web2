 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using test;

namespace web2.Modules
{
 public class Database
    {
        public MySqlConnection GetConnection()
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\DataInfo";
                MySqlConnection conn = new MySqlConnection();
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());//해당 시스템의 ip를 받아온다.
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    //Console.WriteLine("1");
                    if (host.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        //Console.WriteLine("2");
                        string temp=path+"\\116.txt";
                        string inputFile = File.ReadAllText(temp);
                        string targetip = host.AddressList[i].ToString();
                 
                        if(targetip=="192.168.3.116")
                        {
                            conn.ConnectionString = inputFile;
                            Console.WriteLine(inputFile);
                        }
                        else
                        {
                            Console.WriteLine("1");
                            string temp2=path+"\\147.txt";
                            string inputFile2 = File.ReadAllText(temp2);
                            conn.ConnectionString = inputFile2;
                            Console.WriteLine(inputFile2);
                        }
                    }
                }
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

    }
}