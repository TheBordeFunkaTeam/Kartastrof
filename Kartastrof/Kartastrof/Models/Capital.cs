namespace Kartastrof.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Capital : DbContext
    {
        public Capital()
            : base("name=Capital")
        {
        }

        public virtual DbSet<Tbl_Capital> Tbl_Capital { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
