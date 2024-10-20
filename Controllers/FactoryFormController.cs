using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using SbAdmin.Models; 
using SbAdmin; 
using System.IO;
using Newtonsoft.Json;



namespace SbAdmin.Controllers
{
    //  [Route("api/[controller]")]
    [ApiController]
    [Route("FactoryFormController")]
    public class FactoryFormController : ControllerBase
    {
        public FactoryFormController()
        {
        }

      
        [HttpPost("InsertFactoryData")]
        public  IActionResult InsertFactoryData([FromBody] FactoryFormModel data)
        {
            IActionResult response = Unauthorized();
            FactoryFormModel insertData = new FactoryFormModel();

          //  Console.WriteLine(data.factoryCoordinator.Count());
          //  Console.WriteLine(data.factoryCEMInstall.Count());
            if (string.IsNullOrEmpty(data.factory_name.ToString()) || string.IsNullOrEmpty(data.factory_number.ToString()))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }

             Constants Constants = new Constants();


            string createBy = data.create_by; 
            DateTime todayDate = DateTime.Now; 
            insertData.factory_name = data.factory_name;
            insertData.factory_number = data.factory_number;
            insertData.factory_business = data.factory_business;
            insertData.factory_fuel_type = data.factory_fuel_type;
            insertData.factory_location_number = data.factory_location_number;
            insertData.factory_location_moo = data.factory_location_moo;
            insertData.factory_location_soi = data.factory_location_soi;
            insertData.factory_location_road = data.factory_location_road;
            insertData.factory_location_subdistrict = data.factory_location_subdistrict;
            insertData.factory_location_district = data.factory_location_district;
            insertData.factory_location_province = data.factory_location_province;
            insertData.factory_location_zipcode = data.factory_location_zipcode;
            insertData.factory_chimney_install = data.factory_chimney_install;
            insertData.factory_chimney_finish = data.factory_chimney_finish;
            insertData.IP = data.IP;
            insertData.DNS = data.DNS;
            insertData.FTP = data.FTP;
            insertData.port_number = data.port_number;
            insertData.logger_brand = data.logger_brand;
            insertData.logger_model = data.logger_model;
            insertData.logger_id = data.logger_id;
            insertData.factory_id = data.factory_id;
            insertData.create_by = createBy;
            insertData.create_date = todayDate;  
            insertData.factory_status = Constants.FactoryStatus.waiting;


            var factoryFormData_1 =  InsertFactoryForm(insertData);
        
            Console.WriteLine(factoryFormData_1);
            foreach(var item in data.factoryCoordinator )
            {
             FactoryCoordinatorModel factoryCoordinatorData = new FactoryCoordinatorModel();
             factoryCoordinatorData.factory_form_id = Convert.ToInt32(factoryFormData_1) ;
             factoryCoordinatorData.name = item.name;
             factoryCoordinatorData.position = item.position;
             factoryCoordinatorData.tel = item.tel;
             factoryCoordinatorData.mobile = item.mobile;
             factoryCoordinatorData.email = item.email;
             factoryCoordinatorData.alert_email = item.alert_email;
             factoryCoordinatorData.alert_line = item.alert_line;
             factoryCoordinatorData.create_by = createBy; 
             factoryCoordinatorData.create_date = todayDate;  
             var insertData_2 =  InsertFactoryCoordinatorData(factoryCoordinatorData);
         //    Console.WriteLine(item.name);
            }


            Console.WriteLine(factoryFormData_1);
            foreach(var item in data.factoryCEMInstall )
            {
             FactoryCEMInstallModel factoryCEMInstall = new FactoryCEMInstallModel();
             factoryCEMInstall.factory_form_id = Convert.ToInt32(factoryFormData_1) ;
             factoryCEMInstall.no = item.no;
             factoryCEMInstall.production_name = item.production_name;
             factoryCEMInstall.chimney_name = item.chimney_name;
             factoryCEMInstall.chimney_type = item.chimney_type;
             factoryCEMInstall.install_eia = item.install_eia;
             factoryCEMInstall.install_announce = item.install_announce;
             factoryCEMInstall.install_disposed = item.install_disposed;
             factoryCEMInstall.action_installed = item.action_installed;
             factoryCEMInstall.action_not_install = item.action_not_install;  
             factoryCEMInstall.create_by = createBy;
             factoryCEMInstall.create_date = todayDate;  
             var insertData_3 =  InsertFactoryCEMInstall(factoryCEMInstall);
         //    Console.WriteLine(item.name);
            }

