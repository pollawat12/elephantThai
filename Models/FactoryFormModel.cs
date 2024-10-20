using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;


namespace SbAdmin.Models
{
    public class FactoryFormModel
    {

        public int factory_form_id { get; set; }
        public string factory_name { get; set; }
        public string factory_number { get; set; }
        public string factory_business { get; set; }
        public string factory_fuel_type { get; set; }
        public string factory_location_number { get; set; }
        public string factory_location_moo { get; set; }
        public string factory_location_soi { get; set; }
        public string factory_location_road { get; set; }
        public string factory_location_subdistrict { get; set; }
        public string factory_location_district { get; set; }
        public string factory_location_province { get; set; }
        public string factory_location_zipcode { get; set; }
        public string factory_chimney_install { get; set; }
        public string factory_chimney_finish { get; set; }
        public string IP { get; set; }
        public string DNS { get; set; }
        public string FTP { get; set; }
        public string port_number { get; set; }
        public string logger_brand { get; set; }
        public string logger_model { get; set; }
        public string logger_id { get; set; }
        public int factory_id { get; set; }   
        public string create_by { get; set; }
        public string factory_status { get; set; }
        public DateTime  create_date { get; set; }
        
        
        public List<FactoryCoordinatorModel> factoryCoordinator {set;get;}
        public List<FactoryCEMInstallModel> factoryCEMInstall {set;get;}
        public List<FactoruMeasureModel> factoruMeasure {set;get;}


        public class GetListData
        {
           public int factory_id { get; set; }   
           public int factory_form_id { get; set; }
        }


        public class ListDataView
        {
        public int factory_form_id { get; set; }
        public string factory_name { get; set; }
        public string factory_number { get; set; }
        public string factory_business { get; set; }
        public string factory_fuel_type { get; set; }
        public string factory_location_number { get; set; }
        public string factory_location_moo { get; set; }
        public string factory_location_soi { get; set; }
        public string factory_location_road { get; set; }
        public string factory_location_subdistrict { get; set; }
        public string factory_location_district { get; set; }
        public string factory_location_province { get; set; }
        public string factory_location_zipcode { get; set; }
        public string factory_chimney_install { get; set; }
        public string factory_chimney_finish { get; set; }
        public string IP { get; set; }
        public string DNS { get; set; }
        public string FTP { get; set; }
        public string port_number { get; set; }
        public string logger_brand { get; set; }
        public string logger_model { get; set; }
        public string logger_id { get; set; }
        public int factory_id { get; set; }   
        public string  create_by { get; set; }
        public string  create_date { get; set; }
        public string factory_status { get; set; }
        }


        public class UpdateData
        {
           public int factory_id { get; set; }   
           public int factory_form_id { get; set; }
           public string factory_status { get; set; }
        }
        


    }
}
