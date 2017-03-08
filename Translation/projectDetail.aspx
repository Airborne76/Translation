<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectDetail.aspx.cs" Inherits="Translation.projectDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="Repeaterprojects" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>key
                    </th>
                    <th>text
                    </th>                   
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("key") %>
                </td>
                <td>
                    <%# Eval("text") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" Text="后一页" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" Text="前一页" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
