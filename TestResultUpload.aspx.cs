using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessHandler;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using WebApplication4;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CrossPlatformAESEncryption.Helper;
using System.Web.Configuration;
using Spire.Xls;

public partial class TestResultUpload : System.Web.UI.Page
{
    DBClass db = new DBClass();
    DataAccessLayer DAL = new DataAccessLayer();
    SqlConnection con;
    OleDbConnection Econ;
    int getRequiredColumNo = 0, uploadId;
    string getColSpec = "", OrgId, constr, Query, getRequiredColumNames, userName,labName,testId,mobileNo;
    web_api obj_webAPI = new web_api();
    DataTable dt_getData = new DataTable();
    string returnTokenValue, getToken = string.Empty;
    string pwd, userId, getTokenGenerated, getUserId, _getTokenFromWebConfig, branchId;
    string[] getTokenUserId;
    bool vaccinFlag;
    protected void Page_Load(object sender, EventArgs e)
    {
      

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        OrgId = (Session["OrgId"].ToString());
        userName = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + OrgId + "'").ToString();
        branchId = Session["BranchId"].ToString();

        if (!IsPostBack)
        {
            
            db.bindDrp("select testUploadName,testId from tbl_TestResultUploadSpec where orgId='" + OrgId+"'", drpTestName, "testUploadName", "testId");
            drpTestName.Items.Insert(0, new ListItem("All", "All")); //updated code to set first value "All"
            bindGrid();
            //Update tbl_TestResultUploadSpec with Org id
            //con.Open();
            //SqlCommand cmdemp = new SqlCommand("update tbl_TestResultUploadSpec set orgId ='" + OrgId + "' ", con);

            //cmdemp.ExecuteNonQuery();
            //con.Close();


        }
    }

    public void InsertIntoTestTables(string Token,string labNm,string testId,string userId,string value,string getResult)
    {
        obj_webAPI.ManualReportPunching(Token, labNm, testId);
        string get_response=  obj_webAPI.GetReportValuesUpdated(Token, testId);
        if(get_response!="")
           obj_webAPI.AddReport(testId, userId,value, getResult);
        // obj_webAPI.getValuesRef_insertAddReport(Token);


    }

    //get Token
    public string GetToken(string mobNo,string password)
    {
        _getTokenFromWebConfig = WebConfigurationManager.AppSettings["API_GetToken"];
       
        //var client = new RestClient("http://endpoint.visionarylifesciences.in/Auth/Signin");
        var client = new RestClient(_getTokenFromWebConfig);
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var body = @"{" + "\n" +

          @"  ""UserName"": ""@user""," + "\n" +
          @"  ""Password"": ""@pwd""," + "\n" +
        
        @"}";

        //string userName = string.Empty;string pwd = string.Empty;
       body= body.Replace("@user", mobNo);
        body= body.Replace("@pwd", password);

        request.AddParameter("application/json", body, ParameterType.RequestBody);

        // IRestResponse response = client.Execute(request);
        db.insert("insert into tempDebug values('"+"Body :"+ body + "')");

        var restResponse = client.Execute(request);
        db.insert("insert into tempDebug values('" + "restResponse :" + restResponse + "')");
        db.insert("insert into tempDebug values('" + "restResponse Content :" + restResponse.Content + "')");
        // string get_token = response.Content.ToString();
        dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);
        dynamic get_Json_data;
        if (restResponse.Content != "")
        {
            get_Json_data = JObject.Parse(jsonResponse);

            // grab the values and do your assertions :-)
            var Token = get_Json_data["Token"];
            var UserId = get_Json_data["UserId"];
            if (Token == null && userId == null)
                getToken = "0";
            else
                getToken = Convert.ToString(Convert.ToString(Token) + ',' + Convert.ToString(UserId));

        }
        else
            getToken = "0";
        return getToken;

        //end of code

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string path = string.Concat(Server.MapPath("~/BulkUploadFiles/" + FileUpload1.FileName));
        FileUpload1.SaveAs(path);
        userName = db.getData("SELECT Name FROM OrganizationUsers WHERE Org_Id = '" + OrgId + "' and Branch_ID='" + branchId + "'").ToString();

        //insert into bulk Upload Master

        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_AddbulkUploadMaster", con);
        cmd.Parameters.AddWithValue("@fileName", FileUpload1.FileName);
        cmd.Parameters.AddWithValue("@userName", userName);
        cmd.Parameters.AddWithValue("@uploadDate", System.DateTime.Now.ToString("MM/dd/yyyy"));
        cmd.Parameters.AddWithValue("@Org_Id", OrgId);//
        cmd.Parameters.AddWithValue("@uploadForWhome", "Emp_Health");
        cmd.Parameters.AddWithValue("@branchId", branchId);//
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        con.Close();
        uploadId = int.Parse(DAL.ExecuteScalar("select max(uploadId) from EmpBulkUploadMaster"));


        //display Bulk Upload master details
        bindGrid();


        //insert into testtemp Table
        int i= InsertExcelRecords(path);
        if(i==1)
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Uploaded Successfully!\");", true);


        //here bind values to datatable

     
        con.Open();
        SqlCommand cmdGetData = new SqlCommand("SP_GetData",con);
        cmdGetData.CommandType = CommandType.StoredProcedure;
        cmdGetData.Parameters.AddWithValue("@orgId",OrgId);
        cmdGetData.Parameters.AddWithValue("@uploadId",uploadId);
        cmdGetData.Parameters.AddWithValue("@testId", drpTestName.SelectedItem.Value);

        SqlDataAdapter da = new SqlDataAdapter(cmdGetData);
        da.Fill(dt_getData) ;
        con.Close();
        foreach (DataRow row in dt_getData.Rows)
        {
            mobileNo = CryptoHelper.Decrypt(row["Mobile"].ToString());
            pwd = CryptoHelper.Decrypt(row["Password"].ToString());
            //get User Id and token


            returnTokenValue = GetToken(mobileNo, pwd);
            if (returnTokenValue != "0")
            {
                getTokenUserId = returnTokenValue.Split(',');
                getTokenGenerated = getTokenUserId[0];
                getUserId = getTokenUserId[1];
                // insert into test related Tables
                InsertIntoTestTables(getTokenGenerated, row["labName"].ToString().TrimStart(), row["sTestId"].ToString(), getUserId, row["Value"].ToString(), row["Result"].ToString());

                //insert into userOrgBranch
                con.Open();
                SqlCommand cmdOrgAssign = new SqlCommand("SP_AddUserOrgAssign", con);
                cmdOrgAssign.Parameters.AddWithValue("@userId", row["sAppuserId"].ToString());
                cmdOrgAssign.Parameters.AddWithValue("@branchId", branchId);
                cmdOrgAssign.Parameters.AddWithValue("@orgId", OrgId);
                cmdOrgAssign.Parameters.AddWithValue("@createdBy", userName);//
                cmdOrgAssign.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmdOrgAssign.Parameters.AddWithValue("@Returnval", SqlDbType.Int);

                cmdOrgAssign.CommandType = CommandType.StoredProcedure;
                cmdOrgAssign.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public void bindGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_BindBulkUploadDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@orgId", OrgId);
        cmd.Parameters.AddWithValue("@uploadForWhome", "Emp_Health");
        cmd.Parameters.AddWithValue("@branchId", branchId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridTestBulk.DataSource = dt;
        GridTestBulk.DataBind();
        con.Close();
    }
    private void ExcelConn(string FilePath)
    {

        constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1;""", FilePath);
        //constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;""", FilePath);
        Econ = new OleDbConnection(constr);
    }
    private void connection()
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

    }

    //this function is for removing blank rows from excel sheet
    DataTable RemoveEmptyRowsFromDataTable(DataTable Exceldt)
    {
        for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
        {
            if (Exceldt.Rows[i][1] == DBNull.Value)
                Exceldt.Rows[i].Delete();
        }
        Exceldt.AcceptChanges();
        return Exceldt;
    }

    // this function is for replacing one word only not same word occurs in query.
    public string SafeReplace(string input, string find, string replace, bool matchWholeWord)
    {
        string textToFind = matchWholeWord ? string.Format(@"\b{0}\b", find) : find;
        return Regex.Replace(input, textToFind, replace);
    }
    public DataTable excelupload(string path)
    {
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(@path);

        Worksheet sheet = workbook.Worksheets[0];

        DataTable tbl = sheet.ExportDataTable();
        return tbl;
    }

    private int InsertExcelRecords(string FilePath)
    {
        string getActualStringReplace = string.Empty;
        string instruction = string.Empty;
            getRequiredColumNames = db.getData("select colSpecification from tbl_TestResultUploadSpec where testUploadName='" + drpTestName.SelectedItem.Text + "' and orgId='"+OrgId+"'");

        //get get number of column from testResultUploadspec table 
        //if (!vaccinFlag)
        //{
        //    getRequiredColumNames = db.getData("select colSpecification from tbl_TestResultUploadSpec where testUploadName='" + drpTestName.SelectedItem.Text + "'");
        //   // Query = string.Format("select *,@ColSpec,'" + uploadId + "' as UploadId FROM [{0}]", "Sheet1$");
        //    Query = string.Format("select [Test Code],[Test Name],[Employee Name],Age,[Gender],[Emp Code],Status,Remark,orgId,@ColSpec,'" + uploadId + "' as UploadId,[Lab Name],Result,branchId,[User Id] FROM [{0}] ", "Sheet1$");
        //}
        //else
        //{
        //  //  instruction = "Please add If your status is Fully Vaccinated then Use Keyword as 'Fully',if status is Not Vaccinated Use  Keyword as 'Not',if status is Partilly or Half Vaccinated Use  Keyword as 'Partially'";
        //       Query = string.Format("select *  FROM [{0}]", "Sheet1$");
        //    //Query = string.Format("select [Test Code],[Test Name],[Employee Name],Age,[Gender],[Emp Code],Status,Remark,orgId ,'" + uploadId + "' as UploadId,[Vaccine Date],[Vaccination Name],[Center Name],Result,branchId,[User Id] FROM [{0}]", "Sheet1$");
        //}
       
     
        DataTable dtReturn = new DataTable();
        //ExcelConn(FilePath);

        //OleDbCommand Ecom = new OleDbCommand(Query, Econ);
        //Econ.Open();

        //DataSet ds = new DataSet();
        //OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
        //Econ.Close();
        //oda.Fill(ds);
        //DataTable Exceldt = ds.Tables[0];
        //dtReturn = RemoveEmptyRowsFromDataTable(Exceldt);
        DataTable Exceldt = excelupload(FilePath);

        dtReturn = RemoveEmptyRowsFromDataTable(Exceldt);
        // dtReturn.Columns.Add("UploadId");
        //dtReturn.Columns["UploadId"].DefaultValue =uploadId;
        //dtReturn.Columns["Organization Id"].DefaultValue = OrgId;
        foreach (DataRow row in dtReturn.Rows)
        {
            row["UploadId"] = uploadId;
         //   row["Organization Id"] = OrgId;

        }
        connection();

        //creating object of SqlBulkCopy    
        SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //assigning Destination table name    
        if (!vaccinFlag)
        {
            objbulk.DestinationTableName = "testTemp";
            //Mapping Table column    
            objbulk.ColumnMappings.Add("Test Code", "testCode");//1st column is from excel sheet and 2nd is from database table
            objbulk.ColumnMappings.Add("Test Name", "testName");
            objbulk.ColumnMappings.Add("Employee Name", "empName");
            objbulk.ColumnMappings.Add("Emp Code", "empCode");
            objbulk.ColumnMappings.Add("Gender", "gender");
            objbulk.ColumnMappings.Add("Age", "age");
            objbulk.ColumnMappings.Add("OrgId", "orgId");
            objbulk.ColumnMappings.Add("Status", "status");
            objbulk.ColumnMappings.Add("Remark", "remark");
            objbulk.ColumnMappings.Add("UploadId", "uploadId");
            objbulk.ColumnMappings.Add("Lab Name", "labName");
            objbulk.ColumnMappings.Add("Result", "Result");
            objbulk.ColumnMappings.Add("BranchId", "branchId");
            // for loop
            int j = 1;
            string[] splitTestColSpec = new string[500];
            if (getRequiredColumNames != null)
            {
                getColSpec = getRequiredColumNames.ToString().TrimEnd(',');

                splitTestColSpec = getColSpec.Split(',');

                foreach (string colSpec in splitTestColSpec)
                {
                   // getRequiredColumNames = SafeReplace(getRequiredColumNames, colSpec, colSpec + " as col" + j.ToString(), true);
                  //  objbulk.ColumnMappings.Add(string.Format(@"""{0}""", colSpec) , string.Format(@"""{0}""", "col" + j.ToString()) );
                    objbulk.ColumnMappings.Add(colSpec,  "col" + j.ToString());
                    j++;
                }

            }
            else
            {
                objbulk.ColumnMappings.Add(string.Format(@"""{0}""", getColSpec), "col1");

            }
            //end for loop
        }
        else
        {
            objbulk.DestinationTableName = "vaccinationDetails";

            objbulk.ColumnMappings.Add("Employee Name", "Name");
            objbulk.ColumnMappings.Add("Gender", "Gender");
            objbulk.ColumnMappings.Add("Vaccine Date", "date");
            objbulk.ColumnMappings.Add("Vaccination Name", "vaccinationName");
            objbulk.ColumnMappings.Add("Center Name", "centerName");
            objbulk.ColumnMappings.Add("User Id", "sAppUserId");
            objbulk.ColumnMappings.Add("Status", "status");
            objbulk.ColumnMappings.Add("BranchId", "branchId");
            objbulk.ColumnMappings.Add("OrgId", "orgId");
           // objbulk.ColumnMappings.Add("Instruction", "Result");
        }
        //if (getColSpec != "")
        //{
        //    j = 1;
        //    foreach (string colSpec in splitTestColSpec)
        //    {
        //        objbulk.ColumnMappings.Add("col" + j.ToString(), "col" + j.ToString());
        //        j++;
        //    }
        //}
        con.Open();
        objbulk.WriteToServer(Exceldt);
        con.Close();


      //  DAL.ExecuteScalar("update testTemp set status='Success' where uploadId='" + uploadId + "' and orgId='" + OrgId + "' and branchId='" + branchId + "'");
        return 1;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (drpTestName.SelectedItem.Text != "All")
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_createTestUplaodExcel", con);//uploadeId='"+0+"' and 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orgId", OrgId);
            cmd.Parameters.AddWithValue("@testName", drpTestName.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@branchId", branchId);
            cmd.Parameters.AddWithValue("@testId", drpTestName.SelectedItem.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();// (DataTable)ViewState["DataTable"];
            da.Fill(dt);
            con.Close();

          
            if (dt.Rows.Count > 0)
            {
                getColSpec = dt.Rows[0]["colSpecification"].ToString().TrimEnd(',');
                string[] splitTestColSpec = getColSpec.Split(',');

                foreach (string colSpec in splitTestColSpec)
                {
                    dt.Columns.Add(colSpec);

                }

                //   dt.Columns.Add("Employee Name");
                //  dt.Columns.Add("Age");
                //   dt.Columns.Add("Gender");
                //  dt.Columns.Add("Emp Code");
                if (!vaccinFlag)
                {
                 //   dt.Columns.Add("OrgId");
                    dt.Columns.Add("Lab Name");
                    dt.Columns.Add("Status");
                    dt.Columns.Add("Remark");
                    dt.Columns.Add("UploadId");
                    dt.Columns.Add("Result");
                    //  dt.Columns.Add("BranchId");
                    dt.Columns.Remove("Instruction");
                    dt.Columns.Remove("colSpecification");//empnm,age,gender,srno,empCode
                }
                else
                {
                    dt.Columns.Add("Vaccine Date");
                    dt.Columns.Add("Vaccination Name");
                    dt.Columns.Add("Center Name");
                    dt.Columns.Add("Remark");
                    dt.Columns.Add("Status");
                  //  dt.Columns.Add("User ID");
                  //  dt.Columns.Add("BranchId");
                  //  dt.Columns.Add("OrgId");
                    dt.Columns.Add("UploadId");
                    dt.Columns.Add("Result");
               //     dt.Columns.Add("Instruction");
                    dt.Columns.Remove("colSpecification"); 
                    dt.Columns.Remove("Column1");
                }
                CreateExcelFile(dt);

            //    ExportToExcel();
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found!\");", true);
                lblWarning.Text= "No Record Found!";
            }
        }
        else
            lblWarning.Text = "Please Select Test";


    }
    private void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "SampleExcelFormat" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //GridView1.GridLines = GridLines.Both;
        //GridView1.HeaderStyle.Font.Bold = true;
        //GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }
    public void CreateExcelFile(DataTable Excel)
    {
        //Clears all content output from the buffer stream.    
        Response.ClearContent();
        //Adds HTTP header to the output stream    
       
        Response.AddHeader("content-disposition", string.Format("attachment; filename=Sheet1.xls"));
        // Gets or sets the HTTP MIME type of the output stream    
        Response.ContentType = "application/vnd.ms-excel";
        string space = "";
        foreach (DataColumn dcolumn in Excel.Columns)
        {
            Response.Write(space + dcolumn.ColumnName);
            space = "\t";
        }
        Response.Write("\n");
        int countcolumn;
        foreach (DataRow dr in Excel.Rows)
        {
            space = "";
            for (countcolumn = 0; countcolumn < Excel.Columns.Count; countcolumn++)
            {
                Response.Write(space + dr[countcolumn].ToString());
                space = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }
    protected void DownloadFile(object sender, CommandEventArgs e)
    {
        con.Open();
       string uploadId = e.CommandArgument.ToString();
        SqlCommand cmd = new SqlCommand("select * from testTemp where orgId='" + OrgId + "' and uploadId='"+ uploadId + "'", con);//uploadeId='"+0+"' and 
        //cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();

        DataTable dt = new DataTable();// (DataTable)ViewState["DataTable"];
        da.Fill(dt);
        CreateExcelFile(dt);

        ExportToExcel();

    
    }
 protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridTestBulk.PageIndex = e.NewPageIndex;
        this.bindGrid();
    }



    //this function is for Upload result dyanamically for future use
    //public static object getReferences(string data)
    //{
    //    DataAccessLayer DAL = new DataAccessLayer();
    //    DataSet dt = new DataSet();
    //    string response = "";
    //    string Data = data.Replace("!~^!", "¶");
    //    string[] DataArr = Data.Split('¶');
    //    string id = DataArr[0];
    //    string checkFrom = DataArr[1];
    //    string Age = DataArr[2];
    //    string Gender = DataArr[3];
    //    string Val = DataArr[4];
    //    string age = Age.Split(' ')[0];
    //    string AgeUnit = Age.Split(' ')[1];
    //    float parsedValue;
    //    if (float.TryParse(Val, out parsedValue))
    //    {
    //        if (checkFrom == "Analyte")
    //        {
    //            SqlParameter[] param = new SqlParameter[]
    //                     {
    //                        new SqlParameter("@TASMId",id),
    //                        new SqlParameter("@Gender",Gender),
    //                        new SqlParameter("@Age",age),
    //                        new SqlParameter("@AgeUnit",AgeUnit),
    //                        new SqlParameter("@val",(Val !="")?Val:"0")
    //                    };
    //            dt = DAL.ExecuteStoredProcedureDataSet("Sp_GetTestReferencerangeInterpretation2", param);
    //            if (dt.Tables[0].Rows.Count > 0)
    //            {
    //                response = dt.Tables[0].Rows[0]["Interpretation"].ToString();
    //            }
    //            else if (dt.Tables[1].Rows.Count > 0)
    //            {
    //                response = dt.Tables[1].Rows[0]["Interpretation"].ToString();
    //            }
    //            else
    //            {
    //                response = "";
    //            }
    //        }
    //        else if (checkFrom == "SubAnalyte")
    //        {
    //            SqlParameter[] param1 = new SqlParameter[]
    //                     {
    //                        new SqlParameter("@TASMId",id),
    //                        new SqlParameter("@Gender",Gender),
    //                        new SqlParameter("@Age",age),
    //                        new SqlParameter("@AgeUnit",AgeUnit),
    //                        new SqlParameter("@val",(Val !="")?Val:"0")
    //                    };
    //            dt = DAL.ExecuteStoredProcedureDataSet("Sp_GetSubTestReferencerangeInterpretation2", param1);
    //            if (dt.Tables[0].Rows.Count > 0)
    //            {
    //                response = dt.Tables[0].Rows[0]["Interpretation"].ToString();
    //            }
    //            else if (dt.Tables[1].Rows.Count > 0)
    //            {
    //                response = dt.Tables[1].Rows[0]["Interpretation"].ToString();
    //            }
    //            else
    //            {
    //                response = "";
    //            }
    //        }
    //    }
    //    return JsonConvert.SerializeObject(response);
    //}

    protected void drpTestName_TextChanged(object sender, EventArgs e)
    {
        vaccinFlag = false;
        if (drpTestName.SelectedItem.Text == "Cowin Vaccination")
            vaccinFlag = true;

    }
}