using FpUtility.Fp_Common;
using FpUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FpUtility.Fp_BLL
{
    /// <summary>
    /// 自定义字段
    /// </summary>
    public class UserFields
    {        //创建数据层对象

        #region 获取自定义字段集合 + public List<UserFields> UserFields()
        /// <summary>
        /// 获取自定义字段的集合
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static List<Fp_Model.UserFields> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.gen_token.ToString());
            Fp_DAL.CallApi call = new CallApi(dic);
            List<Fp_Model.UserFields> list = call.getdata<Fp_Model.UserFields>("UserFields");
            return list;
        }
        #endregion

    }
}
