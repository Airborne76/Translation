<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Translation.LoginIn" %>

<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>登录</h2>
    <br />
    <div class="row">
        <div class="col-lg-3">
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon1">用户名</span>
                <asp:TextBox CssClass="form-control" ID="usernameTxt" runat="server" placeholder="Username" aria-describedby="basic-addon1" autocomplete="off"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon2">密码 </span>
                <asp:TextBox CssClass="form-control" ID="passwordTxt" runat="server" TextMode="Password" aria-describedby="basic-addon1" autocomplete="off"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="login" CssClass="btn btn-success" runat="server" OnClick="login_Click" Text="登录" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
