using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace SbAdmin.Models
{
    public class FactoryUserModel
    {

        public int factory_id { get; set; }
        public string factory_name { get; set; }
        public string factory_password { get; set; }
        public string factory_number { get; set; }
        public string factory_email { get; set; }
        public string factory_tele { get; set; }
        public string create_by { get; set; }
        public string factory_active { get; set; } 
        public string factory_role { get; set; } 
        public DateTime  create_date { get; set; }
        

       public class GetListData
        {
           public int factory_id { get; set; }   
        }

        public class Login
        {
        public string factory_email { get; set; }
        public string factory_password { get; set; }
        }


        public class Register
        {
        public string factory_name { get; set; }
        public string factory_password { get; set; }
        public string factory_number { get; set; }
        public string factory_email { get; set; }
        public string factory_tele { get; set; }
        }

        public class ListDataView
        {
        public int factory_id { get; set; }
        public string factory_name { get; set; }
        public string factory_password { get; set; }
        public string factory_number { get; set; }
        public string factory_email { get; set; }
        public string factory_tele { get; set; }
        public string create_by { get; set; }
        public string  create_date { get; set; }
        public string  factory_role { get; set; }
        }




    }
}
