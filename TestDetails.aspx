<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMasterPage.master" AutoEventWireup="true" CodeFile="TestDetails.aspx.cs" Inherits="TestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Exportable Table -->
    <section class="content">
      <div class="container-fluid">
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                                Employee Test Details
                            </h2>
                              <div class="row">
             <div class="col-xs-4">
                 
                 <button class="btn btn-lg bg-pink waves-effect" type="submit" style="margin-left:200%;font-weight:bolder"><a href="AssignTest.aspx" style="color:white;">Assign Test</a></button>
                   
             </div>
         </div>
                        </div>
                        <div class="body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped table-hover dataTable js-exportable">
                                    <thead>
                                        <tr>
                                            
                                            <th>Department</th>
                                            <th>Branch</th>
                                            <th>Test Count</th>
                                             <th>Employee Count</th>
                                              <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>Department</th>
                                            <th>Branch</th>
                                            <th>Test Count</th>
                                             <th>Employee Count</th>
                                              <th>Action</th>
                                        </tr>
                                    </tfoot>
                                    <tbody>
                                        <tr>
                                           
                                            <td>Finance</td>
                                            <td>Ahmedabad</td>
                                             <td>3</td>
                                             <td>2</td>
                                            <td>View Report</td>


                                        </tr>
                                        <tr>
                                           
                                            <td>Finance</td>
                                            <td>Ahmedabad</td>
                                             <td>5</td>
                                             <td>4</td>
                                            <td>View Report</td>


                                        </tr>
                                        <tr>
                                            
                                            <td>Sales</td>
                                            <td>Mumbai</td>
                                             <td>4</td>
                                             <td>10</td>
                                            <td>View Report</td>


                                        </tr>
                                      

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          </div>
    </section>
            <!-- #END# Exportable Table -->
</asp:Content>

