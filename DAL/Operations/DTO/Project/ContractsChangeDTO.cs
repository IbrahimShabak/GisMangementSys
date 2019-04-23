using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Projects;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Project
{
    [DataContract]
    public class ContractsChangeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رمز التعريف")]
        [Key]
        public int ID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public int ProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "وصف التغيير ")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ChangedDescription { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "القيمة في العقد")]
        
        public Nullable<decimal> OriginalAmount { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "القيمة الجديدة")]
       
        public Nullable<decimal> NewAmount { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        public int ProjectTBLProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المشروع")]
        public string ProjectTBLProjectNumber { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "مسمى المشروع")]
        public string ProjectTBLArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Project Name")]
        public string ProjectTBLEnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ بدء المشروع")]
        
        public Nullable<System.DateTime> ProjectTBLStartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "قيمة العقد")]
      
        public Nullable<decimal> ProjectTBLMainContractAmount { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        
        public Nullable<System.DateTime> ProjectTBLEndDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "مشروع جاري")]
        
        public Nullable<bool> ProjectTBLIsActiveProject { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "التغيرات المالية للمشاريع")]
        
        public IEnumerable<ContractsChangeDTO> ProjectTBLContractsChanges { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الشركاء و العملاء")]
        
        public IEnumerable<OrganizationsProjectDTO> ProjectTBLOrganizationsProjects { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "موظفوا المشاريع")]
       
        public IEnumerable<ProjectEmployeeDTO> ProjectTBLProjectEmployees { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المراحل الفنية للمشروعات")]
       
        public IEnumerable<StageProjectDTO> ProjectTBLStageProjects { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static ContractsChangeMapper Mapper = new ContractsChangeMapper();
        public ContractsChange GetOriginal(ContractsChange model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ContractsChangeDTO GetDTO(ContractsChange model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class ContractsChangeMapper : MapperBase<ContractsChange, ContractsChangeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ContractsChange, ContractsChangeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ContractsChange, ContractsChangeDTO>>)(p => new ContractsChangeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ProjectID = p.ProjectID,
                    ChangedDescription = p.ChangedDescription,
                    OriginalAmount = p.OriginalAmount,
                    NewAmount = p.NewAmount,
                    ProjectTBLProjectID = p.ProjectTBL != null ? p.ProjectTBL.ProjectID : default(int),
                    ProjectTBLProjectNumber = p.ProjectTBL != null ? p.ProjectTBL.ProjectNumber : default(string),
                    ProjectTBLArName = p.ProjectTBL != null ? p.ProjectTBL.ArName : default(string),
                    ProjectTBLEnName = p.ProjectTBL != null ? p.ProjectTBL.EnName : default(string),
                    ProjectTBLStartDate = p.ProjectTBL != null ? p.ProjectTBL.StartDate : default(Nullable<System.DateTime>),
                    ProjectTBLMainContractAmount = p.ProjectTBL != null ? p.ProjectTBL.MainContractAmount : default(Nullable<decimal>),
                    ProjectTBLEndDate = p.ProjectTBL != null ? p.ProjectTBL.EndDate : default(Nullable<System.DateTime>),
                    ProjectTBLIsActiveProject = p.ProjectTBL != null ? p.ProjectTBL.IsActiveProject : default(Nullable<bool>),
                    //ContractsChanges = p.ProjectTBL.ContractsChanges.AsQueryable().Select(this._contractsChangeMapper.SelectorExpression),
                    //OrganizationsProjects = p.ProjectTBL.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression),
                    //ProjectEmployees = p.ProjectTBL.ProjectEmployees.AsQueryable().Select(this._projectEmployeeMapper.SelectorExpression),
                    //StageProjects = p.ProjectTBL.StageProjects.AsQueryable().Select(this._stageProjectMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(ContractsChangeDTO dto, ContractsChange model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ProjectID = dto.ProjectID;
            model.ChangedDescription = dto.ChangedDescription;
            model.OriginalAmount = dto.OriginalAmount;
            model.NewAmount = dto.NewAmount;

        }
    }
}
