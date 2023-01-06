using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrossPlatformAESEncryption;
using CrossPlatformAESEncryption.Helper;

public partial class UserProfile : System.Web.UI.Page
{
    DataAccessLayer DAL = new DataAccessLayer();
    string branchId, orgId, userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        branchId = Session["BranchId"].ToString();
        orgId = Session["OrgId"].ToString();

        if (!IsPostBack)
        {
            getData();


        }

    }
    void getData()
    {
        DataTable dt = DAL.GetDataTable("select * from OrganizationUsers where Org_Id='" + orgId + "' and Branch_ID='" + branchId + "' ");
        foreach (DataRow row in dt.Rows)
        {
          //  lblUsernm.Text = row["Name"].ToString();
            txtName.Text = row["Name"].ToString();
            txtEmail.Text = CryptoHelper.Decrypt(row["Email"].ToString());
            userId = row["ID"].ToString();
            txtContact.Text = CryptoHelper.Decrypt(row["Contact"].ToString());
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        getData();

        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@userId",userId),
           new SqlParameter("@role","Enterprise"),
           new SqlParameter("@password",CryptoHelper.Encrypt(txtNewPassword.Text))
        };
        DataTable dt = DAL.ExecuteStoredProcedureDataTable("SP_UpdateProfilePassword", param);
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Password Updated Successfully!\");", true);
	sendMail();
    }
    void sendMail()
    {
        ClsEmailTemplates emailTemp = new ClsEmailTemplates();
        string subject = "HowzU Connect – Update Password";

        string mailbody =  "Greetings of the day! <br />" +

            "<h3>Congratulations! You have successfully updated your password. </h3><br />" +
            "<br />Follow the steps below for the further process now <br /><br />" +
             "<b>1 . Download the App :</b><br /><br />" +
            "<b>iOS User</b> : https://apps.apple.com/in/app/howzu/id1481816983 <br />" +
            "<b>Android User</b> : https://play.google.com/store/apps/details?id=com.howzu <br /><br />" +
            "<b>2 . Kindly use following Password to Login,</b><br /><br />" +
                   
                    "<b>Password : " + txtNewPassword.Text + "</b><br /><br />" +

            "<b>Regards,</b><br />" +
            "<b>Howzu Team. </b> ";
       string mailSent = emailTemp.sendmail(txtEmail.Text, txtNewPassword.Text, txtName.Text, "", mailbody, subject);
    }

}