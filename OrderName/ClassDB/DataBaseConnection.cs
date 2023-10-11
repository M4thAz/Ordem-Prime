using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using Xamarin.Essentials;
using ZstdSharp.Unsafe;

namespace OrderName.ClassDB
{
    internal class DataBaseConnection
    {
        public static MySqlConnection ConectionDatabase = new MySqlConnection();

        static string server = "localhost";
        static string nameLinkDb = "julianodb";
        static string user = "root";
        static string password = "";
        public static MySqlConnection LinkDataBase()
        {
            MySqlConnection ConectionDatabase = new MySqlConnection($"server={server}; database={nameLinkDb}; host={user}; password={password}");
            return ConectionDatabase;

        }

        
        public void ConnectionOn()
        {
            try
            {
                LinkDataBase();
                ConectionDatabase.Open();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //finally
            //{
            //if (ConectionDatabase.State == System.Data.ConnectionState.Open)
            //    {
            //        ConectionDatabase.Close();
            //    }
            //}
        }


        public void ConectionOF()
        {
            LinkDataBase();
            ConectionDatabase.Close();
        }

    }
}
