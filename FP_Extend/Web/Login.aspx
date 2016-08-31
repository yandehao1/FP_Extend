<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RURO.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <link href="include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="include/js/jquery.cookie.js"></script>
    <link href="include/css/login.css" rel="stylesheet" />
    <title>Freezerpro插件</title>
    <script type="text/javascript">
        function isEmptyStr(str) {
            if (str == '' || str == null) {
                return true;
            } else {
                return false;
            }
        }
        function focusNext(nextName, evt, num, t) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);
            if (charCode == 13 || charCode == 3) {
                var nextobj = document.getElementById(nextName);
                if (num == 1 && isEmptyStr(t.value)) {
                    alert("请输入用户名！");
                    t.focus();
                    return false;
                }
                if (num == 2 && isEmptyStr(t.value)) {
                    alert("请输入密码！");
                    t.focus();
                    return false;
                }

                nextobj.focus();
                return false;
            }
            return true;
        }
        $(function () {
            $("#btnLogin").click(function () {
                var txtU = $("#<%=txtUsername.ClientID%>").val();
                if (isEmptyStr(txtU)) {
                    alert("请输入用户名！");
                    $("#<%=txtUsername.ClientID%>").focus();
                    return false;
                }
                var txtP = $("#<%=txtPass.ClientID%>").val();
                if (isEmptyStr(txtP)) {
                    alert("请输入密码！");
                    $("#<%=txtPass.ClientID%>").focus();
                    return false;
                }
            });
        })
    </script>
</head>
<body>
    <div id="login">
        <h1>Freezerpo插件登陆</h1>
        <form id="Form1" method="post" runat="server">
            <label>账号:</label>
            <asp:TextBox runat="server" class="nemo01" TabIndex="1" MaxLength="22" size="22" name="user" ID="txtUsername" onkeypress="return focusNext('txtPass', event,1,this)" />
            <br />
            <br />
            <label>密码:</label>
            <input name="user" type="password" class="nemo01" tabindex="1" size="22" maxlength="22" id="txtPass" runat="server" onkeypress="return focusNext('btnLogin', event,2,this)">
            <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
            <%--            <input type="text" required="required" placeholder="用户名" name="username" id="username"></input>
            <input type="password" required="required" placeholder="密码" name="password" id="password"></input>--%>
            <asp:Button ID="btnLogin" runat="server" Text="登陆" CssClass="but" OnClick="btnLogin_Click" />
            <%-- <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="Images/Login/btndenglu.jpg"></asp:ImageButton>--%>
        </form>
    </div>
</body>
</html>
