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
    public class OrganizationsProjectDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int SerNum { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المسئول")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> PeopleID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود المشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> ProjectID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تصنيف الجهة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> OrgTypeID { get; set; }
        [DataMember]
        public int OegTypeOrgTypeID { get; set; }
        [DataMember]
        public string OegTypeTypeArName { get; set; }
        [DataMember]
        public string OegTypeTypeEnName { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> OegTypeOrganizationsProjects { get; set; }
        [DataMember]
        public int PepoleTBLPeopleID { get; set; }
        [DataMember]
        public string PepoleTBLArName { get; set; }
        [DataMember]
        public string PepoleTBLEnName { get; set; }
        [DataMember]
        public string PepoleTBLMobilePhone { get; set; }
        [DataMember]
        public string PepoleTBLLandLineExt { get; set; }
        [DataMember]
        public string PepoleTBLEmailAdress { get; set; }
        [DataMember]
        public int PepoleTBLOrgID { get; set; }
        [DataMember]
        public int PepoleTBLOrganizationBasicOrgID { get; set; }
        [DataMember]
        public string PepoleTBLOrganizationBasicOrgArName { get; set; }
        [DataMember]
        public string PepoleTBLOrganizationBasicOrgEnName { get; set; }
        [DataMember]
        public string PepoleTBLOrganizationBasicLandLineNumber { get; set; }
        [DataMember]
        public IEnumerable<PepoleTBLDTO> PepoleTBLOrganizationBasicPepoleTBLs { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> PepoleTBLOrganizationsProjects { get; set; }
        [DataMember]
        public int ProjectTBLProjectID { get; set; }
        [DataMember]
        public string ProjectTBLProjectNumber { get; set; }
        [DataMember]
        public string ProjectTBLArName { get; set; }
        [DataMember]
        public string ProjectTBLEnName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ProjectTBLStartDate { get; set; }
        [DataMember]
        public Nullable<decimal> ProjectTBLMainContractAmount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ProjectTBLEndDate { get; set; }
        [DataMember]
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
        public static OrganizationsProjectMapper Mapper = new OrganizationsProjectMapper();
        public OrganizationsProject GetOriginal(OrganizationsProject model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static OrganizationsProjectDTO GetDTO(OrganizationsProject model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //----------
    }

    public class OrganizationsProjectMapper : MapperBase<OrganizationsProject, OrganizationsProjectDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<OrganizationsProject, OrganizationsProjectDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<OrganizationsProject, OrganizationsProjectDTO>>)(p => new OrganizationsProjectDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    SerNum = p.SerNum,
                    PeopleID = p.PeopleID,
                    ProjectID = p.ProjectID,
                    OrgTypeID = p.OrgTypeID,
                    OegTypeOrgTypeID = p.OegType != null ? p.OegType.OrgTypeID : default(int),
                    OegTypeTypeArName = p.OegType != null ? p.OegType.TypeArName : default(string),
                    OegTypeTypeEnName = p.OegType != null ? p.OegType.TypeEnName : default(string),
                    //OrganizationsProjects = p.OegType.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression),
                    PepoleTBLPeopleID = p.PepoleTBL != null ? p.PepoleTBL.PeopleID : default(int),
                    PepoleTBLArName = p.PepoleTBL != null ? p.PepoleTBL.ArName : default(string),
                    PepoleTBLEnName = p.PepoleTBL != null ? p.PepoleTBL.EnName : default(string),
                    PepoleTBLMobilePhone = p.PepoleTBL != null ? p.PepoleTBL.MobilePhone : default(string),
                    PepoleTBLLandLineExt = p.PepoleTBL != null ? p.PepoleTBL.LandLineExt : default(string),
                    PepoleTBLEmailAdress = p.PepoleTBL != null ? p.PepoleTBL.EmailAdress : default(string),
                    PepoleTBLOrgID = p.PepoleTBL != null ? p.PepoleTBL.OrgID : default(int),
                    PepoleTBLOrganizationBasicOrgID = p.PepoleTBL != null && p.PepoleTBL.OrganizationBasic != null ? p.PepoleTBL.OrganizationBasic.OrgID : default(int),
                    PepoleTBLOrganizationBasicOrgArName = p.PepoleTBL != null && p.PepoleTBL.OrganizationBasic != null ? p.PepoleTBL.OrganizationBasic.OrgArName : default(string),
                    PepoleTBLOrganizationBasicOrgEnName = p.PepoleTBL != null && p.PepoleTBL.OrganizationBasic != null ? p.PepoleTBL.OrganizationBasic.OrgEnName : default(string),
                    PepoleTBLOrganizationBasicLandLineNumber = p.PepoleTBL != null && p.PepoleTBL.OrganizationBasic != null ? p.PepoleTBL.OrganizationBasic.LandLineNumber : default(string),
                    //PepoleTBLs = p.PepoleTBL.OrganizationBasic.PepoleTBLs.AsQueryable().Select(this._pepoleTBLMapper.SelectorExpression),
                    //OrganizationsProjects = p.PepoleTBL.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression),
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

        public override void MapToModel(OrganizationsProjectDTO dto, OrganizationsProject model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.SerNum = dto.SerNum;
            model.PeopleID = dto.PeopleID;
            model.ProjectID = dto.ProjectID;
            model.OrgTypeID = dto.OrgTypeID;

        }
    }
}
