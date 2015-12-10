using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeDetails
{
    public partial class FrmEmployeeDetail : System.Web.UI.Page
    {
        public static string First_name;
        public static string Last_name;
        public static string Department ;
        public static string Contact_No;
        public static string Email;
        public static string State;
        public static string City;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label9.Visible = false;
            var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(connectionstring);
            
            
            using(SqlCommand cmd = new SqlCommand("Select DepartmentName from Department",sc))
            {
               
                sc.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                DropDownList1.Items.Add(reader[0].ToString());
                }

                sc.Close();
            }
            using (SqlCommand cmd1 = new SqlCommand("Select StateName from State", sc))
            {
               
                sc.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while(reader1.Read())
                {
                    DropDownList2.Items.Add(reader1[0].ToString());
                }
                sc.Close();
            }


        }

        

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand("Select CityName from City where StateId in (select StateId from State where StateName='" + DropDownList2.SelectedValue + "')", sc);
            
               
                sc.Open();
                
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    DropDownList3.Items.Add(reader2[0].ToString());
                }
                sc.Close();
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

           Page.Validate();
           if (Page.IsValid == true)
           {
                First_name = TextBox1.Text;
                Last_name = TextBox2.Text;
                Department = DropDownList1.SelectedItem.ToString();
                Contact_No = TextBox3.Text;
                Email = TextBox4.Text;
                State = DropDownList2.SelectedItem.ToString();
                City = DropDownList3.SelectedItem.ToString();
                var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
                SqlConnection sc = new SqlConnection(connectionstring);
                sc.Open();
                SqlCommand cmd3 = new SqlCommand("insert into Employee (First_Name,Last_Name,Department,Contact_No,Email ,State ,City) values (@First_Name,@Last_Name,@Department,@Contact_No,@Email ,@State ,@City)", sc);
                cmd3.Parameters.AddWithValue("First_Name", First_name);
                cmd3.Parameters.AddWithValue("Last_Name", Last_name);
                cmd3.Parameters.AddWithValue("Department", Department);
                cmd3.Parameters.AddWithValue("Contact_No", Contact_No);
                cmd3.Parameters.AddWithValue("Email", Email);
                cmd3.Parameters.AddWithValue("State", State);
                cmd3.Parameters.AddWithValue("City", City);
                int success = cmd3.ExecuteNonQuery();
               if(success==1)
               {
                   Label9.Visible = true;
                   Label9.Text = "Employee Data Added";
               }
            
           }
            else
           {
               Label9.Visible = true;
                Label9.Text = "Please Enter Valid data.";
            }
                





        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}