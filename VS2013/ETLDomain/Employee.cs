using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETLDomain
{
    public class Employee:Entity
    {
        [Required]
        [Display(Name="First Name")]        
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Suffix")]
        public string NameSuffix { get; set; }
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }
        [Display(Name = "Former Name")]
        public string FormerName { get; set; }
        
        public Address Address { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataTypeAttribute(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }


        [NotMapped]
        public int Age { get { return DateTime.Today.Year - DOB.Year; } }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }        
        [Required]
        [Display(Name = "Martial Status")]
        public MaritalStatus MaritalStatus { get; set; }
        [Display(Name = "Ethnic Group")]
        public string EthnicGroup { get; set; }
        [Display(Name = "Disabled?")]
        public bool IsDisabled { get; set; }
        [Display(Name = "Disabled Vet?")]
        public bool IsDisabledVet { get; set; }
        [Display(Name = "Military Status")]
        public string MilitaryStatus { get; set; }
        [Display(Name = "Highest Education Level")]
        public string HighestEducationLevel { get; set; }
        [Display(Name = "Primary Citizenship Country")]
        public string CitizenshipCountry { get; set; }
        [Display(Name = "Secondary Citizenship Country")]
        public string CitizenshipCountry2 { get; set; }
        [Display(Name = "Is eligible to work in U.S.")]
        public bool IsUSWorkEligible { get; set; }
        [Display(Name = "Visa Number")]
        public string VisaNumber { get; set; }
        [Display(Name = "Visa Expiration Date")]
        [DataTypeAttribute(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime VisaExpireDate { get; set; }
        [Display(Name = "Passport Expiration Date")]
        [DataTypeAttribute(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PassportExpDate { get; set; }
        [Display(Name = "Passport Country")]
        public string PassportCountry { get; set; }
        [Display(Name = "Full Time Student?")]
        public bool IsFullTimeStudent { get; set; }
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
        [Display(Name = "SSN")]
        [Required(ErrorMessage = "SSN is Required")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string SSN { get; set; }

        //Navigation Fields
        public virtual List<Compensation> CompHistory { get; set; }

        public Employee()
        { }
    }
}