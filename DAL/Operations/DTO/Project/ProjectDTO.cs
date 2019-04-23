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
    public class ProjectDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Key]
        public int ProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ProjectNumber { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "مسمى المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ بدء المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "قيمة العقد")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<decimal> MainContractAmount { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> EndDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "مشروع جاري")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<bool> IsActiveProject { get; set; }
        //[DataMember]
        //public IEnumerable<ContractsChangeDTO> ContractsChanges { get; set; }
        //[DataMember]
        //public IEnumerable<OrganizationsProjectDTO> OrganizationsProjects { get; set; }
        //[DataMember]
        //public IEnumerable<ProjectEmployeeDTO> ProjectEmployees { get; set; }
        //[DataMember]
        //public IEnumerable<StageProjectDTO> StageProjects { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static ProjectMapper Mapper = new ProjectMapper();
        public ProjectTBL GetOriginal(ProjectTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ProjectDTO GetDTO(ProjectTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class ProjectMapper : MapperBase<ProjectTBL, ProjectDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ContractsChangeMapper _contractsChangeMapper = new ContractsChangeMapper();
        private OrganizationsProjectMapper _organizationsProjectMapper = new OrganizationsProjectMapper();
        private ProjectEmployeeMapper _projectEmployeeMapper = new ProjectEmployeeMapper();
        private StageProjectMapper _stageProjectMapper = new StageProjectMapper();
        public override Expression<Func<ProjectTBL, ProjectDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ProjectTBL, ProjectDTO>>)(p => new ProjectDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ProjectID = p.ProjectID,
                    ProjectNumber = p.ProjectNumber,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    StartDate = p.StartDate,
                    MainContractAmount = p.MainContractAmount,
                    EndDate = p.EndDate,
                    IsActiveProject = p.IsActiveProject,
                    //ContractsChanges = p.ContractsChanges.AsQueryable().Select(this._contractsChangeMapper.SelectorExpression),
                    //OrganizationsProjects = p.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression),
                    //ProjectEmployees = p.ProjectEmployees.AsQueryable().Select(this._projectEmployeeMapper.SelectorExpression),
                    //StageProjects = p.StageProjects.AsQueryable().Select(this._stageProjectMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(ProjectDTO dto, ProjectTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ProjectID = dto.ProjectID;
            model.ProjectNumber = dto.ProjectNumber;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;
            model.StartDate = dto.StartDate;
            model.MainContractAmount = dto.MainContractAmount;
            model.EndDate = dto.EndDate;
            model.IsActiveProject = dto.IsActiveProject;

        }
    }
}
