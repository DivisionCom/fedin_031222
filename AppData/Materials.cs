//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fedin_031222.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        public int id_materials { get; set; }
        public string materials_name { get; set; }
        public int materials_count { get; set; }
        public int materials_category { get; set; }
        public int materials_providers { get; set; }
        public int materials_manufacturer { get; set; }
        public int materials_available { get; set; }
        public string materials_description { get; set; }
        public string materials_photo { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Providers Providers { get; set; }
    }
}