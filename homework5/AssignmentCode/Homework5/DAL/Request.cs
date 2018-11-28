namespace Homework5.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int RequestId { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string ApartmentName { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitNumber { get; set; }

        [Required]
        [StringLength(2000)]
        public string DescriptionOfIssue { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool EntrancePermission { get; set; }
    }
}
