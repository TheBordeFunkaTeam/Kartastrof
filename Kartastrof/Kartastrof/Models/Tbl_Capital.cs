namespace Kartastrof.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Capital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ca_Id { get; set; }

        public string Ca_Name { get; set; }

        public int? Ca_Longitude { get; set; }

        public int? Ca_Latitude { get; set; }
    }
}
