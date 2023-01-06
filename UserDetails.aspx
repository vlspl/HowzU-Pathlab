<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container-fluid">
                  
                    <!-- Exportable Table -->
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="header">
                                    <h2>User List
                                    </h2>
                                      <div class="row">
                                <div class="col-xs-4">

                                    <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left: 270%; font-weight: bolder"><a href="UserRegistration.aspx" style="color: white;">Add New User </a></button>

                                </div>
                            </div>
                                </div>
                                <div class="body">
                                    <div class="table-responsive">
                                      
                                        <asp:GridView ID="GridUser" CssClass="table table-bordered table-striped table-hover dataTable js-exportable"
                                            runat="server" AutoGenerateColumns="false"  DataKeyNames="masterid" OnRowDeleting="GridUser_RowDeleting" OnRowEditing="GridUser_RowEditing"
                                            OnRowDataBound="OnRowDataBound" AllowPaging="true"  OnPageIndexChanging="OnPageIndexChanging"  AllowSorting="true"  PageSize="10">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="30">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                        <%--<asp:HyperLink runat="server" NavigateUrl='<%# Eval("branchId", "~/Branch.aspx?branchId={0}") %>'
                                                            Text='<%# Eval("branchId") %>' />--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="branchId" HeaderText="Branch ID" ItemStyle-Width="50" ReadOnly="true" />--%>
                                                <asp:BoundField DataField="Name" HeaderText="User Name" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="designation" HeaderText="Designation" ItemStyle-Width="150" />
                                                
                                                <asp:BoundField DataField="mobile" HeaderText="Mobile No" ItemStyle-Width="80" />
                                                <asp:BoundField DataField="emailId" HeaderText="Email Id" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="createdDate" HeaderText="Created On" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="remark" HeaderText="Remark" ItemStyle-Width="70" />

                                                <%--<asp:CommandField ShowEditButton="true" HeaderText="Update" ItemStyle-Width="20" EditText="<i class='material-icons'>edit</i>" />--%>
                                                <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" ItemStyle-Width="20" DeleteText="<i class='material-icons'>delete</i>" />
                                               <%--  <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Branch.aspx?branchId={0}",
                    HttpUtility.UrlEncode(Eval("branchId").ToString())) %>'>
                                                     <i class="material-icons">edit</i></asp:HyperLink>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- #END# Exportable Table -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>

