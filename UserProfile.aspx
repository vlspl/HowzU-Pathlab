<%@ Page Title="" Language="C#" MasterPageFile="~/EnterpriseMasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="content">
        <div class="container-fluid">
            <div class="row clearfix">
                <%--<div class="col-xs-12 col-sm-3">
                    <div class="card profile-card">
                        <div class="profile-header">&nbsp;</div>
                        <div class="profile-body">
                            <div class="image-area">
                                <img src="../../images/user-lg.jpg" alt="AdminBSB - Profile Image" />
                            </div>
                            <div class="content-area">
                                <h3><asp:Label ID="lblUsernm" runat="server" Text="" ></asp:Label></h3>
                                <p style="text-align:center;"> <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label></p>
                                 <p style="text-align:center;">Administrator</p>
                            </div>
                        </div>
                        <div class="profile-footer">
                            <ul>
                                <li>
                                    <span>Followers</span>
                                    <span>1.234</span>
                                </li>
                                <li>
                                    <span>Following</span>
                                    <span>1.201</span>
                                </li>
                                <li>
                                    <span>Friends</span>
                                    <span>14.252</span>
                                </li>
                            </ul>
                            <button class="btn btn-primary btn-lg waves-effect btn-block">FOLLOW</button>
                        </div>
                    </div>--%>

                    <%--<div class="card card-about-me">
                        <div class="header">
                            <h2>ABOUT ME</h2>
                        </div>
                        <div class="body">
                            <ul>
                                <li>
                                    <div class="title">
                                        <i class="material-icons">library_books</i>
                                        Education
                                    </div>
                                    <div class="content">
                                        B.S. in Computer Science from the University of Tennessee at Knoxville
                                    </div>
                                </li>
                                <li>
                                    <div class="title">
                                        <i class="material-icons">location_on</i>
                                        Location
                                    </div>
                                    <div class="content">
                                        Malibu, California
                                    </div>
                                </li>
                                <li>
                                    <div class="title">
                                        <i class="material-icons">edit</i>
                                        Skills
                                    </div>
                                    <div class="content">
                                        <span class="label bg-red">UI Design</span>
                                        <span class="label bg-teal">JavaScript</span>
                                        <span class="label bg-blue">PHP</span>
                                        <span class="label bg-amber">Node.js</span>
                                    </div>
                                </li>
                                <li>
                                    <div class="title">
                                        <i class="material-icons">notes</i>
                                        Description
                                    </div>
                                    <div class="content">
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam fermentum enim neque.
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>--%>
                <div class="col-xs-12 col-sm-9">
                    <div class="card" style="height:500px;">
                        <div class="body"  >
                            <div>
                                <ul class="nav nav-tabs" role="tablist">
                                    <%--<li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Home</a></li>--%>
                                    <li role="presentation" class="active"><a href="#profile_settings" aria-controls="settings" role="tab" data-toggle="tab">Profile Settings</a></li>
                                    <li role="presentation"><a href="#change_password_settings" aria-controls="settings" role="tab" data-toggle="tab">Change Password</a></li>
                                </ul>

                                <div class="tab-content">
                                    
                                    <div role="tabpanel" class="tab-pane fade in active" id="profile_settings">
                                        <br />
                                        <div class="col-lg-12">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <div class="image-area">
                                                        <img src="../../images/Default_user.png" alt="AdminBSB - Profile Image" />
                                                    </div>
                                                     <div class="content-area">
                                <h3><asp:Label ID="lblUsernm" runat="server" Text="" ></asp:Label></h3>
                                <p > <asp:Label ID="lblDesignation" runat="server" Text="Administrator"></asp:Label></p>
                               
                            </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <div class="form-group">
                                                    <label for="NameSurname" class="col-sm-2 control-label">Name</label>
                                                    <div class="col-sm-10">
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtName" runat="server" class="form-control" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group">
                                                    <label for="Email" class="col-sm-2 control-label">Email</label>
                                                    <div class="col-sm-10">
                                                        <div class="form-line">
                                                            <%--     <input type="email" class="form-control" id="Email" name="Email" placeholder="Email" value="" required>--%>
                                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <%--<div class="form-group">
                                                <label for="InputExperience" class="col-sm-2 control-label">Experience</label>

                                                <div class="col-sm-10">
                                                    <div class="form-line">
                                                        <textarea class="form-control" id="InputExperience" name="InputExperience" rows="3" placeholder="Experience"></textarea>
                                                    </div>
                                                </div>
                                            </div>--%>
                                                <div class="clearfix"></div>
                                                <div class="form-group">
                                                    <label for="InputSkills" class="col-sm-2 control-label">Contact</label>

                                                    <div class="col-sm-10">
                                                        <div class="form-line">
                                                            <%--   <input type="text" class="form-control" id="InputSkills" name="InputSkills" placeholder="Skills">--%>
                                                            <asp:TextBox ID="txtContact" runat="server" class="form-control" required></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    
                                        <div class="col-lg-12">
                                             <div class="col-lg-4"></div>
                                             <div class="col-lg-8">
                                                 <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <input type="checkbox" id="terms_condition_check" class="chk-col-red filled-in" />
                                                    <label for="terms_condition_check">I agree to the <a href="#">terms and conditions</a></label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10">
