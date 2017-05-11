<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Translation.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>创建新账户</h2>
    <br />
    <div class="row">
        <div class="col-lg-3">
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon1">用户名</span>
                <asp:TextBox ID="username" CssClass="form-control" aria-describedby="basic-addon1" placeholder="Username" runat="server" autocomplete="off"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon2">密码</span>
                <asp:TextBox ID="password1" runat="server" CssClass="form-control" aria-describedby="basic-addon1" autocomplete="off"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <span class="input-group-addon" id="basic-addon3">确认密码</span>
                <asp:TextBox ID="password2" runat="server" CssClass="form-control" aria-describedby="basic-addon1" autocomplete="off"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="userRegister" runat="server" CssClass="btn btn-success" OnClick="userRegister_Click" Text="注册" />
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
