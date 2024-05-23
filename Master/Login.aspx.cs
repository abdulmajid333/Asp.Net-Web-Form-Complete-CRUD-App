using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Master
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source = LAPTOP-J1EB5BI8;initial catalog = mycompany; integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login" , con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "CHECKDETAIL");
            cmd.Parameters.AddWithValue("@email" , txtuid.Text);
            cmd.Parameters.AddWithValue("@password" , txtupassword.Text);   
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if(dt.Rows.Count > 0)
            {
                Session["op"] = dt.Rows[0]["password"];
                Session["rrid"] = dt.Rows[0]["rid"];
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblmsg.Text = "Login Failed !!";
            }
        }
    }
}