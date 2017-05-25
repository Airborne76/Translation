<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myProject.aspx.cs" Inherits="Translation.myProject" %>

<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="myproject_exit_0" CssClass="btn btn-warning pull-right valueTranslate" OnClick="Button1_Click" />
    <h2><%= getUsername()%>的项目</h2>
    <br />
    <div class="<%=hasProject("bind") %>">
        <asp:Repeater ID="Repeaterprojects" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <tr>
                        <th class="innerTranslate">myproject_table_0</th>
                        <th class="innerTranslate">myproject_table_1</th>
                        <th class="innerTranslate">myproject_table_2</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><span><%# Eval("projectname") %></span>
                        <div>
                            <div class="progress">
                                <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: <%# showRate(Eval("projectId").ToString()) %>;">
                                    <%# showRate(Eval("projectId").ToString()) %>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <span><%# Eval("createtime")%></span>
                    </td>
                    <td>
                        <input type="button" name="<%# Eval("projectId") %>" class="btn btn-success valueTranslate" value="myproject_download_0" onclick="getFile(this)" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Button ID="ButtonPrevious" CssClass="valueTranslate" runat="server" Text="myproject_previous_0" OnClick="ButtonPrevious_Click" />
            <asp:Button ID="ButtonNext" runat="server" CssClass="valueTranslate" Text="myproject_next_0" OnClick="ButtonNext_Click" />
        </div>
    </div>
    <div class="<%=hasProject("tip") %>">
        <span class="innerTranslate">myproject_noproject_0</span>
    </div>
    <%--AJAX测试--%>
    <script>
        function getFile(dom) {
            var projectId = dom.name;
            if (projectId != "") {
                Translation.WebService1.getFile(projectId, function (result) {
                    download(result);
                }, function () {
                    console.log("error");
                });
            }
        }
        function download(projectId) {
            var a = document.createElement('a');
            a.href = "DownloadFile/" + projectId + ".json";
            a.download = projectId + ".json";
            a.click();
        }
    </script>
    <br />
    <h3 class="innerTranslate">myproject_upload_0</h3>
    <div class="row">
        <div class="col-lg-3">
            <div class="input-group">
                <span class="input-group-addon innerTranslate" id="basic-addon1">myproject_projectname_0</span>
                <asp:TextBox CssClass="form-control" ID="ProjectName" runat="server" placeholder="ProjectName" aria-describedby="basic-addon1" autocomplete="off"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <strong class="innerTranslate">myproject_introduce_0</strong>
    <textarea id="TextArea1" class="form-control" cols="20" runat="server" rows="3"></textarea>
    <br />
    <asp:Button ID="upload" CssClass="btn btn-success valueTranslate" runat="server" OnClick="upload_Click" Text="myproject_uploadfile_0" />
    <br />
    <asp:Label ID="usermsg" runat="server" Text=""></asp:Label>
</asp:Content>