<%--                                                    <button type="submit" class="btn btn-danger">SUBMIT</button>--%>
                                        <asp:Button ID="btnSubmit" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Save" ValidationGroup="LoginFrame" OnClick="BtnSave_Click" />
                                                    </div>
                                            </div>

                                             </div>
                                        </div>

                                            
                                       
                                    </div>
                                    <div role="tabpanel" class="tab-pane fade in" id="change_password_settings">
                                        
                                            <div class="form-group">
                                                <label for="OldPassword" class="col-sm-3 control-label">Old Password</label>
                                                <div class="col-sm-9">
                                                    <div class="form-line">
<%--                                                        <input type="password" class="form-control" id="OldPassword" name="OldPassword" placeholder="Old Password" required>--%>
                                                        <asp:TextBox ID="txtOldPassword" runat="server" class="form-control" required TextMode="Password"></asp:TextBox>
                                                        </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="NewPassword" class="col-sm-3 control-label">New Password</label>
                                                <div class="col-sm-9">
                                                    <div class="form-line">
<%--                                                        <input type="password" class="form-control" id="NewPassword" name="NewPassword" placeholder="New Password" required>--%>
                                                        <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" required TextMode="Password"></asp:TextBox>
                                                        </div>
                                                    <asp:regularexpressionvalidator id="rev1" runat="server" controltovalidate="txtNewPassword" errormessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" validationexpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}" ForeColor="Red"></asp:regularexpressionvalidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="NewPasswordConfirm" class="col-sm-3 control-label">New Password (Confirm)</label>
                                                <div class="col-sm-9">
                                                    <div class="form-line">
<%--                                                        <input type="password" class="form-control" id="NewPasswordConfirm" name="NewPasswordConfirm" placeholder="New Password (Confirm)" required>--%>
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" required TextMode="Password"></asp:TextBox>
                                                        </div>
    <asp:CompareValidator id="comparePasswords"   runat="server"     ControlToCompare="txtNewPassword"
           ControlToValidate="txtConfirmPassword"    ErrorMessage="Your passwords do not match up!"    Display="Dynamic" Font-Names="Verdana" ForeColor="red" />                                                    </div>
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-offset-3 col-sm-9">
<%--                                                    <button type="submit" class="btn btn-danger">SUBMIT</button>--%>
                                        <asp:Button ID="BtnSave" class="btn btn-primary btn-lg m-l-15 waves-effect" runat="server" Width="100px" Text="Save" ValidationGroup="LoginFrame" OnClick="BtnSave_Click" />
                                                </div>
                                            </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

