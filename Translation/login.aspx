<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Translation.LoginIn" %>
<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
        <asp:Label ID="Label3" runat="server" Text="用户名:"></asp:Label>
        
        <asp:TextBox ID="usernameTxt" runat="server"  autocomplete="off"></asp:TextBox>
<br />    
        <asp:Label ID="Label2" runat="server" Text="密码:  "></asp:Label>      
        <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>
<br />
        <asp:Button ID="login" runat="server" OnClick="login_Click" Text="登录" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="result"></asp:Label>
        <br />        
</asp:Content>
