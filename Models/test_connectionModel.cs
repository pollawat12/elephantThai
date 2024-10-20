using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace SbAdmin.Models
{
    public class test_connectionModels
    {

        public int id { get; set; }
        public string detail1 { get; set; }
        public string detail2 { get; set; }
        public List<BannerData> arry1 {set;get;}

       public class BannerData
        {
            public string BannerData1 { get; set; }
            public string BannerData2 { get; set; }
            public string BannerData3 { get; set; }

        }


    }
}
