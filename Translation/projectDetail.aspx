﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="projectDetail.aspx.cs" Inherits="Translation.projectDetail" %>
<%@ MasterType VirtualPath="~/main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeaterprojects" runat="server">
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
                    <input id="Text1" type="text" autocomplete="off"/>
                    <input id="Button1" type="button" value="button"  onclick="submitText(this)" />
                    <span class="hidden"><%# Eval("textId")%></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%--AJAX测试--%>
    <script>
        function submitText(dom) {
            var username="<%=username%>";
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
            var translatedTextElement = dom.parentNode.previousSibling.previousSibling.childNodes[1];
            var usernameElement = translatedTextElement.nextSibling.nextSibling;
            var updateTimeElement = usernameElement.nextSibling.nextSibling;
            translatedTextElement.innerHTML = text;
            usernameElement.innerHTML = username;
            updateTimeElement.innerHTML = time;
            dom.previousSibling.previousSibling.value = "";
        }
    </script>
    <div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonPrevious" runat="server" Text="后一页" OnClick="ButtonPrevious_Click" />
        <asp:Button ID="ButtonNext" runat="server" Text="前一页" OnClick="ButtonNext_Click" />
    </div>
</asp:Content>
