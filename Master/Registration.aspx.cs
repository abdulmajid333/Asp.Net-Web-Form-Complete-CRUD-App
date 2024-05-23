using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace Master
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source = MAJID-333;initial catalog = mycompany; integrated security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Display();
                BindCountry();
                BindDepartment();
            }
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblreg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action" , "GET");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvreg.DataSource = dt;
            gvreg.DataBind();
        }

        public void BindDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblreg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETDEPARTMENT");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddldept.DataValueField = "did";
            ddldept.DataTextField = "dname";
            ddldept.DataSource = dt;
            ddldept.DataBind();
            ddldept.Items.Insert(0, new ListItem("--Select", "0"));
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblreg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETCOUNTRY");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlcy.DataValueField = "cid";
            ddlcy.DataTextField = "cname";
            ddlcy.DataSource = dt;
            ddlcy.DataBind();
            ddlcy.Items.Insert(0, new ListItem("--Select", "0"));
        }

        public void Clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            rblgender.ClearSelection();
            btnregister.Text = "Register";
            cblh.ClearSelection();
            ddlcy.SelectedValue = "0";
            ddldept.SelectedValue = "0";
        }

       
        protected void btnr_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("sp_tblreg", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@action", "CHECKEMAIL");
            cmd1.Parameters.AddWithValue("@email", txtemail.Text);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            con.Close();
            if (dt1.Rows.Count > 0)
            {
                lblmsg.Text = "This email already exist";
                lblmsg.ForeColor = Color.Red;
            }
            else
            {

                if (btnregister.Text == "Register")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_tblreg", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "INSERT");
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@department", ddldept.SelectedValue);
                    cmd.Parameters.AddWithValue("@country", ddlcy.SelectedValue);


                    /*
                     * 
                     *  type one for check checkboxlist 
                     *  tick or not
                    //string kk = "";
                    //if (cblh.Items[0].Selected==true)
                    {
                        kk += cblh.Items[0].Text;
                    }
                    if (cblh.Items[1].Selected == true)
                    {
                        kk += cblh.Items[1].Text;
                    }
                    if (cblh.Items[2].Selected == true)
                    {
                        kk += cblh.Items[2].Text;
                    }
                    if (cblh.Items[3].Selected == true)
                    {
                        kk += cblh.Items[3].Text;
                    }
                    if (cblh.Items[4].Selected == true)
                    {
                        kk += cblh.Items[4].Text;
                    }
                    if (cblh.Items[5].Selected == true)
                    {
                        kk += cblh.Items[5].Text;
                    }

                    */


                    // type two check checkbox list


                    string kk = "";
                    for(int j=0; j < 6; j++)
                    {
                        if (cblh.Items[j].Selected == true)
                        {
                            kk += cblh.Items[j].Text + ",";
                        }
                    }

                    //trimend last se , hatane kai liye use hota hai

                    kk = kk.TrimEnd(',');

                    cmd.Parameters.AddWithValue("@hobbies", kk );

                    // Image insert

                    string fn = Path.GetFileName(fuimage.PostedFile.FileName);
                    fuimage.SaveAs(Server.MapPath("userpics" + "\\" + fn));
                    cmd.Parameters.AddWithValue("@image", fn);

                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    Clear();
                    if(i > 0)
                    {
                        lblmsg.Text = "Record register successfully";
                        lblmsg.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblmsg.Text = "Record not register";
                        lblmsg.ForeColor = Color.Red;
                    }
                    

                }
                else if (btnregister.Text == "Update")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_tblreg", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "UPDATE");
                    cmd.Parameters.AddWithValue("@rid", ViewState["idd"]);
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@department", ddldept.SelectedValue);
                    cmd.Parameters.AddWithValue("@country", ddlcy.SelectedValue);

                    string kk = "";
                    if (cblh.Items[0].Selected == true)
                    {
                        kk += cblh.Items[0].Text + ",";
                    }
                    if (cblh.Items[1].Selected == true)
                    {
                        kk += cblh.Items[1].Text + ",";
                    }
                    if (cblh.Items[2].Selected == true)
                    {
                        kk += cblh.Items[2].Text + ",";
                    }
                    if (cblh.Items[3].Selected == true)
                    {
                        kk += cblh.Items[3].Text + ",";
                    }
                    if (cblh.Items[4].Selected == true)
                    {
                        kk += cblh.Items[4].Text + ",";
                    }
                    if (cblh.Items[5].Selected == true)
                    {
                        kk += cblh.Items[5].Text + ",";
                    }

                    kk = kk.TrimEnd(',');

                    cmd.Parameters.AddWithValue("@hobbies", kk );
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    Clear();
                    if (i > 0)
                    {
                        lblmsg.Text = "Record update successfully";
                        lblmsg.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblmsg.Text = "Record not update";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
        }

        protected void gvreg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblreg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@rid", e.CommandArgument);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Display();
                if (i > 0)
                {
                    lblmsg.Text = "Record delete successfully";
                    lblmsg.ForeColor = Color.Green;
                }
                else
                {
                    lblmsg.Text = "Record not delete";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            else if(e.CommandName=="B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblreg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "EDIT");
                cmd.Parameters.AddWithValue("@rid", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtpassword.Text = dt.Rows[0]["password"].ToString();
                ddldept.SelectedValue = dt.Rows[0]["department"].ToString();
                ddlcy.SelectedValue = dt.Rows[0]["country"].ToString();
                string[] arr = dt.Rows[0]["hobbies"].ToString().Split(',');

                cblh.ClearSelection();
                for(int j = 0 ; j < cblh.Items.Count ; j++)
                {
                    for(int k=0; k<arr.Length; k++)
                    {
                        if (cblh.Items[j].Text == arr[k])
                        {
                            cblh.Items[j].Selected = true;
                        }
                    }
                }

                btnregister.Text = "Update";
                ViewState["idd"] = e.CommandArgument;
            }
        }
    }
}