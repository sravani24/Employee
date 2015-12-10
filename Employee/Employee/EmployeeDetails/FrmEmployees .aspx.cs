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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmEmployeeDetail.aspx");
         
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmEmployeeDetail.aspx");
        }

       
    }
}