using System;
using MySql.Data.MySqlClient;

namespace SbAdmin
{
    public class Constants
    {
       public string   ConnectionString = "";
   
        public MySqlConnection GetConnection()
        {
           ConnectionString = "Server=103.30.127.29;Database=cotdev_factory_form;Port=3306;Username=cotdev_factory;Password=Vg8c089f#;CharSet=utf8";
            return new MySqlConnection(ConnectionString);
        }
   

        public struct Status
        {
         public const string active = "A";
         public const string InActive = "I";
        }

       public struct FactoryStatus
        {
         public const string waiting = "1";
         public const string approved = "2";
        }

        
        public struct Role
        {
         public const string user = "1";
         public const string admin = "0";
        }


    }
}
