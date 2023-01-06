using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userBranchAssign : System.Web.UI.Page
{
    public int userId, objuserBrancgAssignBO, drpBranchName, branchId, AddBranchDetails, EmpChieldID, OrgId;
   
    string branchName, userNm;
  
    DataTable dt = new DataTable();
    DBClass db = new DBClass();
    userBranchAccessDAL objDAL = new userBranchAccessDAL();
    DataAccessLayer DAL = new DataAccessLayer();
    protected void Page_Load(object sender, EventArgs e)
       {
        
        userNm = Session["userName"].ToString();
        branchId = int.Parse(Session["BranchId"].ToString());

        OrgId = int.Parse(Session["OrgId"].ToString());
       
        userNm = Session["userName"].ToString();
        //orgId = int.Parse(db.getData("SELECT OrganizationMaster.ID FROM OrganizationMaster INNER JOIN  UserLoginMaster ON OrganizationMaster.ID = UserLoginMaster.UserId WHERE(UserLoginMaster.EmailId = '" + userNm + "') ").ToString());
       
            if (!this.IsPostBack)
            {

            db.bindDrp("select distinct branchName from BranchMaster  where Org_Id='" + OrgId + "'", drpParentBranch, "branchName", "branchName");
            db.bindDrp("select UserName from UserLoginMaster where orgId='" + OrgId + "'", drpUserName, "UserName", "UserName");
            drpUserName.Items.Insert(0, new ListItem("All", "All"));
            drpParentBranch.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
            BindGrid();

            }
       
        //DataTable dt = new DataTable();
        //dt.Columns.AddRange(new DataColumn[5] { new DataColumn("QualificationId"), new DataColumn("Qulification"), new DataColumn("Pyear"), new DataColumn("Grade"), new DataColumn("University") });

        //ViewState["Qulification"] = dt;}


    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        ClsEmailTemplates emailTemp = new ClsEmailTemplates();
        lblError.Visible = true;
        if (drpUserName.SelectedValue == "All")
            lblError.Text = "Please Select  User Name";
        else if (drpParentBranch.Text == "All")
            lblError.Text = "Please Select BranchName";
         
        else if (drpStatus1.SelectedValue == "--Select--")
            lblError.Text = "Please Select  Status";
        else
        {
            insert();
            BindGrid();
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);

            // send mail code here
            SqlParameter[] paramlab = new SqlParameter[]
                                         {
                                                new SqlParameter("@UserName",drpUserName.Text),
                                                 new SqlParameter("@orgId",OrgId)
                                            
                                         };
            dt = DAL.ExecuteStoredProcedureDataTable("Sp_GetDetailsForEmail", paramlab);
            string emailId="", password="";
            foreach (DataRow dr in dt.Rows)
            {
                emailId =CryptoHelper.Decrypt(dr["EmailId"].ToString());
                password = CryptoHelper.Decrypt( dr["Password"].ToString());
               
            }
            emailTemp.sendmailForEnterprise(emailId, password, drpUserName.Text);
           
            lblError.Visible = false;

        }
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetUserBranchAssign", con))
         
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orgId", OrgId);
              //  cmd.Parameters.AddWithValue("userName", userName);
             //   cmd.Parameters.AddWithValue("branchName", branchName);

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    private void insert()
    {
        try
        {
            string Output = string.Empty;
            userBranchAssignBO branchAssignBO = new userBranchAssignBO();


            branchAssignBO.UserName = drpUserName.SelectedValue;
            branchAssignBO.BranchName = drpParentBranch.SelectedValue;
            branchAssignBO.Status = drpStatus1.SelectedValue;
            branchAssignBO.CreatedBy = "";
            branchAssignBO.CreatedDate = System.DateTime.Now;
            branchAssignBO.DeletedBy = "";
            branchAssignBO.DeletedDate = System.DateTime.Now;
            branchAssignBO.EditedBy = "";
            branchAssignBO.EditedDate = System.DateTime.Now;
           // branchAssignBO.UserId = drpUserName.SelectedValue;
            //BranchDal objdal = new BranchDal();
            userBranchAccessDAL objDal = new userBranchAccessDAL();
            int j = objDal.userBranchAssignDetails(branchAssignBO, int.Parse(OrgId.ToString()),branchId);
            //drpUserName.SelectedValue = "--Select--";
            //drpStatus1.SelectedValue = "--Select--";




        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        objDAL.delete(id);
        BindGrid();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete ?')){ return false; };";
                }
            }
        }
    }

}



   
