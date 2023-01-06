<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="TestMaster.aspx.cs" Inherits="TestMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="block-header">
                        <!--<h2>FORM EXAMPLES</h2>-->
                    </div>
                    <!-- Inline Layout | With Floating Label -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>Test Master
                                <!--<small>With floating label</small>-->
                                    </h2>
                                  <%--  <div style="float:right">
                                        <asp:Button ID="Button1" runat="server" Text="Add New Branch" class="btn bg-purple waves-effect"/>

                                    </div>--%>
                                </div>
                                <div class="body" id="branch">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label7" runat="server" Text="Test ID" Font-Size="Large"></asp:Label></b>
<%--                                                        <asp:TextBox ID="txtId" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtId" runat="server" class="form-control" Text="0"></asp:Label>
                                                    </div>
                                                </div>
                                                <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                         <b> <asp:Label ID="Label1" runat="server" Text="Test Code" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtTestCode" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="txtTestCode" runat="server" class="form-control" Text="0"></asp:Label>

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                         <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label2" runat="server" Text="Test Name" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtTestname" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="txtTestname" runat="server" class="form-control" Text="0"></asp:Label>
                                                    </div>
                                                </div>
                                                <%--<asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtbranchName" ErrorMessage="Please enter Branch" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label6" runat="server" Text="Analyte Name" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtAnalyte" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtAnalyte" runat="server" class="form-control" Text="0"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label4" runat="server" Text="Profile" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="txtProfile" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label5" runat="server" Text="Section" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="txtSection" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                                       
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label3" runat="server" Text="Reference Type" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="lblRefType" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label9" runat="server" Text="Grade" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="lblgrade" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                                        
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label11" runat="server" Text="Unit" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="lblUnit" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label13" runat="server" Text="Upper Limit" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="lblUpperLimit" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                                         <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label15" runat="server" Text="Lower Limit" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="lblLowerlimit" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label17" runat="server" Text="Result Type" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="lblresultType" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                                        
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label19" runat="server" Text="Method Name" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="lblmethodNm" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label21" runat="server" Text="Sample Type" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="lblSampleType" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                                        
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <b> <asp:Label ID="Label23" runat="server" Text="Quantity" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtProfile" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                         <asp:Label ID="lblQty" runat="server" class="form-control" Text="0"></asp:Label>


                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                       <b> <asp:Label ID="Label25" runat="server" Text="Time Period" Font-Size="Large"></asp:Label></b>
                                                        <%--<asp:TextBox ID="txtSection" runat="server" class="form-control" placeholder=""></asp:TextBox>--%>
                                                        <asp:Label ID="lbltimePeriod" runat="server" class="form-control" Text="0"></asp:Label>
                                                      

                                                    </div>
                                                </div>
                                            </div>
                                         
                                        </div>
                                         <div class="row clearfix">
                                         
                                               
                                                    <div>
                                                       <center> <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="btnClose_Click"/> </center>
                                                    </div>
                                                
                                           
                                             </div>
                                    
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Inline Layout | With Floating Label -->
                  
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

