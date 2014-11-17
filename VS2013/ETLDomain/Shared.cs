using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETLDomain
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum MaritalStatus
    {
        Single,
        Married
    }
    public enum CompFrequency
    {
        Hourly,
        Weekly
    }
    public class Entity
    {
        public int ID { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UserModified { get; set; }

    }
    public class DDEntity
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }



    public class Address
    {
        [StringLength(100)]
        [Column("Street1")]        
        public string Street1 { get; set; }
        [StringLength(100)]
        [Column("Street2")]
        public string Street2 { get; set; }
        [StringLength(100)]
        [Column("Street3")]
        public string Street3 { get; set; }
        [StringLength(70)]
        [Column("City")]
        public string City { get; set; }
        [StringLength(2)]
        [Column("State")]
        public string State { get; set; }
        [StringLength(10)]
        [Column("Zip")]
        public string Zip { get; set; }
        [StringLength(2)]
        [Column("Country")]
        public string Country { get; set; }
    }
}