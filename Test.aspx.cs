using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using CrossPlatformAESEncryption.Helper;

public partial class Test : System.Web.UI.Page
{
    DataTable dtFillData;
    TestDal objdal = new TestDal();
    TestBO objBranchBo = new TestBO();
    string userNm, orgId,branchId;
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        userNm = Session["userName"].ToString();
        branchId = Session["BranchId"].ToString();
        orgId = Session["OrgId"].ToString();
       // orgId = (db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());

        if (!IsPostBack)
        {
            BindGrid();
            
        }

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        insert();
        BindGrid();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        insert();

    }
    private void insert()
    {
        try
        {
            string Output = string.Empty;
            TestBO objTestBo = new TestBO();

            //objTestBo.testName = txtTestName.Text;
            //objTestBo.range = txtRange.Text;
            //objTestBo.status = drpStatus.Text;


            TestDal objdal = new TestDal();

            int j = objdal.AddTestDetails(objTestBo);


            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
            //txtTestName.Text =txtRange.Text= string.Empty;
            //drpStatus.Text = "--Select--";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_BindTestData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId", orgId);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridTest.DataSource = dt;
                        GridTest.DataBind();
                        GridTest.Columns[0].Visible = false;
                    }
                }
            }
        }
    }
    protected void GridTest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridTest.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        objdal.DeleteTesthDetails(Convert.ToInt32(GridTest.DataKeys[e.RowIndex].Value.ToString()));
        BindGrid();
       
    }
    protected void GridTest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridTest.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridTest_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        int userid = Convert.ToInt32(GridTest.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridTest.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");

        //TextBox textBranchName = (TextBox)row.Cells[2].Controls[0];
        //TextBox textStatus = (TextBox)row.Cells[3].Controls[0];
        string testName = (row.Cells[2].Controls[0] as TextBox).Text;
            string range = (row.Cells[3].Controls[0] as TextBox).Text;
        string Status = (row.Cells[4].Controls[0] as TextBox).Text;
        //objBranchBo.BranchName = textBranchName.Text;
        //objBranchBo.status = textStatus.Text;

        GridTest.EditIndex = -1;
        objdal.UpdateTestDetails(userid, testName, range, Status);

        BindGrid();
       
    }
    protected void GridTest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridTest.EditIndex = -1;
        BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = CryptoHelper.Decrypt(e.Row.Cells[5].Text);
        //}
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridTest.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
}