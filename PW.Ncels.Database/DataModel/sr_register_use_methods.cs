namespace PW.Ncels.Database.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sr_register_use_methods
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int register_id { get; set; }

        public int use_method_id { get; set; }

        public virtual sr_register_drugs sr_register_drugs { get; set; }

        public virtual sr_use_methods sr_use_methods { get; set; }
    }
}
