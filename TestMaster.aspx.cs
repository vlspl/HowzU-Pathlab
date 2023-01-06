using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestMaster : System.Web.UI.Page
{
    TestDal objdal = new TestDal();
    DataTable dtFillData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sTestId"] != null)
        {
            dtFillData = objdal.fillData(Request.QueryString["sTestId"]);
            foreach (DataRow row in dtFillData.Rows)
            {
                // basic Info
                txtId.Text= row["sTestId"].ToString();
                txtTestCode.Text = row["sTestCode"].ToString();
                txtTestname.Text = row["sTestName"].ToString();
                txtProfile.Text = row["sProfileName"].ToString();
                txtSection.Text = row["sSectionName"].ToString();
                txtAnalyte.Text = row["sAnalyteName"].ToString();
                lblRefType.Text = row["ReferenceType"].ToString();
                lblgrade.Text = row["Grade"].ToString();
                lblUnit.Text = row["Unit"].ToString();
                lblLowerlimit.Text = row["LowerLimit"].ToString();
                lblUpperLimit.Text = row["UpperLimit"].ToString();
                lblresultType.Text = row["sResultType"].ToString();
                lblmethodNm.Text = row["sMethodName"].ToString();
                lblSampleType.Text = row["sSampleType"].ToString();
                lblQty.Text = row["sQuantity"].ToString();
                lbltimePeriod.Text = row["sTimePeriod"].ToString();
            }
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Test.aspx");
    }
}