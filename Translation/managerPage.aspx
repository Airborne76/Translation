<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managerPage.aspx.cs" Inherits="Translation.managerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ManagerPage</title>
     <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/WebService1.asmx" />
            </Services>
        </asp:ScriptManager>
    <div>
    <asp:Repeater ID="Repeaterprojects" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>username
                    </th>
                    <th>删除账号
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("username") %>
                </td>
                <td>
                    <input type="button" class="btn btn-danger" value="删除" name="<%# Eval("username") %>" onclick="deleteUser(this)" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="center-block">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" Text="上一页" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" Text="下一页" OnClick="ButtonNext_Click" />
    </div>
        <script>
            function deleteUser(dom){
                var username = dom.name;
                if (confirm("删除用户" + username + "?")) {
                    Translation.WebService1.deleteUser(username, function (result) {
                        alert("账号" + result + "已删除");
                        window.location.href = "managerPage.aspx";
                    }, function () {
                        console.log("error");
                    })
                }
            }
        </script>
    </div>
    </form>
</body>
</html>
