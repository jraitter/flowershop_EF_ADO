//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowerShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FlowerBouquet
    {
        public int FlowerBouquetID { get; set; }
        public int BouquetID { get; set; }
        public int FlowerID { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Bouquet Bouquet { get; set; }
        public virtual Flower Flower { get; set; }
    }
}