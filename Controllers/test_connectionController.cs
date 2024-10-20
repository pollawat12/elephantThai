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
    [Route("test_connectionController")]
    public class test_connectionController : ControllerBase
    {
        public test_connectionController()
        {
        }

      
        [HttpPost("xx")]
        public  IActionResult InsertAccessLog([FromBody] test_connectionModels data)
        {
              IActionResult response = Unauthorized();
            test_connectionModels insertData = new test_connectionModels();

            Console.WriteLine(data.arry1.Count());
            if (string.IsNullOrEmpty(data.detail1.ToString()) || string.IsNullOrEmpty(data.detail2.ToString()))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }

            insertData.detail1 = "xxx1";
            insertData.detail2 = "xxx2";

            var logAccessModel =  insert(insertData);
        
            Console.WriteLine(logAccessModel);
            foreach(var item in data.arry1 )
            {
             test2 insertData2 = new test2();
             insertData2.t1 = logAccessModel;
             insertData2.t2 = item.BannerData1;
             insertData2.t3 = item.BannerData1;
             var insertData_2 =  InsertTest2(insertData2);
             Console.WriteLine(item.BannerData1);
            }

            if (logAccessModel != null)
            {
                response = Ok(new { status = "s" });
            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }

        private string insert(test_connectionModels logAccess)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO test_connection (detail1, detail2)                 
                VALUES (@detail1, @detail2) ; SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@detail1", logAccess.detail1);
                cmd.Parameters.AddWithValue("@detail2", logAccess.detail2);

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


         private string InsertTest2(test2 data)
        {
            string response = "";
            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO test2 (t1,t2,t3)                 
                VALUES (@t1,@t2,@t3) ; SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@t1", data.t1);
                cmd.Parameters.AddWithValue("@t2", data.t2);
                cmd.Parameters.AddWithValue("@t3", data.t3);

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



    
        


        
    

    }
    

}