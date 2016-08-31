using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RURO.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CheckLoginByCookie())
                {
                    //Response.Redirect("ExtendPage.aspx");
                    Response.Redirect("index.aspx");
                }
            }
            //登陆
            //验证登陆
            //跳转扩展页面
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region 检查登陆

            string userName = txtUsername.Text.ToString().Trim();
            string passWord =RURO.Common.PageValidate.InputText(txtPass.Value.Trim(), 30);
            //获取当前科室存入cookie
            //string depar = department.SelectedValue;
            //DateTime datetime = DateTime.Now.AddDays(7.0);
            //Common.CookieHelper.SetCookie(userName+"department", Common.DEncrypt.DESEncrypt.Encrypt(depar), datetime);
            if (checkToken(userName, passWord))
            {
                //清除cookie
                LoginOut();
                //重写cookie
                WriteCookie(userName, passWord);
                // Response.Redirect("ExtendPage.aspx");
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMsg.Text = "请检查账号密码";
                // Response.Redirect("Login.aspx");
            }

            #endregion 检查登陆
        }
        public bool CheckLoginByCookie()
        {
            string userName =RURO.Common.CookieHelper.GetCookieValue("username");
            string temPass =RURO.Common.CookieHelper.GetCookieValue("password");
            if (!string.IsNullOrEmpty(userName) && userName != "null" && !string.IsNullOrEmpty(temPass) && temPass != "null")
            {
                string passWord = string.Empty;
                try
                {
                    passWord = Common.DEncrypt.DESEncrypt.Decrypt(temPass);
                }
                catch (Exception ex)
                {
                    RURO.Common.LogHelper.WriteError(ex);
                }
                return checkToken(userName, passWord);
            }
            else
            {
                return false;
            }
        }

        private void LoginOut()
        {
            Common.CookieHelper.ClearCookie("username");
            Common.CookieHelper.ClearCookie("password");
        }

        private bool checkToken(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                FpUtility.Fp_Common.UnameAndPwd up = new FpUtility.Fp_Common.UnameAndPwd(username, password);
                FpUtility.Fp_BLL.Token token = new FpUtility.Fp_BLL.Token(up);
                bool b = token.checkAuth_Token();
                return b;
            }
        }

        //写入cookie
        private void WriteCookie(string username, string password)
        {
            string DEnPassword =RURO.Common.DEncrypt.DESEncrypt.Encrypt(password);
            HttpCookie passwordcookie = new HttpCookie("password");
            passwordcookie.Value = DEnPassword;
            Response.Cookies.Add(passwordcookie);
            Common.CookieHelper.SetCookie("username", username);
            Common.CookieHelper.SetCookie("password", DEnPassword);
        }
    }
}