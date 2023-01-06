<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

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
                                    <h2>User Registration
                                <!--<small>With floating label</small>-->
                                    </h2>

                                </div>
                                <div class="body">
                                    <form>
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                                        <asp:TextBox ID="txtUserNm" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                    </div>
                                                <asp:RequiredFieldValidator ID="use3" runat="server" ControlToValidate="txtUserNm" ErrorMessage="Please Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator>  
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                        
                                                    </div>
                                                <asp:RequiredFieldValidator ID="use2r" runat="server" ControlToValidate="txtMobile" ErrorMessage="Please Enter Mobile No." ForeColor="Red"></asp:RequiredFieldValidator>  
                                                </div>
                                            </div>
                                            </div>
                                        <div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                     
                                                    </div>
                                                <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter EmailId" ForeColor="Red"></asp:RequiredFieldValidator>  
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="designation" runat="server" Text="Designation"></asp:Label>
                                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                       
                                                         
                                                    </div>
                                                <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Please Enter Designation" ForeColor="Red"></asp:RequiredFieldValidator>  
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="row clearfix">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">

                                                        <asp:Label ID="Label3" runat="server" Text="Country"></asp:Label>
                                                        <asp:DropDownList ID="drpCountry" runat="server" class="form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label4" runat="server" Text="City"></asp:Label>
                                                        <asp:DropDownList ID="drpCity" runat="server" class="form-control">
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">

                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="Insert"/>
                                            </div>
                                        </div>--%>
                                       <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover dataTable js-exportable" AutoGenerateColumns="false"
                                                    EmptyDataText="No records has been added." OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound" >
                                                    <Columns>

                                                        <asp:BoundField DataField="country" HeaderText="Country" ItemStyle-Width="200" />
                                                        <asp:BoundField DataField="city_branch" HeaderText="City" ItemStyle-Width="200" />
                                                        
                                                        <%--  <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120" />--%>
                                         <%--<asp:ButtonField Text="Delete" HeaderText="Delete"></asp:ButtonField>
                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  ItemStyle-Width="50"/>
                                                    </Columns>
                                                </asp:GridView>--%>
                                         <div class="row clearfix">
                                          <%--  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>
                                                        <asp:TextBox ID="txtDept" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                     
                                                    </div>
                                                </div>
                                            </div>--%>
                                               <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:Label ID="Label3" runat="server" Text="Remark"></asp:Label>
                                                        <asp:TextBox ID="txtRemark" runat="server" class="form-control" placeholder=""></asp:TextBox>

                                                       
                                                         
                                                    </div>
                                                </div>
                                            </div>
                                             </div>
                                            <%--<div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                <div class="form-group form-float">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="drpStatus" runat="server" class="form-control">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Deactive</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div >
                                                
                                                <center><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary waves-effect" data-type="basic" OnClick="BtnSave_Click" /></center>
                                                <%--                                        <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect">Save</button>--%>
                                            </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

