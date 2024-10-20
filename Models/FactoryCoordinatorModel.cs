using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace SbAdmin.Models
{
    public class FactoryCoordinatorModel
    {

        public int id { get; set; }
        public int factory_form_id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string tel { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public bool  alert_email { get; set; }
        public bool  alert_line { get; set; }
        public string create_by { get; set; }
        public DateTime  create_date { get; set; }
     
        public class GetListData
        {
           public int factory_form_id { get; set; }   
        }


       public class ListDataView
        {
        public int id { get; set; }
        public int factory_form_id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string tel { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public bool  alert_email { get; set; }
        public bool  alert_line { get; set; }
        public string create_by { get; set; }
        public string  create_date { get; set; }
        }

    }
}
