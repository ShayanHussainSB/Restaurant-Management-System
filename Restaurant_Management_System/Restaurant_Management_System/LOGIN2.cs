using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Restaurant_Management_System
{
    class LOGIN2
    {
        public static string id;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Restaurant_Management_System;Integrated Security=True");
        public int newpass { get; set; }
        public string pass { get; set; }
        public string email { get; set; }

        public LOGIN2(string em, string ps)
        {
            email = em;
            pass = ps;
        }

        public LOGIN2(string ps, int newps)
        {
            pass = ps;
            newpass = newps;
        }
        public string chklogin()
        {
            SqlCommand com = new SqlCommand("Select * from Employee_signup", con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr[2].ToString() == email)
                    {
                        if (dr[4].ToString() == pass)
                        {
                            if (dr[6].ToString() == "Admin")
                            {
                                id = dr[0].ToString();
                                con.Close();
                                return "successfull";
                            }
                            else if (dr[6].ToString() == "User")
                            {
                                con.Close();
                                return "successfull2";
                            }
                            else if (dr[6].ToString() == "Owner")
                            {
                                con.Close();
                                return "successfull3";
                            }
                        }
                        else
                        {
                            con.Close();
                            return "PASSWORD INCORRECT";
                        }
                    }
                }
            }
            else
            {
                con.Close();
                return "EMAIL AND PASSWORD INCORRECT";
            }
            con.Close();
            return "";
        }
    }
}
