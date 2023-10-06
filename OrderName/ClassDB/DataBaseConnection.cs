using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace OrderName.ClassDB
{
    internal class DataBaseConnection
    {
        public static MySqlConnection ConectionDatabase = new MySqlConnection();

        static string server = "127.0.0.1";
        static string nameLinkDb = "julianodb";
        static string host = "root";
        static string password = "";


        public static MySqlConnection LinkDataBase()
        {
            ConectionDatabase = new MySqlConnection($"server={server}; nameLinkDb={nameLinkDb}; host={host}; password={password}");
            return ConectionDatabase;

        }

        public void ConectionOn()
        {
            LinkDataBase();
            ConectionDatabase.Open();
        }


        public void ConectionOF()
        {
            LinkDataBase();
            ConectionDatabase.Close();
        }

    }
}
