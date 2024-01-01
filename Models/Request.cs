namespace BloodManagementSystem_API_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestId { get; set; }

        public int? SeekerId { get; set; }

        public int? DonorId { get; set; }

        [StringLength(10)]
        public string BloodGroup { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Seeker Seeker { get; set; }
    }
}
