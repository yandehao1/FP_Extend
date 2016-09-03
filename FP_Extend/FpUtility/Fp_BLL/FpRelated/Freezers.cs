using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FpUtility.Fp_Model;

namespace FpUtility.Fp_BLL
{
    public class Freezers
    {
        //{"Total":1,"Freezers":[{"id":1,"name":"001号冰箱","description":"001号冰箱","access":0,"subdivisions":4,"boxes":0,"barcode_tag":"7000000001","rfid_tag":"355AB1CBC000007000000001"}]}
        //获取冰箱结构
        /// <summary>
        /// 获取冰箱列表
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static List<Fp_Model.Freezer> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.freezers.ToString());
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Freezer> list = call.getdata<Freezer>("Freezers");
            return list;
        }
        /// <summary>
        /// 根据冰箱名称返回冰箱
        /// </summary>
        /// <param name="up"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Freezer GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            Fp_Model.Freezer freezer = GetAll(up).Where<Fp_Model.Freezer>(a => a.name == name).FirstOrDefault();
            return freezer;
        }
        //dic.Add("method", Fp_Common.FpMethod.freezer_samples.ToString());
    }
}
