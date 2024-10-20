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
using BC = BCrypt.Net.BCrypt;
using SbAdmin.Models; 


namespace SbAdmin.Controllers
{
    //  [Route("api/[controller]")]
    [ApiController]
    [Route("FactoryUserController")]
    public class FactoryUserController : ControllerBase
    {
        public FactoryUserController()
        {
        }

   
        [HttpPost("insertUser")]
        public IActionResult InsertUserAsync([FromBody] FactoryUserModel.Register user)
        {
            IActionResult response = Unauthorized();
            FactoryUserModel insertData = new FactoryUserModel();

            if (string.IsNullOrEmpty(user.factory_email) && string.IsNullOrEmpty(user.factory_password))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }

            FactoryUserModel Data = new FactoryUserModel();
            Data.factory_email = user.factory_email;

            var checkUser = CheckUser(Data);


            if (checkUser != null)
            {
                response = Ok(new { status = "already have username" });
                return response;
            }

            string passwordHash = BC.HashPassword(user.factory_password);


          //  string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.factory_password.Trim());
           Constants Constants = new Constants();

            insertData.factory_name = user.factory_name;
            insertData.factory_password = passwordHash;
            insertData.factory_number = user.factory_number;
            insertData.factory_email = user.factory_email;
            insertData.factory_tele = user.factory_tele;
            insertData.create_by = user.factory_email;
            insertData.create_date = DateTime.Now;
            insertData.factory_active = Constants.Status.active;
            insertData.factory_role = Constants.Role.user;

            var user2 = InsertUserSql(insertData);

            if (user2 != null)
            {
                response = Ok(new { status = "s" });

            }
            else
            {
                response = Ok(new { status = "f" });
            }

            return response;
        }

        private object CheckUser(FactoryUserModel data)
        {
            FactoryUserModel user = null;

            List<FactoryUserModel> list = new List<FactoryUserModel>();

            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_user where factory_email = @factory_email ", conn);
                cmd.Parameters.AddWithValue("@factory_email", data.factory_email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        user = new FactoryUserModel
                        {
                            factory_name = reader["factory_name"].ToString() ,
                            factory_email = reader["factory_email"].ToString() 
                        };

                    }
                }

                conn.Close();
            }



            return user;
        }

    
        private string InsertUserSql(FactoryUserModel insertData)
        {
            string response = "";

           Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO factory_user (factory_name ,factory_password ,factory_number  , factory_email , factory_tele, create_by, create_date, factory_active , factory_role)                 
                VALUES (@factory_name ,@factory_password ,@factory_number  , @factory_email , @factory_tele, @create_by, @create_date, @factory_active ,  @factory_role)", conn);
                cmd.Parameters.AddWithValue("@factory_name", insertData.factory_name);
                cmd.Parameters.AddWithValue("@factory_password", insertData.factory_password);
                cmd.Parameters.AddWithValue("@factory_number", insertData.factory_number);
                cmd.Parameters.AddWithValue("@factory_email", insertData.factory_email);
                cmd.Parameters.AddWithValue("@factory_tele", insertData.factory_tele);
                cmd.Parameters.AddWithValue("@create_by", insertData.create_by);
                cmd.Parameters.AddWithValue("@create_date", insertData.create_date);
                cmd.Parameters.AddWithValue("@factory_active", insertData.factory_active);
                cmd.Parameters.AddWithValue("@factory_role", insertData.factory_role);



                var reader = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (reader.Read())
                {
                }

                response = "s";
                conn.Close();
            }

            return response;
        }



        [HttpPost("Login")]
        public IActionResult Login([FromBody] FactoryUserModel.Login login)
        {
            IActionResult response = Unauthorized();

            var user2 = AuthenticateUser(login);
            Console.WriteLine(user2);
            if (user2 != null)
            {
                Console.WriteLine(user2.factory_password);

                if (user2 == null || !BC.Verify(login.factory_password,user2.factory_password))
                {
                    // authentication failed
                    response = Ok(new { token = "worng password" });
                }
                else
                {
                    var tokenString = GenerateJSONWebToken(user2);
                    //get refreshtoken
                    var refreshtokenString = GenerateJSONWebToken(user2);
                    response = Ok(new { token = tokenString, refreshtoken = refreshtokenString });
                }


            }
            else
            {
                response = Ok(new { token = "user not found" });
            }
            //response = Ok(new { token = user });
            return response;
        }

        private string GenerateJSONWebToken(FactoryUserModel userInfo)
        {
            var _secret = "PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f";
            var _expDate = "1440";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("factory_tele", userInfo.factory_tele) ,
                    new Claim("factory_name", userInfo.factory_name) ,
                    new Claim("factory_number", userInfo.factory_number) ,
                    new Claim("factory_email", userInfo.factory_email) ,
                    new Claim("factory_id", userInfo.factory_id.ToString()) ,
                    new Claim("factory_active", userInfo.factory_active) ,
                    new Claim("factory_role", userInfo.factory_role) ,
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        private FactoryUserModel AuthenticateUser(FactoryUserModel.Login login)
        {
            FactoryUserModel user = null;

            List<FactoryUserModel> list = new List<FactoryUserModel>();

            Constants Constants = new Constants();

            using (MySqlConnection conn = Constants.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from factory_user where factory_email = @factory_email ", conn);
                cmd.Parameters.AddWithValue("@factory_email", login.factory_email);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
     
                        user = new FactoryUserModel
                        {
                            factory_id = Convert.ToInt32(reader["factory_id"]) ,
                            factory_name = reader["factory_name"].ToString() ,
                            factory_password = reader["factory_password"].ToString() ,
                            factory_number = reader["factory_number"].ToString() ,
                            factory_email = reader["factory_email"].ToString() ,
                            factory_tele = reader["factory_tele"].ToString() ,
                            factory_active = reader["factory_active"].ToString() ,
                            factory_role = reader["factory_role"].ToString() 
                        };

                    }
                }

                conn.Close();
            }

 
            return user;
        }


    
        


        
    

    }
    

}