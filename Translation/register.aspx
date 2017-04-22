<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Translation.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>创建新账户</h4>
    <div>
        <asp:Label ID="Label1" runat="server" Text="用户名&nbsp;:"></asp:Label>
        <asp:TextBox ID="username" runat="server" autocomplete="off"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="密码&nbsp;&nbsp;:"></asp:Label>
        <asp:TextBox ID="password1" runat="server" autocomplete="off"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="确认密码:"></asp:Label>
        <asp:TextBox ID="password2" runat="server" autocomplete="off"></asp:TextBox>
    </div>
    <asp:Button ID="userRegister" runat="server" OnClick="userRegister_Click" Text="注册" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="info"></asp:Label>
    <br />
</asp:Content>
