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
    public class PepoleTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المسئول")]
        [Key]
        public int PeopleID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الأسم")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الجوال")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string MobilePhone { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تحويلة المكتب")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string LandLineExt { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "البريد الإلكتروني")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EmailAdress { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الجهة")]
        public int OrgID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "كود الجهة")]
        public int OrganizationBasicOrgID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم الجهة")]
       
        public string OrganizationBasicOrgArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Organization Name")]
        
        public string OrganizationBasicOrgEnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الهاتف الأرضي")]
   
        public string OrganizationBasicLandLineNumber { get; set; }
        [DataMember]
        public IEnumerable<PepoleTBLDTO> OrganizationBasicPepoleTBLs { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> OrganizationsProjects { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static PepoleTBLMapper Mapper = new PepoleTBLMapper();
        public PepoleTBL GetOriginal(PepoleTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static PepoleTBLDTO GetDTO(PepoleTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------


    }

    public class PepoleTBLMapper : MapperBase<PepoleTBL, PepoleTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private OrganizationsProjectMapper _organizationsProjectMapper = new OrganizationsProjectMapper();
        public override Expression<Func<PepoleTBL, PepoleTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<PepoleTBL, PepoleTBLDTO>>)(p => new PepoleTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    PeopleID = p.PeopleID,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    MobilePhone = p.MobilePhone,
                    LandLineExt = p.LandLineExt,
                    EmailAdress = p.EmailAdress,
                    OrgID = p.OrgID,
                    OrganizationBasicOrgID = p.OrganizationBasic != null ? p.OrganizationBasic.OrgID : default(int),
                    OrganizationBasicOrgArName = p.OrganizationBasic != null ? p.OrganizationBasic.OrgArName : default(string),
                    OrganizationBasicOrgEnName = p.OrganizationBasic != null ? p.OrganizationBasic.OrgEnName : default(string),
                    OrganizationBasicLandLineNumber = p.OrganizationBasic != null ? p.OrganizationBasic.LandLineNumber : default(string),
                    //PepoleTBLs = p.OrganizationBasic.PepoleTBLs.AsQueryable().Select(this._pepoleTBLMapper.SelectorExpression),
                    OrganizationsProjects = p.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(PepoleTBLDTO dto, PepoleTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.PeopleID = dto.PeopleID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;
            model.MobilePhone = dto.MobilePhone;
            model.LandLineExt = dto.LandLineExt;
            model.EmailAdress = dto.EmailAdress;
            model.OrgID = dto.OrgID;

        }
    }
}
