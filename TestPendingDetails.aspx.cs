using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestCompletedDetails : System.Web.UI.Page
{
    string userNm, orgId, branchId;
    DBClass db = new DBClass();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        // orgId = (db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
        branchId = Session["BranchId"].ToString();
        orgId = Session["OrgId"].ToString();
     
            if (!this.IsPostBack)
            {

                this.BindGrid();

            }
        

    }
    private void BindGrid()
    {

       
            cmd = new SqlCommand("SP_TestPendingDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("orgId", this.orgId);
            cmd.Parameters.AddWithValue("parentbranchId", this.branchId);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridEmp.DataSource = dt;
            GridEmp.DataBind();

       

    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridEmp.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

}