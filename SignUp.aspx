<%@ Page Title="" Language="C#" MasterPageFile="~/FilmMaster.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<%-- Add content controls here --%>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <section id="Login" class="pad-x2">
        <div class="container">
            <div class="row"> 
                <div class="col-sm-8 col-sm-offset-2 text-center margin-30 wow fadeIn" data-wow-delay="0.6s">
                    <h1>Sign Up</h1>
                </div>
                <div class="col-sm-8 col-md-offset-2">
                    <asp:TextBox ID="Email" runat="server" TextMode="Email" placeholder="Email" AutoCompleteType="Email" Type="Email" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^([0-9a-z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ControlToValidate="Email" Visible="False"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="ConfirmEmail" runat="server" TextMode="Email" placeholder="Confirm Email" AutoCompleteType="Email" CssClass="form-control" Type="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ValidationExpression="^([0-9a-z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ControlToValidate="Email" Visible="False"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="FirstName" runat="server" placeholder="First Name" AutoCompleteType="FirstName" Type="FirstName" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="FirstName" Visible="False" ValidationExpression="^[A-Z][a-z]+$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="SecondName" runat="server" placeholder="Second Name" AutoCompleteType="LastName" Type="LastName" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="LastName" Visible="False" ValidationExpression="^[A-Z][a-z]+$"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Password" Type="Password" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" Text="Sign Up" />
                    <a href="SignIn.aspx" class="lead wow fadeIn">Already have an account?</a>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

            </div>

        </div>
    </section> 
</asp:Content>

