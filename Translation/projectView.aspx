<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectView.aspx.cs" Inherits="Translation.projectView" %>
<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="innerTranslate">projectview_title_0</h2>
    <asp:Repeater ID="Repeaterprojects" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th class="innerTranslate">projectview_table_0</th>                    
                    <th class="innerTranslate">projectview_table_1</th>
                    <th class="innerTranslate">projectview_table_2</th>
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
        <asp:Button ID="ButtonPrevious" CssClass="valueTranslate" runat="server" Text="projectview_previous_0" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" CssClass="valueTranslate" runat="server" Text="projectview_next_0" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
