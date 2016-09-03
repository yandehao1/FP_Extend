using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;//验证导入
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace RURO.Common
{
    /// <summary>
    /// JSON操作类
    /// </summary>
    public class FpJsonHelper
    {
        /// <summary>
        /// 将对象序列化为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 将JSON字符串反序列化为object
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object DeserializeObjectStr(string str)
        {
            return JsonConvert.DeserializeObject(str);
        }
        /// <summary>
        /// 将字符串转换为JObject对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static JObject JObjectForStr(string str) 
        {
            return JObject.Parse(str);
        }
        /// <summary>
        /// 将JSON字符串转换为CLASS类型
        /// </summary>
        /// <typeparam name="T">待转换的对象类型</typeparam>
        /// <param name="jsonStr">字符串</param>
        /// <returns>对象</returns>
        public static T JsonStrToObject<T>(string jsonStr) where T : class
        {
            return JsonConvert.DeserializeObject(jsonStr, typeof(T)) as T;
        }
        /// <summary>
        /// 将API返回的json格式的字符串中对象转换成list集合
        /// </summary>
        /// <typeparam name="T">要转换成的对象集合如：UserFields对象</typeparam>
        /// <param name="str">该对象在api字符串中的标识如：UserFields[{"obj_id":86,"id":86,"display_name":"中心编码".....}]</param>
        /// <param name="json">传入api返回的字符串</param>
        /// <returns>转换成的对象的list集合</returns>
        public static List<T> JObjectToList<T>(string str, string json)
        {
            List<T> list = new List<T>();
            try
            {
                JObject jObject = JObject.Parse(json);
                JArray jArray = (JArray)jObject[str];
                for (int i = 0; i < jArray.Count; i++)
                {
                    T t = JsonConvert.DeserializeObject<T>(jArray[i].ToString());
                    list.Add(t);
                }
            }
            catch (Exception)
            {
                list.Clear();
            }

            return list;
        }
        /// <summary>
        /// 将键值对格式的字符串转换成Dictionary
        /// </summary>
        /// <typeparam name="T">key的类型</typeparam>
        /// <typeparam name="K">value的类型</typeparam>
        /// <param name="json">传入的json格式的字符串</param>
        /// <returns>返回Dictionary</returns>
        public static Dictionary<T, K> JsonStrToDictionary<T, K>(string json)
        {

            Dictionary<T, K> dictionary = new Dictionary<T, K>();
            try
            {
                dictionary = JsonConvert.DeserializeObject<Dictionary<T, K>>(json);
            }
            catch (Exception)
            {
                dictionary.Clear();
            }
            return dictionary;
        }
        /// <summary>
        /// 将Dictionary转换长JSON格式的字符串
        /// </summary>
        /// <typeparam name="T">Dictionary 键的类型</typeparam>
        /// <typeparam name="K">Dictionary 值的类型</typeparam>
        /// <param name="dic">Dictionary</param>
        /// <returns>JSON格式的字符串</returns>
        public static string DictionaryToJsonString<T, K>(Dictionary<T, K> dic)
        {
            string result = "";
            try
            {
                result = JsonConvert.SerializeObject(dic);
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        #region XML简单操作
        /// <summary>
        /// 将xml字符串转换为Json字符串
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string XMLStrForJsonStr(string xml)
        {
            try
            {
                string strjson = "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                strjson = JsonConvert.SerializeXmlNode(doc);
                return strjson;
            }
            catch (Exception ex) 
            {
                return "";
            }
        }
        /// <summary>
        /// 将xml对象转换为Json字符串
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string XmlDocumentForJsonStr(XmlDocument doc)
        {
            try
            {
                string strjson = "";
                strjson = JsonConvert.SerializeXmlNode(doc);
                return strjson;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// 将json字符串转换为XML对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static XmlDocument JsonStrForXmlDocument(string str) 
        {
            return (XmlDocument)JsonConvert.DeserializeXmlNode(str);
        }
        #endregion

    }
}