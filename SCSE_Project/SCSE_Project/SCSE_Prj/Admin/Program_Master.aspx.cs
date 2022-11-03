using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SCSE_Prj.Admin
{
    public partial class Program_Master : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter ad;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            if (!IsPostBack)
            {
                try
                {
                    pnlError.Visible = false;
                    //getprogramlist();
                   // getcollegecode();
                }
                catch (Exception ex)
                {

                }

            }

        }
        private void ShowMsg(string msg, string css)
        {
            if (string.IsNullOrEmpty(msg))
                lblError.Text = "Some Error Occurred!";
            else
                lblError.Text = msg;

            if (string.IsNullOrEmpty(css))
                css = "alert alert-danger margin-bottom-30";
            else
                pnlError.CssClass = css + " margin-bottom-30";

            pnlError.Visible = true;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("programinsert"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@programid", txtprogcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@programname", txtprogname.Text.Trim());
                    cmd.Parameters.AddWithValue("@specialization", txtbranch.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt64(txtyear.Text.Trim()));
                    cmd.Parameters.AddWithValue("@semester", Convert.ToInt64(txtsem.Text.Trim()));
                    con.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        ShowMsg(msg: "Program  Saved Successfully!", css: "alert alert-success");
                       // getprogramlist();
                        //clear();
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "HideLabel();", true);
                    }

                }
            }
            catch(Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }
}