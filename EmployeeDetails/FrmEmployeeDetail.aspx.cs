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
        public static int emp_id_check;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (shared.Employee_id != 0)
                {

                    Emp_Details_Retrive(shared.Employee_id);

                }
            }
          
            Label9.Visible = false;
           
        }

        protected void Insert_Data(object sender, EventArgs e)
        {
           int eid= shared.emp_id(TextBox1.Text);
           //insertion
            if(eid==0)
            {
                Page.Validate();
                if (Page.IsValid == true)
                {
                    Insert();
                }
                else
                {
                    Label9.Visible = true;
                    Label9.Text = "Please Enter Valid data.";
                }
            }
          //updation
            else 
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

                SqlCommand cmd3 = new SqlCommand("update Employee set First_Name = @First_Name , Last_Name = @Last_Name , Department = @Department , Contact_No = @Contact_No , Email = @Email , StateName = @StateName, CityName = @CityName where EmployeeID = " + shared.Employee_id, sc);

                cmd3.Parameters.AddWithValue("First_Name", First_name);
                cmd3.Parameters.AddWithValue("Last_Name", Last_name);
                cmd3.Parameters.AddWithValue("Department", Department);
                cmd3.Parameters.AddWithValue("Contact_No", Contact_No);
                cmd3.Parameters.AddWithValue("Email", Email);
                cmd3.Parameters.AddWithValue("StateName", State);
                cmd3.Parameters.AddWithValue("CityName", City);
                int success = cmd3.ExecuteNonQuery();
                if (success == 1)
                {
                    Label9.Visible = true;
                    Label9.Text = "Employee Data Updated";
                    sc.Close();
                }
            }
            
        }

        
        private void Insert()
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

            SqlCommand cmd3 = new SqlCommand("insert into Employee (First_Name,Last_Name,Department,Contact_No,Email ,StateName ,CityName) values (@First_Name,@Last_Name,@Department,@Contact_No,@Email ,@StateName ,@CityName)", sc);
            cmd3.Parameters.AddWithValue("First_Name", First_name);
            cmd3.Parameters.AddWithValue("Last_Name", Last_name);
            cmd3.Parameters.AddWithValue("Department", Department);
            cmd3.Parameters.AddWithValue("Contact_No", Contact_No);
            cmd3.Parameters.AddWithValue("Email", Email);
            cmd3.Parameters.AddWithValue("StateName", State);
            cmd3.Parameters.AddWithValue("CityName", City);
            int success = cmd3.ExecuteNonQuery();
            if (success == 1)
            {
                Label9.Visible = true;
                Label9.Text = "Employee Data Added";
                sc.Close();
            }
        }

        private void Emp_Details_Retrive(int empid)
        {

            var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("select * from Employee where EmployeeID=" + empid, sc);


            try
            {
                sc.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        TextBox1.Text = (read["First_Name"].ToString());
                        TextBox2.Text = (read["Last_Name"].ToString());
                        DropDownList1.Text = (read["Department"].ToString());
                        TextBox3.Text = (read["Contact_No"].ToString());
                        TextBox4.Text = (read["Email"].ToString());
                        DropDownList2.Text = (read["StateName"].ToString());
                        DropDownList3.Items.Insert(0,new ListItem(read["CityName"].ToString(),"0"));//listread["CityName"].ToString());

                    }
                }
            }
            finally
            {
                sc.Close();
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {


            City_Bind();
            


        }

       private void City_Bind()
        {
            DropDownList3.Items.Clear();
           
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
       
    }
     
}