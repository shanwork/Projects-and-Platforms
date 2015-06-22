using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data_Entities
{
    namespace ReferenceData
    {
        public  class ReferenceTableInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReferenceContext>
        {
            protected override void Seed(ReferenceContext context)
            {
                var EffortCategoryList = new List<EffortCategory>
                {
                    new EffortCategory{
                            EffortCategoryName="Air Rescue", 
                            EffortCategoryDescription="Types where stranded or/and injured perons are airlifted. Examples helicopter rescue", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    },
                     new EffortCategory{
                            EffortCategoryName="Land rescue", 
                            EffortCategoryDescription="Types where stranded or/and injured perons are reached by land = can be by digging, auto, etc", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    },
                     new EffortCategory{
                            EffortCategoryName="Water rescue", 
                            EffortCategoryDescription="Types where stranded or/and injured perons are reached by water=boat, divers, submarine, etc", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    }
                    
                };
                EffortCategoryList.ForEach(s => context.EffortCategoryRefList.Add(s));
                context.SaveChanges();
               var EffortList = new List<Effort>
               {
                   new Effort{ EffortName="Helicopter Rescue", 
                        EffortDescription="Hover over rescue area, use winch to pull up injured",
                        EffortCategoryID =
                        (from EffortCategoryE in EffortCategoryList 
                            where EffortCategoryE.EffortCategoryName=="Air Rescue" select EffortCategoryE.EffortCategoryID).First() ,
                              EffortCategoryName= (from EffortCategoryE in EffortCategoryList 
                            where EffortCategoryE.EffortCategoryName=="Air Rescue" select EffortCategoryE.EffortCategoryName).First() ,
                                 Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                        
                   },
                   new Effort{EffortName="STOL Air Rescue", 
                        EffortDescription="Using rugged aircraft where conditions are too extreme for choppers  ",
                        EffortCategoryID =
                        (from EffortCategoryE in EffortCategoryList 
                            where EffortCategoryE.EffortCategoryName=="Air Rescue" select EffortCategoryE.EffortCategoryID).First() ,
                       EffortCategoryName= (from EffortCategoryE in EffortCategoryList 
                            where EffortCategoryE.EffortCategoryName=="Air Rescue" select EffortCategoryE.EffortCategoryName).First() ,
                                 Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                        
                   }
               };
               EffortList.ForEach(s => context.EffortRefList.Add(s));
               context.SaveChanges();
               var EffortStepList = new List<EffortSteps>
                {
                    new EffortSteps{ 
                        EffortStepName="RoutePlanned", 
                        EffortStepDescription="Quick route plan based on weather and terrain",
                        EffortStepSequence=1,
                        EffortName=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortName).First() ,
                    EffortID=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortID).First() ,
                             Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                    },
                     new EffortSteps{ 
                        EffortStepName="Flight", 
                        EffortStepDescription="Actual flight",
                        EffortStepSequence=2,
                        EffortName=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortName).First() ,
                    EffortID=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortID).First() ,
                             Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                    },
                    
                     new EffortSteps{ 
                        EffortStepName="Medics Lowered", 
                        EffortStepDescription="Did the injured/affected need medical attention?",
                        EffortStepSequence=3,
                        EffortName=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortName).First() ,
                    EffortID=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortID).First() ,
                             Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                    },
                          
                     new EffortSteps{ 
                        EffortStepName="Party Winched up", 
                        EffortStepDescription="Loaded into chopper",
                        EffortStepSequence=4,
                        EffortName=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortName).First() ,
                    EffortID=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortID).First() ,
                             Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                    },
                     new EffortSteps{ 
                        EffortStepName="Party dropped off", 
                        EffortStepDescription="Hospital, refugee camp or further transportation",
                        EffortStepSequence=5,
                        EffortName=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortName).First() ,
                    EffortID=(from EffortE in EffortList 
                            where EffortE.EffortName=="Helicopter Rescue" select EffortE.EffortID).First() ,
                             Added=DateTime.Now,
                          
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
                    }
                };
               EffortStepList.ForEach(s => context.EffortStepsRefList.Add(s));
               context.SaveChanges();
               var TeamCategoryList = new List<TeamCategory>
                {
                    new TeamCategory{
                            TeamCategoryName="First Aid and Trauma", 
                            TeamCategoryDescription="Administering emergency first aid, and attending to urgent, critical life threatening issues", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    },
                     new TeamCategory{
                            TeamCategoryName="Search, Extract and rescue", 
                            TeamCategoryDescription="Responsible for finding humans and animals, seeing their condition and transporting them", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    },
                    new TeamCategory{
                            TeamCategoryName="Admin and Dispatch", 
                            TeamCategoryDescription="Administering Teams coordination. Command post kind of responsibilities", 
                            Added=DateTime.Now,
                            IsActive=true,
                            Updated=DateTime.Now,
                            Inactivated=DateTime.MaxValue
           
                    }
                    
                };
               TeamCategoryList.ForEach(s => context.TeamCategoryRefList.Add(s));
               context.SaveChanges();
            }
        }
    }
}
