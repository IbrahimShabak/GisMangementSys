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
    public class DeliverableStageDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم التسليمات")]
        [Key]
        public int DeliverableID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المرحلة")]
        public Nullable<int> StageID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم التسليم")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string DeliverableArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Deliverable Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string DeliverableEnName { get; set; }
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
        [Display(Name = "قيمة التسليم بالريال")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<decimal> DeliverableBudget { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المرحلة")]
        [Key]
        public int StageProjectStageID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
       
        public int StageProjectProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم المرحلة")]
  
        public string StageProjectStageArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Stage Name")]

        public string StageProjectStageEnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ البدء")]
        public Nullable<System.DateTime> StageProjectStartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        public Nullable<System.DateTime> StageProjectEndDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "قيمة المرحلة بالريال")]
        public Nullable<decimal> StageProjectStageBudget { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        public IEnumerable<DeliverableStageDTO> StageProjectDeliverableStages { get; set; }
        [DataMember]
        public int StageProjectProjectTBLProjectID { get; set; }
        [DataMember]
        public string StageProjectProjectTBLProjectNumber { get; set; }
        [DataMember]
        public string StageProjectProjectTBLArName { get; set; }
        [DataMember]
        public string StageProjectProjectTBLEnName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> StageProjectProjectTBLStartDate { get; set; }
        [DataMember]
        public Nullable<decimal> StageProjectProjectTBLMainContractAmount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> StageProjectProjectTBLEndDate { get; set; }
        [DataMember]
        public Nullable<bool> StageProjectProjectTBLIsActiveProject { get; set; }
        [DataMember]
        public IEnumerable<ContractsChangeDTO> StageProjectProjectTBLContractsChanges { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> StageProjectProjectTBLOrganizationsProjects { get; set; }
        [DataMember]
        public IEnumerable<ProjectEmployeeDTO> StageProjectProjectTBLProjectEmployees { get; set; }
        [DataMember]
        public IEnumerable<StageProjectDTO> StageProjectProjectTBLStageProjects { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static DeliverableStageMapper Mapper = new DeliverableStageMapper();
        //internal object DeliverableStages;

        public DeliverableStage GetOriginal(DeliverableStage model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static DeliverableStageDTO GetDTO(DeliverableStage model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class DeliverableStageMapper : MapperBase<DeliverableStage, DeliverableStageDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<DeliverableStage, DeliverableStageDTO>> SelectorExpression => ((Expression<Func<DeliverableStage, DeliverableStageDTO>>)(p => new DeliverableStageDTO()
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            DeliverableID = p.DeliverableID,
            StageID = p.StageID,
            DeliverableArName = p.DeliverableArName,
            DeliverableEnName = p.DeliverableEnName,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            DeliverableBudget = p.DeliverableBudget,
            StageProjectStageID = p.StageProject != null ? p.StageProject.StageID : default(int),
            StageProjectProjectID = p.StageProject != null ? p.StageProject.ProjectID : default(int),
            StageProjectStageArName = p.StageProject != null ? p.StageProject.StageArName : default(string),
            StageProjectStageEnName = p.StageProject != null ? p.StageProject.StageEnName : default(string),
            StageProjectStartDate = p.StageProject != null ? p.StageProject.StartDate : default(Nullable<System.DateTime>),
            StageProjectEndDate = p.StageProject != null ? p.StageProject.EndDate : default(Nullable<System.DateTime>),
            StageProjectStageBudget = p.StageProject != null ? p.StageProject.StageBudget : default(Nullable<decimal>),
            //DeliverableStages = p.StageProject.DeliverableStages.AsQueryable().Select(_deliverableStageMapper.SelectorExpression),
            StageProjectProjectTBLProjectID = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.ProjectID : default(int),
            StageProjectProjectTBLProjectNumber = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.ProjectNumber : default(string),
            StageProjectProjectTBLArName = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.ArName : default(string),
            StageProjectProjectTBLEnName = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.EnName : default(string),
            StageProjectProjectTBLStartDate = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.StartDate : default(Nullable<System.DateTime>),
            StageProjectProjectTBLMainContractAmount = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.MainContractAmount : default(Nullable<decimal>),
            StageProjectProjectTBLEndDate = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.EndDate : default(Nullable<System.DateTime>),
            StageProjectProjectTBLIsActiveProject = p.StageProject != null && p.StageProject.ProjectTBL != null ? p.StageProject.ProjectTBL.IsActiveProject : default(Nullable<bool>),
            //ContractsChanges = p.StageProject.ProjectTBL.ContractsChanges.AsQueryable().Select(this._contractsChangeMapper.SelectorExpression),
            //OrganizationsProjects = p.StageProject.ProjectTBL.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression),
            //ProjectEmployees = p.StageProject.ProjectTBL.ProjectEmployees.AsQueryable().Select(this._projectEmployeeMapper.SelectorExpression),
            //StageProjects = p.StageProject.ProjectTBL.StageProjects.AsQueryable().Select(this._stageProjectMapper.SelectorExpression)
        }));

        public object _deliverableStageMapper { get; private set; }

        public override void MapToModel(DeliverableStageDTO dto, DeliverableStage model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.DeliverableID = dto.DeliverableID;
            model.StageID = dto.StageID;
            model.DeliverableArName = dto.DeliverableArName;
            model.DeliverableEnName = dto.DeliverableEnName;
            model.StartDate = dto.StartDate;
            model.EndDate = dto.EndDate;
            model.DeliverableBudget = dto.DeliverableBudget;

        }
    }
}