            Console.WriteLine(factoryFormData_1);
            foreach(var item in data.factoruMeasure )
            {
             FactoruMeasureModel factoruMeasure = new FactoruMeasureModel();
             factoruMeasure.factory_form_id = Convert.ToInt32(factoryFormData_1) ;
             factoruMeasure.no = item.no;
             factoruMeasure.parameter = item.parameter;
             factoruMeasure.unit = item.unit;
             factoruMeasure.range2 = item.range2;
             factoruMeasure.eia = item.eia;
             factoruMeasure.chimney_name = item.chimney_name;
             factoruMeasure.chimney_width = item.chimney_width;
             factoruMeasure.chimney_height = item.chimney_height;
             factoruMeasure.channel_number = item.channel_number;  
             factoruMeasure.chimney_coordinates_x = item.chimney_coordinates_x;
             factoruMeasure.chimney_coordinates_y = item.chimney_coordinates_y;  
             factoruMeasure.create_by = createBy;
             factoruMeasure.create_date = todayDate;  
             var insertData_4 =  InsertFactoruMeasure(factoruMeasure);
         //    Console.WriteLine(item.name);
            }


            if (factoryFormData_1 != null)
            {
                response = Ok(new { status = "s" });
            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }
        private string InsertFactoryForm(FactoryFormModel data)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO factory_form (factory_name, factory_number , factory_business, factory_fuel_type, factory_location_number, factory_location_moo, factory_location_soi, factory_location_road, factory_location_subdistrict, factory_location_district, factory_location_province, factory_location_zipcode, factory_chimney_install, factory_chimney_finish, IP, DNS, FTP, port_number, logger_brand, logger_model, logger_id, factory_id, create_by, create_date,factory_status)                 
                VALUES (@factory_name, @factory_number, @factory_business, @factory_fuel_type, @factory_location_number, @factory_location_moo, @factory_location_soi, @factory_location_road, @factory_location_subdistrict, @factory_location_district, @factory_location_province, @factory_location_zipcode, @factory_chimney_install, @factory_chimney_finish, @IP, @DNS, @FTP, @port_number, @logger_brand, @logger_model, @logger_id, @factory_id, @create_by, @create_date,@factory_status) ; SELECT LAST_INSERT_ID();", conn);

