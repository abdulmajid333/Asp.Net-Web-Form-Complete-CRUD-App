<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Master.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table>
            <tr>
                <td>User id :</td>
                <td><asp:TextBox ID="txtuid" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>User Pasword :</td>
                <td><asp:TextBox ID="txtupassword" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" /></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
            </tr>
        </table>
    </center>
</asp:Content>
