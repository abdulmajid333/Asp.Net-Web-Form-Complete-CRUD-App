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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con =  new SqlConnection("data source = LAPTOP-J1EB5BI8;initial catalog = mycompany; integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txtnp.Text == txtcnp.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_changepassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CHANGEPASSWORD");
                cmd.Parameters.AddWithValue("@rid", Session["rrid"]);
                cmd.Parameters.AddWithValue("@oldpassword", txtop.Text);
                cmd.Parameters.AddWithValue("@newpassword" , txtnp.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    lblmsg.Text = "Your Password Has Been Change Successfully !!";
                }
                else
                {
                    lblmsg.Text = "Your Password Has Not Been Change Successfully !!";
                }
            }
            else
            {
                lblmsg.Text = "Password Do Nopt Match";
            }
        }
    }
}