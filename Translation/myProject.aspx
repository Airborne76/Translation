<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myProject.aspx.cs" Inherits="Translation.myProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="<%=hasProject("bind") %>">
        <asp:Repeater ID="Repeaterprojects" runat="server">
            <ItemTemplate>
                <div class="textBlock">
                    <div>
                        <span><%# Eval("projectname") %></span>
                        <span><%# showRate(Eval("projectId").ToString()) %></span>
                    </div>
                    <div>
                        <span><%# Eval("createtime")%></span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Button ID="ButtonPrevious" runat="server" Text="后一页" OnClick="ButtonPrevious_Click" />
            <asp:Button ID="ButtonNext" runat="server" Text="前一页" OnClick="ButtonNext_Click" />
        </div>
    </div >
    <div class="<%=hasProject("tip") %>">
        <span>你还没有创建过任何项目</span>
    </div>   
    <asp:Label ID="Label2" runat="server" Text="项目名:"></asp:Label>
    <asp:TextBox ID="ProjectName" runat="server"></asp:TextBox>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="upload" runat="server" OnClick="upload_Click" Text="上传文件" />
    <br />
    <asp:Label ID="usermsg" runat="server" Text="MSG"></asp:Label>
</asp:Content>
