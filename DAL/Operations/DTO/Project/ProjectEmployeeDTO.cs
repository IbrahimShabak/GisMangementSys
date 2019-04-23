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
    public class ProjectEmployeeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int ID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public int ProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود الموظف")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public int EmpID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ البدء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> StartFrom { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> EndTo { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الوظيفة بالمشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public int PositionInProject { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int PositionInProject1ID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الوظيفة بالمشروع")]
        
        public string PositionInProject1ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Position In The Project")]
      
        public string PositionInProject1EnName { get; set; }
        [DataMember]
        public IEnumerable<ProjectEmployeeDTO> PositionInProject1ProjectEmployees { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Key]
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
        public static ProjectEmployeeMapper Mapper = new ProjectEmployeeMapper();
        public ProjectEmployee GetOriginal(ProjectEmployee model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ProjectEmployeeDTO GetDTO(ProjectEmployee model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class ProjectEmployeeMapper : MapperBase<ProjectEmployee, ProjectEmployeeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ProjectEmployee, ProjectEmployeeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ProjectEmployee, ProjectEmployeeDTO>>)(p => new ProjectEmployeeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ProjectID = p.ProjectID,
                    EmpID = p.EmpID,
                    StartFrom = p.StartFrom,
                    EndTo = p.EndTo,
                    PositionInProject = p.PositionInProject,
                    PositionInProject1ID = p.PositionInProject1 != null ? p.PositionInProject1.ID : default(int),
                    PositionInProject1ArName = p.PositionInProject1 != null ? p.PositionInProject1.ArName : default(string),
                    PositionInProject1EnName = p.PositionInProject1 != null ? p.PositionInProject1.EnName : default(string),
                    //ProjectEmployees = p.PositionInProject1.ProjectEmployees.AsQueryable().Select(this._projectEmployeeMapper.SelectorExpression),
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

        public override void MapToModel(ProjectEmployeeDTO dto, ProjectEmployee model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ProjectID = dto.ProjectID;
            model.EmpID = dto.EmpID;
            model.StartFrom = dto.StartFrom;
            model.EndTo = dto.EndTo;
            model.PositionInProject = dto.PositionInProject;

        }
    }
}
