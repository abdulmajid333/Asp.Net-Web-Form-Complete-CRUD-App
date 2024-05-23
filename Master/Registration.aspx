<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Master.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table>

            <tr>
                <td>Name :</td>
                <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Email :</td>
                <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Password :</td>
                <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Department :</td>
                <td><asp:DropDownList ID="ddldept" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>Country :</td>
                <td><asp:DropDownList ID="ddlcy" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>Gender :</td>
                <td>
                    <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Hobbies :</td>
                <td><asp:CheckBoxList ID="cblh" runat="server" RepeatColumns="6">
                    <asp:ListItem Text="Cricket" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Drawing" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Music" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Reading" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Cooking" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Coding" Value="6"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>

            <tr>
                <td>Image Upload :</td>
                <td><asp:FileUpload ID="fuimage" runat="server" /></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Button ID="btnregister" runat="server" Text="Register" OnClick="btnr_Click" /></td>
            </tr>

            <tr>
                <td></td>
                <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
            </tr>

            

            <tr>
                <td></td>
                <td><asp:GridView ID="gvreg" runat="server" OnRowCommand="gvreg_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="User Id">
                            <ItemTemplate>
                                <%#Eval("rid") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <%#Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Gender">
                            <ItemTemplate>
                                <%#Eval("gender").ToString() == "1" ? "Male" : Eval("gender").ToString() == "2" ? "Female" : "Others" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Email">
                            <ItemTemplate>
                                <%#Eval("email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Password">
                            <ItemTemplate>
                                <%#Eval("password") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Department">
                            <ItemTemplate>
                                <%#Eval("dname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Country">
                            <ItemTemplate>
                                <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Hobbies">
                            <ItemTemplate>
                                <%#Eval("hobbies") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Image">
                            <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="70px" Height="50px" ImageUrl='<%#Eval("image" , "~/userpics{0}/") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                                <%#Eval("inserted_date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" BackColor="RoyalBlue" ForeColor="White" Width="70px" Height="20px" CommandName="A" CommandArgument='<%#Eval("rid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" BackColor="RoyalBlue" ForeColor="White" Width="70px" Height="20px" CommandName="B" CommandArgument='<%#Eval("rid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView></td>
            </tr>

    </table>
    </center>
</asp:Content>
