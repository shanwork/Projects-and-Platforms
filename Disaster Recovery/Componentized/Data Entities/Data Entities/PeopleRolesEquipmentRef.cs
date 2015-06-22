using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Data_Entities
{
    namespace ReferenceData
    {
        /// <summary>
        /// Add Category 'multiple'
        /// </summary>
        public class TeamCategory:TableTemplate
        {
            [Key]
            public int TeamCategoryID { get; set; }
            public string TeamCategoryName { get; set; }
            public string TeamCategoryDescription { get; set; }
        }
        
        public class Role:TableTemplate
        {
            [Key]
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
        }
        public class RoleQualification:TableTemplate
        {
            [Key]
            public int RoleQualificationID { get; set; }
            public string RoleQualificationName { get; set; }
            public string RoleQualificationDescription { get; set; }
            public bool Mandatory { get; set; }
         //  public virtual int RoleID{ get; set; } make a mapping table - see below
        }

        public class RoleToQualificationMapping:TableTemplate // do we need the date created updated?
        {
            [Key]
            public int RoleToQualificationMappingID { get; set; }
            public virtual int RoleID { get; set; }
            public virtual int RoleQualificationID { get; set; }
        }

        public class EquipmentCategory : TableTemplate
        {
            [Key]
            public int EquipmentCategoryID { get; set; }
            public string EquipmentCategoryName { get; set; }
            public string EquipmentCategoryDescription { get; set; }
        }
        // DbContext Class
        public class ReferenceContext2 : DbContext
        {
            public DbSet<TeamCategory> TeamCategoryRefList { get; set; }
            public DbSet<Role> RoleRefList { get; set; }
            public DbSet<RoleQualification> RoleQualificationRefList { get; set; }
            public DbSet<RoleToQualificationMapping> RoleToQualificationMappingRefList { get; set; }
            public DbSet<EquipmentCategory> EquipmentCategoryRefList { get; set; }

        }
    }
}