                cmd.Parameters.AddWithValue("@factory_name", data.factory_name);
                cmd.Parameters.AddWithValue("@factory_number", data.factory_number);
                cmd.Parameters.AddWithValue("@factory_business", data.factory_business);
                cmd.Parameters.AddWithValue("@factory_fuel_type", data.factory_fuel_type);
                cmd.Parameters.AddWithValue("@factory_location_number", data.factory_location_number);
                cmd.Parameters.AddWithValue("@factory_location_moo", data.factory_location_moo);
                cmd.Parameters.AddWithValue("@factory_location_soi", data.factory_location_soi);
                cmd.Parameters.AddWithValue("@factory_location_road", data.factory_location_road);
                cmd.Parameters.AddWithValue("@factory_location_subdistrict", data.factory_location_subdistrict);
                cmd.Parameters.AddWithValue("@factory_location_district", data.factory_location_district);
                cmd.Parameters.AddWithValue("@factory_location_province", data.factory_location_province);
                cmd.Parameters.AddWithValue("@factory_location_zipcode", data.factory_location_zipcode);
                cmd.Parameters.AddWithValue("@factory_chimney_install", data.factory_chimney_install);
                cmd.Parameters.AddWithValue("@factory_chimney_finish", data.factory_chimney_finish);
                cmd.Parameters.AddWithValue("@IP", data.IP);
                cmd.Parameters.AddWithValue("@DNS", data.DNS);
                cmd.Parameters.AddWithValue("@FTP", data.FTP);
                cmd.Parameters.AddWithValue("@port_number", data.port_number);
                cmd.Parameters.AddWithValue("@logger_brand", data.logger_brand);
                cmd.Parameters.AddWithValue("@logger_model", data.logger_model);
                cmd.Parameters.AddWithValue("@logger_id", data.logger_id);
                cmd.Parameters.AddWithValue("@factory_id", data.factory_id);
                cmd.Parameters.AddWithValue("@create_by", data.create_by);
                cmd.Parameters.AddWithValue("@create_date", data.create_date);
                cmd.Parameters.AddWithValue("@factory_status", data.factory_status);

                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                long id = cmd.LastInsertedId; 
                while (reader.Read())
                {
                }
                response = id.ToString();
                conn.Close();
            }
                 Console.WriteLine("data.arry1.Count()");
                 return response;
        }


         private string InsertFactoryCoordinatorData(FactoryCoordinatorModel data)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO factory_coordinator (factory_form_id,name,position,tel,mobile,email,alert_email,alert_line, create_by, create_date)                 
                VALUES (@factory_form_id,@name,@position,@tel,@mobile,@email,@alert_email,@alert_line, @create_by, @create_date) ; SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                cmd.Parameters.AddWithValue("@name", data.name);
                cmd.Parameters.AddWithValue("@position", data.position);
                cmd.Parameters.AddWithValue("@tel", data.tel);
                cmd.Parameters.AddWithValue("@mobile", data.mobile);
                cmd.Parameters.AddWithValue("@email", data.email);
                cmd.Parameters.AddWithValue("@alert_email", data.alert_email);
                cmd.Parameters.AddWithValue("@alert_line", data.alert_line);
                cmd.Parameters.AddWithValue("@create_by", data.create_by);
                cmd.Parameters.AddWithValue("@create_date", data.create_date);

  

                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                long id = cmd.LastInsertedId; 
                while (reader.Read())
                {
                }
                response = id.ToString();
                conn.Close();
            }
   
                 return response;
        }

        private string InsertFactoryCEMInstall(FactoryCEMInstallModel data)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO factory_CEM_install (factory_form_id,no,production_name,chimney_name,chimney_type,install_eia,install_announce,install_disposed,action_installed,action_not_install, create_by, create_date)                 
                VALUES (@factory_form_id,@no,@production_name,@chimney_name,@chimney_type,@install_eia,@install_announce,@install_disposed,@action_installed,@action_not_install, @create_by, @create_date) ; SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                cmd.Parameters.AddWithValue("@no", data.no);
                cmd.Parameters.AddWithValue("@production_name", data.production_name);
                cmd.Parameters.AddWithValue("@chimney_name", data.chimney_name);
                cmd.Parameters.AddWithValue("@chimney_type", data.chimney_type);
                cmd.Parameters.AddWithValue("@install_eia", data.install_eia);
                cmd.Parameters.AddWithValue("@install_announce", data.install_announce);
                cmd.Parameters.AddWithValue("@install_disposed", data.install_disposed);
                cmd.Parameters.AddWithValue("@action_installed", data.action_installed);
                cmd.Parameters.AddWithValue("@action_not_install", data.action_not_install);
                cmd.Parameters.AddWithValue("@create_by", data.create_by);
                cmd.Parameters.AddWithValue("@create_date", data.create_date);

  

                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                long id = cmd.LastInsertedId; 
                while (reader.Read())
                {
                }
                response = id.ToString();
                conn.Close();
            }
   
                 return response;
        }
        
        private string InsertFactoruMeasure(FactoruMeasureModel data)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO factory_measure (factory_form_id,no,parameter,unit,eia,chimney_name,chimney_width,chimney_height,channel_number,chimney_coordinates_x,chimney_coordinates_y, create_by, create_date,range2)                 
                VALUES (@factory_form_id,@no,@parameter,@unit,@eia,@chimney_name,@chimney_width,@chimney_height,@channel_number,@chimney_coordinates_x,@chimney_coordinates_y, @create_by, @create_date,@range2) ; SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                cmd.Parameters.AddWithValue("@no", data.no);
                cmd.Parameters.AddWithValue("@parameter", data.parameter);
                cmd.Parameters.AddWithValue("@unit", data.unit);
                cmd.Parameters.AddWithValue("@eia", data.eia);
                cmd.Parameters.AddWithValue("@chimney_name", data.chimney_name);
                cmd.Parameters.AddWithValue("@chimney_width", data.chimney_width);
                cmd.Parameters.AddWithValue("@chimney_height", data.chimney_height);
                cmd.Parameters.AddWithValue("@channel_number", data.channel_number);
                cmd.Parameters.AddWithValue("@chimney_coordinates_x", data.chimney_coordinates_x);
                cmd.Parameters.AddWithValue("@chimney_coordinates_y", data.chimney_coordinates_y);
                cmd.Parameters.AddWithValue("@create_by", data.create_by);
                cmd.Parameters.AddWithValue("@create_date", data.create_date);
                cmd.Parameters.AddWithValue("@range2", data.range2);
               // Console.WriteLine(cmd);

                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                long id = cmd.LastInsertedId; 
                while (reader.Read())
                {
                }
                response = id.ToString();
                conn.Close();
            }
   
                 return response;
        }
        





        [HttpPost("GetFactoryListViewData")]
        public  IActionResult GetFactoryListViewData([FromBody] FactoryFormModel.GetListData data)
        {
            IActionResult response = Unauthorized();
            FactoryFormModel.GetListData getData = new FactoryFormModel.GetListData();

            if (string.IsNullOrEmpty(data.factory_id.ToString()))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }
            getData.factory_id = data.factory_id;
            var GetFactoryForm_1 = GetFactoryForm(getData);
 

            if (GetFactoryForm_1 != null)
            {
                response = Ok(new { data = GetFactoryForm_1   });
            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }


        private List<FactoryFormModel.ListDataView> GetFactoryForm(FactoryFormModel.GetListData data)
        {
           FactoryFormModel.ListDataView data_ = null;

            List<FactoryFormModel.ListDataView> datalist = new List<FactoryFormModel.ListDataView>();
            Constants Constants = new Constants();
            string createDate ;
            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_form where factory_id = @factory_id ", conn);
                cmd.Parameters.AddWithValue("@factory_id", data.factory_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     if (!string.IsNullOrEmpty(reader["create_date"].ToString()))
                    {
                        createDate = reader["create_date"].ToString();
                    }
                    else
                    {
                        createDate = "ไม่พบข้อมูล";
                    }
    
                        data_ = new FactoryFormModel.ListDataView
                        {
                            factory_form_id= Convert.ToInt32(reader["factory_form_id"].ToString()) ,
                            factory_name = reader["factory_name"].ToString(),
                            factory_number = reader["factory_number"].ToString(),
                            factory_business = reader["factory_business"].ToString(),
                            factory_fuel_type = reader["factory_fuel_type"].ToString(),
                            factory_location_number = reader["factory_location_number"].ToString(),
                            factory_location_moo = reader["factory_location_moo"].ToString(),
                            factory_location_soi = reader["factory_location_soi"].ToString(),
                            factory_location_road = reader["factory_location_road"].ToString(),
                            factory_location_subdistrict = reader["factory_location_subdistrict"].ToString(),
                            factory_location_province = reader["factory_location_province"].ToString(),
                            factory_location_zipcode = reader["factory_location_zipcode"].ToString(),
                            factory_chimney_install = reader["factory_chimney_install"].ToString(),
                            factory_chimney_finish = reader["factory_chimney_finish"].ToString(),
                            IP = reader["IP"].ToString(),
                            DNS = reader["DNS"].ToString(),
                            FTP = reader["FTP"].ToString(),
                            port_number = reader["port_number"].ToString(),
                            logger_brand = reader["logger_brand"].ToString(),
                            logger_model = reader["logger_model"].ToString(),
                            logger_id = reader["logger_id"].ToString(),
                            factory_id = Convert.ToInt32(reader["factory_id"].ToString()) ,
                            create_by = reader["create_by"].ToString(),
                            factory_status = reader["factory_status"].ToString(),
                            create_date = createDate
                        };

                         datalist.Add(data_);

                    }
                }

                conn.Close();
            }



            return datalist;
        }

    




    

        [HttpPost("GetFactoryDetailViewData")]
        public  IActionResult GetFactoryDetailViewData([FromBody] FactoryFormModel.GetListData data)
        {
            IActionResult response = Unauthorized();

            if (string.IsNullOrEmpty(data.factory_form_id.ToString()))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }
            
            FactoryFormModel.GetListData getDataFactoryForm = new FactoryFormModel.GetListData();
            getDataFactoryForm.factory_form_id = data.factory_form_id;
            var getFactoryForm = GetFactoryFormByFormId(getDataFactoryForm);
 


            FactoryCoordinatorModel.GetListData getDataCoordinator = new FactoryCoordinatorModel.GetListData();
            getDataCoordinator.factory_form_id = data.factory_form_id;
            var getFactoryCoordinator = GetFactoryCoordinatorByFormId(getDataCoordinator);


            FactoruMeasureModel.GetListData getDataFactoruMeasure = new FactoruMeasureModel.GetListData();
            getDataFactoruMeasure.factory_form_id = data.factory_form_id;
            var getFactoruMeasure = GetFactoruMeasureByFormId(getDataFactoruMeasure);



        
            FactoryCEMInstallModel.GetListData getDataFactoryCEMInstall= new FactoryCEMInstallModel.GetListData();
            getDataFactoryCEMInstall.factory_form_id = data.factory_form_id;
            var getFactoryCEMInstall = GetFactoryCEMInstallByFormId(getDataFactoryCEMInstall);

            if (getFactoryForm != null)
            {
                response = Ok(new { FactoryForm  = getFactoryForm  , FactoryCEMInstall = getFactoryCEMInstall   , FactoruMeasure = getFactoruMeasure  , FactoryCoordinator = getFactoryCoordinator       });
            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }



        private List<FactoryFormModel.ListDataView> GetFactoryFormByFormId(FactoryFormModel.GetListData data)
        {
           FactoryFormModel.ListDataView data_ = null;

            List<FactoryFormModel.ListDataView> datalist = new List<FactoryFormModel.ListDataView>();
            Constants Constants = new Constants();
            string createDate ;
            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_form where factory_form_id = @factory_form_id ", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     if (!string.IsNullOrEmpty(reader["create_date"].ToString()))
                    {
                        createDate = reader["create_date"].ToString();
                    }
                    else
                    {
                        createDate = "ไม่พบข้อมูล";
                    }
    
                        data_ = new FactoryFormModel.ListDataView
                        {
                            factory_form_id= Convert.ToInt32(reader["factory_form_id"].ToString()) ,
                            factory_name = reader["factory_name"].ToString(),
                            factory_number = reader["factory_number"].ToString(),
                            factory_business = reader["factory_business"].ToString(),
                            factory_fuel_type = reader["factory_fuel_type"].ToString(),
                            factory_location_number = reader["factory_location_number"].ToString(),
                            factory_location_moo = reader["factory_location_moo"].ToString(),
                            factory_location_soi = reader["factory_location_soi"].ToString(),
                            factory_location_road = reader["factory_location_road"].ToString(),
                            factory_location_subdistrict = reader["factory_location_subdistrict"].ToString(),
                            factory_location_province = reader["factory_location_province"].ToString(),
                            factory_location_zipcode = reader["factory_location_zipcode"].ToString(),
                            factory_chimney_install = reader["factory_chimney_install"].ToString(),
                            factory_chimney_finish = reader["factory_chimney_finish"].ToString(),
                            IP = reader["IP"].ToString(),
                            DNS = reader["DNS"].ToString(),
                            FTP = reader["FTP"].ToString(),
                            port_number = reader["port_number"].ToString(),
                            logger_brand = reader["logger_brand"].ToString(),
                            logger_model = reader["logger_model"].ToString(),
                            logger_id = reader["logger_id"].ToString(),
                            factory_id = Convert.ToInt32(reader["factory_id"].ToString()) ,
                            create_by = reader["create_by"].ToString(),
                            factory_status = reader["factory_status"].ToString(),
                            create_date = createDate
                        };

                         datalist.Add(data_);

                    }
                }

                conn.Close();
            }



            return datalist;
        }



        private List<FactoryCoordinatorModel.ListDataView> GetFactoryCoordinatorByFormId(FactoryCoordinatorModel.GetListData data)
        {
           FactoryCoordinatorModel.ListDataView data_ = null;

            List<FactoryCoordinatorModel.ListDataView> datalist = new List<FactoryCoordinatorModel.ListDataView>();
            Constants Constants = new Constants();
            string createDate ;
            bool alertEmail ;
            bool alertLine ;
            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_coordinator where factory_form_id = @factory_form_id ", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     if (!string.IsNullOrEmpty(reader["create_date"].ToString()))
                    {
                        createDate = reader["create_date"].ToString();
                    }
                    else
                    {
                        createDate = "ไม่พบข้อมูล";
                    }

                    if (!string.IsNullOrEmpty(reader["alert_email"].ToString()))
                    {
                        if(reader["alert_email"].ToString().Equals("1"))
                        {
                         alertEmail = true;
                        }else
                        {
                         alertEmail = false;
                        }
                 
                    }
                    else
                    {
                        alertEmail = false;
                    }

                     if (!string.IsNullOrEmpty(reader["alert_line"].ToString()))
                    {
                        if(reader["alert_line"].ToString().Equals("1"))
                        {
                         alertLine = true;
                        }else
                        {
                         alertLine = false;
                        }

                    }
                    else
                    {
                        alertLine = false;
                    }
    
    

    
                        data_ = new FactoryCoordinatorModel.ListDataView
                        {
                            id  = Convert.ToInt32(reader["id"].ToString()) ,
                            factory_form_id  = Convert.ToInt32(reader["factory_form_id"].ToString()) ,
                            name = reader["name"].ToString(),
                            position = reader["position"].ToString(),
                            tel = reader["tel"].ToString(),
                            mobile = reader["mobile"].ToString(),     
                            email = reader["email"].ToString(),
                            alert_email = alertEmail,
                            alert_line = alertLine,          
                            create_by = reader["create_by"].ToString(),
                            create_date = createDate
                        };

                         datalist.Add(data_);

                    }
                }

                conn.Close();
            }



            return datalist;
        }

        private List<FactoruMeasureModel.ListDataView> GetFactoruMeasureByFormId(FactoruMeasureModel.GetListData data)
        {
           FactoruMeasureModel.ListDataView data_ = null;

            List<FactoruMeasureModel.ListDataView> datalist = new List<FactoruMeasureModel.ListDataView>();
            Constants Constants = new Constants();
            string createDate ;
            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_measure where factory_form_id = @factory_form_id ", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     if (!string.IsNullOrEmpty(reader["create_date"].ToString()))
                    {
                        createDate = reader["create_date"].ToString();
                    }
                    else
                    {
                        createDate = "ไม่พบข้อมูล";
                    }

            
                        data_ = new FactoruMeasureModel.ListDataView
                        {
                            id  = Convert.ToInt32(reader["id"].ToString()) ,
                            factory_form_id  = Convert.ToInt32(reader["factory_form_id"].ToString()) ,
                            no  = Convert.ToInt32(reader["no"].ToString()) ,
                            parameter = reader["parameter"].ToString(),
                            unit = reader["unit"].ToString(),     
                            range2 = reader["range2"].ToString(),
                            eia = reader["eia"].ToString(),
                            chimney_name = reader["chimney_name"].ToString(),       
                            chimney_width = reader["chimney_width"].ToString(),
                            chimney_height = reader["chimney_height"].ToString(),
                            channel_number = reader["channel_number"].ToString(),       
                            chimney_coordinates_x = reader["chimney_coordinates_x"].ToString(),
                            chimney_coordinates_y = reader["chimney_coordinates_y"].ToString(),  
                            create_by = reader["create_by"].ToString(),
                            create_date = createDate
                        };

                         datalist.Add(data_);

                    }
                }

                conn.Close();
            }



            return datalist;
        }

           private List<FactoryCEMInstallModel.ListDataView> GetFactoryCEMInstallByFormId(FactoryCEMInstallModel.GetListData data)
        {
           FactoryCEMInstallModel.ListDataView data_ = null;

            List<FactoryCEMInstallModel.ListDataView> datalist = new List<FactoryCEMInstallModel.ListDataView>();
            Constants Constants = new Constants();
            string createDate ;
            bool actionInstalled ;
            bool actionNotInstall ;
            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_CEM_install where factory_form_id = @factory_form_id ", conn);
                cmd.Parameters.AddWithValue("@factory_form_id", data.factory_form_id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                     if (!string.IsNullOrEmpty(reader["create_date"].ToString()))
                    {
                        createDate = reader["create_date"].ToString();
                    }
                    else
                    {
                        createDate = "ไม่พบข้อมูล";
                    }

                    if (!string.IsNullOrEmpty(reader["action_installed"].ToString()))
                    {
                        if(reader["action_installed"].ToString().Equals("1"))
                        {
                         actionInstalled = true;
                        }else
                        {
                         actionInstalled = false;
                        }
                 
                    }
                    else
                    {
                        actionInstalled = false;
                    }

                    
                    if (!string.IsNullOrEmpty(reader["action_not_install"].ToString()))
                    {
                        if(reader["action_not_install"].ToString().Equals("1"))
                        {
                         actionNotInstall = true;
                        }else
                        {
                         actionNotInstall = false;
                        }
                 
                    }
                    else
                    {
                        actionNotInstall = false;
                    }

            
                        data_ = new FactoryCEMInstallModel.ListDataView
                        {
                            id  = Convert.ToInt32(reader["id"].ToString()) ,
                            factory_form_id  = Convert.ToInt32(reader["factory_form_id"].ToString()) ,
                            no  = Convert.ToInt32(reader["no"].ToString()) ,
                            production_name = reader["production_name"].ToString(),
                            chimney_name = reader["chimney_name"].ToString(),     
                            chimney_type = reader["chimney_type"].ToString(),
                            install_eia = reader["install_eia"].ToString(),
                            install_announce = reader["install_announce"].ToString(),     
                            install_disposed= reader["install_disposed"].ToString(),
                            action_installed = actionInstalled,
                            action_not_install = actionNotInstall,       
                            create_by = reader["create_by"].ToString(),
                            create_date = createDate
                        };

                         datalist.Add(data_);

                    }
                }

                conn.Close();
            }



            return datalist;
        }




        [HttpPost("UpdateFactoryFormApprove")]
        public IActionResult UpdateFactoryFormApprove([FromBody] FactoryFormModel.UpdateData data)
        {
            IActionResult response = Unauthorized();
            FactoryUserModel insertData = new FactoryUserModel();

            if (string.IsNullOrEmpty(data.factory_form_id.ToString()))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }

            FactoryFormModel updateData = new FactoryFormModel();
            Constants Constants = new Constants();
            updateData.factory_form_id = data.factory_form_id;
            updateData.factory_status = Constants.FactoryStatus.approved;

 

            var FactoryUpdate = UpdateFactorySql(updateData);

            if (FactoryUpdate != null)
            {
                response = Ok(new { status = "s" });

            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }

      

    
        private string UpdateFactorySql(FactoryFormModel Data)
        {
            string response = "";

           Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"UPDATE  factory_form SET  factory_status = @factory_status              
                WHERE factory_form_id = @factory_form_id ", conn);
                cmd.Parameters.AddWithValue("@factory_status", Data.factory_status);
                cmd.Parameters.AddWithValue("@factory_form_id", Data.factory_form_id);



                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (reader.Read())
                {

                }

                response = "s";
                conn.Close();
            }

            return response;
        }




    }
    

}