using CrossPlatformAESEncryption.Helper;
using DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegistration : System.Web.UI.Page
{
    DBClass db = new DBClass();
    public int _masterId, OrgId;
    string password;
    DataAccessLayer DAL = new DataAccessLayer();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        OrgId = int.Parse(Session["OrgId"].ToString());
        
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        password=CreateRandomPassword();
        SaveData();
     
        // send mail code here

        //ClsEmailTemplates emailTemp = new ClsEmailTemplates();
        //string mailSent = emailTemp.sendmail(txtEmail.Text, password, txtUserNm.Text, txtMobile.Text);
       // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);

    }
    void clearAllText()
    {
        txtDesignation.Text = txtEmail.Text = txtMobile.Text = txtUserNm.Text = string.Empty;
        
    }
    private void SaveData()
    {
        try
        {
            string Output = string.Empty;
            UserCreationBO objUserBO = new UserCreationBO();

            objUserBO.Name = txtUserNm.Text;
            objUserBO.Designation = txtDesignation.Text;
            objUserBO.Department = "";
           
            objUserBO.MobileNo = txtMobile.Text;
            objUserBO.Email = txtEmail.Text;
            objUserBO.Password = password;
            objUserBO.Remark = txtRemark.Text;
            objUserBO.OrgId = OrgId.ToString();
            objUserBO.CreatedBy = "";
            objUserBO.CreatedDate = System.DateTime.Now;
            objUserBO.EditedBy = "";
            objUserBO.EditedDate = System.DateTime.Now;
            objUserBO.DeletedBy = "";
            objUserBO.DeletedDate = System.DateTime.Now;
            userCreationDal objdal = new userCreationDal();

            _masterId = objdal.AddUser(objUserBO);
            // insert into user Login Master
            string _Mobile, _EmailId, _password;
            _Mobile = CryptoHelper.Encrypt(txtMobile.Text);
            _EmailId = CryptoHelper.Encrypt(txtEmail.Text);
            _password = CryptoHelper.Encrypt(password);

            SqlParameter[] paramlab = new SqlParameter[]
                                           {
                                                new SqlParameter("@UserId","0"),
                                                new SqlParameter("@Mobile",_Mobile),
                                                new SqlParameter("@EmailId",_EmailId),
                                                new SqlParameter("@Role","Enterprise"),
                                                new SqlParameter("@Password",_password),
                                                new SqlParameter("@UserName",txtUserNm.Text),
                                                new SqlParameter("@Returnval",SqlDbType.Int),
                                                 new SqlParameter("@orgId",OrgId)
                                              //  new SqlParameter("@loginStatus","A")
                                           };
            int ResultVal1 = DAL.ExecuteStoredProcedureRetnInt("Sp_AddUserLoginCredentialsEnterprise", paramlab);
            //Insert into Organization user
            SqlParameter[] param1 = new SqlParameter[]
                        {
                             new SqlParameter("@Name",txtUserNm.Text),
                             new SqlParameter("@Org_Id",OrgId),
                             new SqlParameter("@Branch_ID",""),
                             new SqlParameter("@Contact",_Mobile),
                             new SqlParameter("@Email",_EmailId),
                             new SqlParameter("@Role","CEO"),
                             new SqlParameter("@Password",""),
                             new SqlParameter("@returnval",SqlDbType.Int)
                         };
            int Resultval = DAL.ExecuteStoredProcedureRetnInt("Sp_AddOrgnizationUser", param1);

            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Save Successfully!\");", true);
            Response.Redirect("UserDetails.aspx");
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    private string CreateRandomPassword()
    {
        // Create a string of characters, numbers, special characters that allowed in the password  
        string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
        Random random = new Random();

        // Select one random character at a time from the string  
        // and create an array of chars  
        char[] chars = new char[6];
        for (int i = 0; i < 6; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }
        return new string(chars);
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
   
}