using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace SbAdmin.Models
{
    public class FactoruMeasureModel
    {

        public int id { get; set; }
        public int factory_form_id { get; set; }
        public int no { get; set; }
        public string parameter { get; set; }
        public string unit { get; set; }
        public string range2 { get; set; }
        public string eia { get; set; }
        public string chimney_name { get; set; }
        public string chimney_width { get; set; }
        public string chimney_height { get; set; }
        public string channel_number { get; set; }
        public string chimney_coordinates_x { get; set; }
        public string chimney_coordinates_y { get; set; }
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
        public string parameter { get; set; }
        public string unit { get; set; }
        public string range2 { get; set; }
        public string eia { get; set; }
        public string chimney_name { get; set; }
        public string chimney_width { get; set; }
        public string chimney_height { get; set; }
        public string channel_number { get; set; }
        public string chimney_coordinates_x { get; set; }
        public string chimney_coordinates_y { get; set; }
        public string create_by { get; set; }
        public string  create_date { get; set; }

        }




    }
}
