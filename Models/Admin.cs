namespace BloodManagementSystem_API_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [StringLength(10)]
        public string AdminId { get; set; }

        [StringLength(10)]
        public string Adminpassword { get; set; }
    }
}
