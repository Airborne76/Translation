<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectDetail.aspx.cs" Inherits="Translation.projectDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeaterprojects" runat="server">
        <%--<HeaderTemplate>
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

                <td>
                    <%# Eval("username") %>
                </td>
                <td>
                    <%# Eval("translatedText") %>
                </td>
                <td>
                    <%# Eval("updateTime") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>--%>
        <ItemTemplate>
            <div class="textBlock">
                <div>
                    
                    <span>key:</span>
                    <span><%# Eval("key") %></span>
                </div>
                <div>
                    <span>text:</span>
                    <span><%# Eval("text") %></span>
                </div>
                <div>
                    <span><%# Eval("translatedText")%></span>
                    <span><%# Eval("username")%></span>
                    <span><%# Eval("updateTime")%> </span>
                </div>
                <div>
                    <input id="Text1" type="text" />
                    <%--<asp:Button ID="Button" runat="server" Text="Button"   CommandArgument='<%# Eval("textId") %>' OnCommand="Submit"/>--%>
                    <input id="Button1" type="button" value="button"  onclick="submitText(this)"/>
                    <span class="hidden"><%# Eval("textId")%></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%--AJAX测试--%>
    <script>
        function submitText(dom) {
            var username = getCookie("username");
            var text = dom.previousSibling.previousSibling.value;
            var textId = dom.nextSibling.nextSibling.innerHTML;
            var d =new Date();
            var timeNow = d.getFullYear() + "/" + d.getMonth() + "/" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
            Translation.WebService1.Submit(username,text,textId,timeNow,function (result) {
                console.log(result);
            }, function () {
                console.log("error");
            }
                );
        }
        function getCookie(name) {
            var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            if (arr = document.cookie.match(reg))
                return unescape(arr[2]);
            else
                return null;
        }
    </script>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" Text="后一页" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" Text="前一页" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
