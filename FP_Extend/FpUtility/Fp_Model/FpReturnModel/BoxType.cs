namespace FpUtility.Fp_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoxType
    {
        /// <summary>
        /// �������ӵ�����
        /// </summary>
        public string id { get; set; }
        public  string  obj_id { get; set; }
        public string name { get; set; }
        public Nullable<int> width { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> coords { get; set; }
        public Nullable<int> inuse { get; set; }
    }
}
