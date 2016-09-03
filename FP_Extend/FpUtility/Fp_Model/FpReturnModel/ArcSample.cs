namespace FpUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 表示从冷冻室和垃圾箱中取出的样品，并将其移动到只读样品归档属性中
    /// </summary>
    public partial class ArcSample
    {
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string sample_source_name { get; set; }
        public string sample_type_name { get; set; }
        public string user_name { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string created_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string deletedby_uname { get; set; }
        public string userfields { get; set; }
    }
}
