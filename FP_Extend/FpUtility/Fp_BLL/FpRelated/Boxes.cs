using FpUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_BLL
{

    public class Boxes
    {
        //判断指定名称的盒子是否存在
        public static bool CheckBoxesByGetAll(Fp_Common.UnameAndPwd up, string id, string boxName)
        {
            List<Box> boxes = GetAll(up, id);
            if (boxes == null)
            {
                return false;
            }
            else
            {
                Box box = boxes.Where(a => a.name == boxName).FirstOrDefault();
                if (box == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 查找所有的盒子
        /// </summary>
        /// <param name="up"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Box> GetAll(Fp_Common.UnameAndPwd up, string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.boxes.ToString());
            dic.Add("id", id);
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Box> boxes = call.getdata<Box>("Boxes");
            return boxes;
        }
        /// <summary>
        /// 查找所有的盒子类型
        /// </summary>
        /// <param name="up"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<BoxType> GetAllBoxType(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.box_types.ToString());
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<BoxType> BoxType = call.getdata<BoxType>("BoxType");
            return BoxType;
        }
        /// <summary>
        /// 根据ID获样本盒
        /// </summary>
        /// <param name="up"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Box> GetAllBoxInfo(Fp_Common.UnameAndPwd up, string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.box_info.ToString());
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Box> Box = call.getdata<Box>("box_info");
            return Box;
        }
        /// <summary>
        ///  查询指定冰箱指定位置是否存在符合条件的盒子
        /// </summary>
        /// <param name="up">登陆账号</param>
        /// <param name="space">所需空间</param>
        /// <param name="freezer_name">冰箱名称</param>
        /// <returns></returns>
        public static string get_perfect_box(Fp_Common.UnameAndPwd up, string space, string freezer_name)
        {
            string resultStr = string.Empty;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.get_perfect_box.ToString());
            dic.Add("freezer_name", freezer_name);
            dic.Add("space", space);
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            resultStr = call.GetData();
            return resultStr;
        }
        /// <summary>
        /// 未知
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static List<Box> Get_prescan_box(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.prescan_box.ToString());
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Box> BoxType = call.getdata<Box>("Last_open_box");
            return BoxType;
        }
        /// <summary>
        /// 修改盒子视图
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static List<Box> Get_update_box_view(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.update_box_view.ToString());
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Box> BoxType = call.getdata<Box>("update_box_view");
            return BoxType;
        }
        /// <summary>
        /// 盒子里的小瓶列表
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static List<Box> Get_vials_box(Fp_Common.UnameAndPwd up,string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.vials_box.ToString());
            dic.Add("ID",id);
            dic.Add("show_empty", "true");
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Box> BoxType = call.getdata<Box>("vials_box");
            return BoxType;
        }
    }
}
