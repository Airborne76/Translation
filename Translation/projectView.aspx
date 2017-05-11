<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectView.aspx.cs" Inherits="Translation.projectView" %>
<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>项目浏览</h2>
    <asp:Repeater ID="Repeaterprojects" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>项目名
                    </th>
                    <th>创建者
                    </th>
                    <th>创建时间
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>                 
                  <a runat="server" href='<%# getUrl(Eval("projectId").ToString())%>'><%# Eval("projectname") %></a>  
                </td>
                <td>
                    <%# Eval("username") %>
                </td>
                <td>
                    <%# Eval("createtime") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" Text="上一页" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" Text="下一页" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
