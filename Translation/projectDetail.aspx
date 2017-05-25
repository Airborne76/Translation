<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectDetail.aspx.cs" Inherits="Translation.projectDetail" %>

<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3>来自创建者<%=GetCreatorMessage().Rows[0][0] %></h3>
    <div class="panel panel-default">
        <div class="panel-body">
            <%=GetCreatorMessage().Rows[0][1] %>
        </div>
    </div>
    
    <strong class="text-left">贡献者：<% if (GetMembers() != null)
                                      {
                                          foreach (var member in GetMembers())
                                          {
                                              Response.Write(member.username + "（" + member.translationnumber + "）");
                                              Response.Write("&nbsp;&nbsp;&nbsp;");
                                          }
                                      }
                                      else
                                      {
                                          Response.Write("无");
                                      }
                                      %></strong>
    <asp:Repeater ID="Repeaterprojects" runat="server">
        <ItemTemplate>
            <div class="well">
                <div class="well well-sm">
                    <div>
                        <h5><i><%# Eval("key") %></i></h5>
                    </div>
                    <div>
                        <h3><%# Eval("text") %></h3>
                    </div>
                </div>
                <div class="<%# hasText(Eval("translatedText").ToString()) %>"">
                    <h5><%# Eval("username")%>于<%# Eval("updateTime")%></h5>
                    <div class="alert alert-success" role="alert"><h4><%# Eval("translatedText")%></h4></div>
                </div>                
                <div class="form-group">
                    <input id="Text1" type="text" autocomplete="off" class="form-control" placeholder="text"/>
                    <input id="Button1" type="button" value="projectdetail_submit_0" class="btn btn-success valueTranslate" onclick="submitText(this)" />
                    <span class="hidden"><%# Eval("textId")%></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%--AJAX测试--%>
    <script>
        function submitText(dom) {
            var username = "<%=username%>";
            var text = dom.previousSibling.previousSibling.value.replace(/(^\s*)|(\s*$)/g, "");
            var textId = dom.nextSibling.nextSibling.innerHTML;
            var d = new Date();
            var timeNow = d.getFullYear() + "/" + d.getMonth() + "/" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
            if (text != "") {
                //调用webservice内的方法
                Translation.WebService1.Submit(username, text, textId, timeNow, function (result) {
                    if (result == undefined) {
                        console.log("error");
                    } else {
                        showTranslationInfo(dom, result.Username, result.Text, result.Time);
                    }
                }, function () {
                    console.log("error");
                }
                                );
            }
            else {
                alert("请填写译文");
            }

        }
        //一些DOM操作
        function showTranslationInfo(dom, username, text, time) {
            var userinfoElement = dom.parentNode.previousSibling.previousSibling.childNodes[1];
            var translatedTextElement = userinfoElement.nextSibling.nextSibling.childNodes[0];
            translatedTextElement.innerHTML = text;
            userinfoElement.innerHTML = username + "于" + time;
            userinfoElement.parentNode.setAttribute("class", "well well-sm show");
            dom.previousSibling.previousSibling.value = "";
        }
    </script>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" CssClass="valueTranslate" Text="projectdetail_previous_0" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" CssClass="valueTranslate" Text="projectdetail_next_0" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
