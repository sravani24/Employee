using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    public partial class FrmEmployees : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
            if (!IsPostBack)
            { 
                BindGrid();
            }

            Label2.Visible = false;
            
            
        }
        public void BindGrid()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT [First_Name] AS First_Name, [Email], [CityName] AS City, [Contact_No] AS Contact_No FROM [Employee]", sc);
            sc.Open();
           SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(dr);
             GridView1.DataSource = dt;
             GridView1.DataBind();
             sc.Close();

        }
        protected void Add_Employee(object sender, EventArgs e)
        {
            Response.Redirect("FrmEmployeeDetail.aspx");
        }
        protected void Delete_Employee(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (GridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //finding checkbox in GridView
                        CheckBox cbx = (CheckBox)GridView1.Rows[i].FindControl("cbSelect");
                        //CheckBox not null
                        if (cbx != null)
                        {
                            //if CheckBox Checked
                            if (cbx.Checked)
                            {

                                string First_Name = GridView1.Rows[i].Cells[1].Text;

                                var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
                                SqlConnection sc = new SqlConnection(connectionstring);
                                int emid = shared.emp_id(First_Name);
                                SqlCommand cmd = new SqlCommand("Delete from Employee where EmployeeID='" + emid + "'", sc);
                                sc.Open();
                                cmd.ExecuteNonQuery();
                                sc.Close();

                            }
                        }
                    }
                }



            }
            BindGrid();
        }

        protected void Update_Employee(object sender, EventArgs e)
        {
            int count = 0;
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                CheckBox chkId = (row.FindControl("cbSelect") as CheckBox);
                if (chkId.Checked)
                {
                    count++;
                    shared.first_Name = row.Cells[1].Text;
                }

            }
            if (count == 1)
            {
                shared.Employee_id=shared.emp_id(shared.first_Name);
                Response.Redirect("FrmEmployeeDetail.aspx");
            }
            else
            {
                Label2.Text = "Select Only one row";
                Label2.Visible = true;
                
            }
        }
        
    }
    public static class shared
    {
        public static int Employee_id=0;
        public static string first_Name = "NS";
       
        public static int emp_id(string name)
        { 
            var connectionstring = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
            SqlConnection sc = new SqlConnection(connectionstring);
            sc.Open();
            SqlCommand cmd = new SqlCommand("select EmployeeID from Employee where First_Name='" + name + "'", sc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee_id = (Int32.Parse(dr["EmployeeID"].ToString()));
            }
            sc.Close();
            return Employee_id;
           
        }
       
    }
}
            
        

       
    
