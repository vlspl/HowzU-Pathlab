using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDetails : System.Web.UI.Page
{
    string OrgId;
    userCreationDal objdal=new userCreationDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        OrgId = (Session["OrgId"].ToString());
        if (!IsPostBack)
          BindGrid();
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_BindUserDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId", OrgId);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    GridUser.DataSource = dt;
                    GridUser.DataBind();

                }
            }
        }
    }

    protected void GridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridUser.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        int id = Convert.ToInt32(GridUser.DataKeys[e.RowIndex].Value.ToString());
        objdal.DeleteUserDetails(id);
        BindGrid();

    }
    protected void GridUser_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridUser.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridUser.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                }
            }
        }
    }
}