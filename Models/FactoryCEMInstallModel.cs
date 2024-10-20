using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace SbAdmin.Models
{
    public class FactoryCEMInstallModel
    {

        public int id { get; set; }
        public int factory_form_id { get; set; }
        public int no { get; set; }
        public string production_name { get; set; }
        public string chimney_name { get; set; }
        public string chimney_type { get; set; }
        public string install_eia { get; set; }
        public string install_announce { get; set; }
        public string install_disposed { get; set; }
        public bool action_installed { get; set; }
        public bool action_not_install { get; set; }
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
        public int no { get; set; }
        public string production_name { get; set; }
        public string chimney_name { get; set; }
        public string chimney_type { get; set; }
        public string install_eia { get; set; }
        public string install_announce { get; set; }
        public string install_disposed { get; set; }
        public bool action_installed { get; set; }
        public bool action_not_install { get; set; }
        public string create_by { get; set; }
        public string  create_date { get; set; }

        }

    }
}
