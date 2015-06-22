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
        /// Set of classes used as reference pertaining to sets/sequences of actions which
        /// are classified, or named Efforts
        /// We have the following classes
        /// EffortCategory = e.g. Aerial Rescue
        /// Effort e.g. HelicopterRescue
        /// EffortSteps - 
        ///     e.g. 
        ///     1. Flight and locate
        ///     2. Winch Lowered with Rescue Person 
        ///     3. Person Strapped 
        ///     4. Winch raised with Person 
        ///     5 Winch lowered for Rescue person and raised
        ///     6 Fly back
        /// </summary>
        public class EffortCategory : TableTemplate
        {
            [Key]
            public int EffortCategoryID { get; set; }
            public string EffortCategoryName { get; set; }
            public string EffortCategoryDescription { get; set; }
        }
        
        public class Effort : TableTemplate
        {
            [Key]
            public int EffortID { get; set; }
            public string EffortName { get; set; }
            public string EffortDescription { get; set; }
            public int EffortCategoryID { get; set; }
            public virtual string EffortCategoryName { get; set; }

            public virtual ICollection<EffortCategory> EffortCategories { get; set; }
        }
        public class EffortSteps : TableTemplate
        {
            [Key]
            public int EffortStepID { get; set; }
            public string EffortStepName { get; set; }
            public string EffortStepDescription { get; set; }
            public int EffortStepSequence { get; set; }
            public virtual int EffortID { get; set; }
            public virtual string EffortName { get; set; }

        }

        // DbContext Classx
        public class ReferenceContext : DbContext
        {
            public DbSet<EffortCategory> EffortCategoryRefList { get; set; }
            public DbSet<Effort> EffortRefList { get; set; }
            public DbSet<EffortSteps> EffortStepsRefList { get; set; }
            public DbSet<TeamCategory> TeamCategoryRefList { get; set; }
            public DbSet<Role> RoleRefList { get; set; }
            public DbSet<RoleQualification> RoleQualificationRefList { get; set; }
            public DbSet<RoleToQualificationMapping> RoleToQualificationMappingRefList { get; set; }
            public DbSet<EquipmentCategory> EquipmentCategoryRefList { get; set; }
        }
    }
}
