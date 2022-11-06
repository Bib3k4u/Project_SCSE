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
                    getprogramlist();
                   // getcollegecode();
                }
                catch (Exception ex)
                {

                }

            }

        }
       

        protected void grdprogramlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                pnlError.Visible = false;
                string programid;
                using (SqlCommand cmd = new SqlCommand("Del_Program_Master"))
                {

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    programid = ((sender as LinkButton).CommandArgument).ToString();

                    cmd.Parameters.AddWithValue("@programid", programid);
                    con.Open();
                    int k = cmd.ExecuteNonQuery();
                    getprogramlist();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        private void getprogramlist()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Get_Program_Master"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grdprogramlist.DataSource = dt;
                            grdprogramlist.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
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
                        getprogramlist();
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

        protected void grdprogramlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdprogramlist.EditIndex = e.NewEditIndex;
            getprogramlist();
            pnlError.Visible = false;

            grdprogramlist.Rows[e.NewEditIndex].Attributes.Remove("ondblclick");
            TextBox txtprogramcode = grdprogramlist.Rows[e.NewEditIndex].FindControl("txtprogramcode") as TextBox;


            hidden1.Value = txtprogramcode.Text;
        }

        protected void grdprogramlist_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void grdprogramlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                TextBox txtprogramcode = grdprogramlist.Rows[e.RowIndex].FindControl("txtprogramcode") as TextBox;

                TextBox txtprogramname = grdprogramlist.Rows[e.RowIndex].FindControl("txtprogramname") as TextBox;

                TextBox txtspecialization = grdprogramlist.Rows[e.RowIndex].FindControl("txtspecialization") as TextBox;
                TextBox txtyear = grdprogramlist.Rows[e.RowIndex].FindControl("txtyear") as TextBox;


                TextBox txtsemester = grdprogramlist.Rows[e.RowIndex].FindControl("txtsemester") as TextBox;

                pnlError.Visible = false;

                using (SqlCommand cmd = new SqlCommand("Update_Program_Master"))
                {


                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@programid", txtprogramcode.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("@programname", txtprogramname.Text.Trim());
                    cmd.Parameters.AddWithValue("@specialization", txtspecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt64(txtyear.Text.Trim()));
                    
                    cmd.Parameters.AddWithValue("@semester", Convert.ToInt64(txtsemester.Text.Trim()));
                    

                    con.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        grdprogramlist.EditIndex = -1;
                        ShowMsg(msg: "Program  Saved Successfully!", css: "alert alert-success");
                        getprogramlist();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "HideLabel();", true);

                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

        protected void grdprogramlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdprogramlist.EditIndex = -1;
            pnlError.Visible = false;
            getprogramlist();

        }

        protected void grdprogramlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdprogramlist.PageIndex = e.NewPageIndex;
            pnlError.Visible = false;
            getprogramlist();

        }

        protected void grdprogramlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        
      

       

        

    }
}