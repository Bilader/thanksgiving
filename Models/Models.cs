using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TurkeyBase.Models
{
    [Table("People")]
    public class Turk
    {
        
        [Column("uid")]
        [Key]
        public long Uid { get; set; }

        [Display(Name="National identifier")]
        [Column("national_identifier")]
        public long NationalIdentifier { get; set; }

        [Display(Name = "First name")]
        [Column("first")]
        public string First { get; set; }

        [Display(Name = "Last name")]
        [Column("last")]
        public string Last { get; set; }

        [Display(Name = "Mother's first name")]
        [Column("mother_first")]
        public string mother_first { get; set; }

        [Display(Name = "Father's first name")]
        [Column("father_first")]
        public string father_first { get; set; }

        [Display(Name = "Gender")]
        [Column("gender")]
        public string gender { get; set; }

        [Display(Name = "Birth city")]
        [Column("birth_city")]
        public string birth_city { get; set; }

        [Display(Name = "Date of birth")]
        [Column("date_of_birth")]
        public DateTime date_of_birth { get; set; }

        [Display(Name = "Registration city")]
        [Column("id_registration_city")]
        public string id_registration_city { get; set; }

        [Display(Name = "Registration district")]
        [Column("id_registration_district")]
        public string id_registration_district { get; set; }

        [Display(Name = "Address city")]
        [Column("address_city")]
        public string address_city { get; set; }

        [Display(Name = "Address district")]
        [Column("address_district")]
        public string address_district { get; set; }

        [Display(Name = "Address neighborhood")]
        [Column("address_neighborhood")]
        public string address_neighborhood { get; set; }

        [Display(Name = "Address street")]
        [Column("street_address")]
        public string street_address { get; set; }

        [Display(Name = "Door/entrance number")]
        [Column("door_or_entrance_number")]
        public string door_or_entrance_number { get; set; }

        [Display(Name = "Misc")]
        [Column("misc")]
        public string misc { get; set; }

        public byte Deleted { get; set; }
    }

    public class TurkList
    {

        [Column("uid")]
        [Key]
        public long Uid { get; set; }

        [Display(Name = "National identifier")]
        [Column("national_identifier")]
        public long NationalIdentifier { get; set; }

        [Display(Name = "First name")]
        [Column("first")]
        public string First { get; set; }

        [Display(Name = "Last name")]
        [Column("last")]
        public string Last { get; set; }

        [Display(Name = "Mother's first name")]
        [Column("mother_first")]
        public string mother_first { get; set; }

        [Display(Name = "Father's first name")]
        [Column("father_first")]
        public string father_first { get; set; }

        [Display(Name = "Date of birth")]
        [Column("date_of_birth")]
        public DateTime date_of_birth { get; set; }
    }

    public class Search
    {
        [Display(Name = "First name")]
        [MaxLength(70)]
        public string First { get; set; }
        [MaxLength(70)]
        [Display(Name = "Last name")]
        public string Last { get; set; }
        [Display(Name = "National identifier")]
        public long? NationalIdentifier { get; set; }
    }

   
    public class TurkeyContext : DbContext
    {
        public virtual DbSet<Turk> People { get; set; }

        public TurkeyContext() : base("DefaultConnection")
        {
            Database.SetInitializer<TurkeyContext>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.UseDatabaseNullSemantics = false;
            this.Database.Log = a => System.Diagnostics.Debug.WriteLine(a);
        }
    }
}