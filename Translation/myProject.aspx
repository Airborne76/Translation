<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myProject.aspx.cs" Inherits="Translation.myProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="upload" runat="server" OnClick="upload_Click" Text="上传文件" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="MSG"></asp:Label>
</asp:Content>
