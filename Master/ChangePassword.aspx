<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Master.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table>
            <tr>
                <td>Old Password :</td>
                <td><asp:TextBox ID="txtop" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>New Password :</td>
                <td><asp:TextBox ID="txtnp" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Confirm New Password :</td>
                <td><asp:TextBox ID="txtcnp" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Button ID="btncp" runat="server" Text="Change Password" OnClick="btncp_Click" /></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
            </tr>
        </table>
    </center>
</asp:Content>
