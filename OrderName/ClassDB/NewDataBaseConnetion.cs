using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using MySql.Data.MySqlClient;


namespace OrderName.ClassDB
{
    internal class NewDataBaseConnetion
    {
        public NewDataBaseConnetion()
        {

        }

        const string connectionTest = "server=localhost; database=julianodb; Uid=root; password=;";
        public static MySqlConnection TesteDaConexao() {
        
            MySqlConnection conn = new MySqlConnection(connectionTest);
            return conn;
    }


       public void TestOnConection()
        {
            TesteDaConexao();
        }

    }

}


