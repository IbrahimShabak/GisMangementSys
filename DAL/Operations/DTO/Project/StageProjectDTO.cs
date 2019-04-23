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
    public class StageProjectDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المرحلة")]
        [Key]
        public int StageID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public int ProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم المرحلة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string StageArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Stage Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string StageEnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ البدء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> EndDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "القيمة بالريال")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<decimal> StageBudget { get; set; }
        [DataMember]
        public IEnumerable<DeliverableStageDTO> DeliverableStages { get; set; }
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
        [Display(Name = "تاريخ البدء")]
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
        [DataMember]
        public IEnumerable<ContractsChangeDTO> ProjectTBLContractsChanges { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> ProjectTBLOrganizationsProjects { get; set; }
        [DataMember]
        public IEnumerable<ProjectEmployeeDTO> ProjectTBLProjectEmployees { get; set; }
        [DataMember]
        public IEnumerable<StageProjectDTO> ProjectTBLStageProjects { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static StageProjectMapper Mapper = new StageProjectMapper();
        public StageProject GetOriginal(StageProject model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static StageProjectDTO GetDTO(StageProject model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class StageProjectMapper : MapperBase<StageProject, StageProjectDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private DeliverableStageMapper _deliverableStageMapper = new DeliverableStageMapper();
        public override Expression<Func<StageProject, StageProjectDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<StageProject, StageProjectDTO>>)(p => new StageProjectDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    StageID = p.StageID,
                    ProjectID = p.ProjectID,
                    StageArName = p.StageArName,
                    StageEnName = p.StageEnName,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    StageBudget = p.StageBudget,
                    DeliverableStages = p.DeliverableStages.AsQueryable().Select(this._deliverableStageMapper.SelectorExpression),
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

        public override void MapToModel(StageProjectDTO dto, StageProject model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.StageID = dto.StageID;
            model.ProjectID = dto.ProjectID;
            model.StageArName = dto.StageArName;
            model.StageEnName = dto.StageEnName;
            model.StartDate = dto.StartDate;
            model.EndDate = dto.EndDate;
            model.StageBudget = dto.StageBudget;

        }
    }
}
