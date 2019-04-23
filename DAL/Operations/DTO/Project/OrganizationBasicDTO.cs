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
    public class OrganizationBasicDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الجهة")]
        [Key]
        public int OrgID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم الجهة ")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string OrgArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Organization Name ")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string OrgEnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الهاتف الأرضي")]
        public string LandLineNumber { get; set; }
        [DataMember]
        public IEnumerable<PepoleTBLDTO> PepoleTBLs { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static OrganizationBasicMapper Mapper = new OrganizationBasicMapper();
        public OrganizationBasic GetOriginal(OrganizationBasic model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static OrganizationBasicDTO GetDTO(OrganizationBasic model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class OrganizationBasicMapper : MapperBase<OrganizationBasic, OrganizationBasicDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private PepoleTBLMapper _pepoleTBLMapper = new PepoleTBLMapper();
        public override Expression<Func<OrganizationBasic, OrganizationBasicDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<OrganizationBasic, OrganizationBasicDTO>>)(p => new OrganizationBasicDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    OrgID = p.OrgID,
                    OrgArName = p.OrgArName,
                    OrgEnName = p.OrgEnName,
                    LandLineNumber = p.LandLineNumber,
                    PepoleTBLs = p.PepoleTBLs.AsQueryable().Select(this._pepoleTBLMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(OrganizationBasicDTO dto, OrganizationBasic model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.OrgID = dto.OrgID;
            model.OrgArName = dto.OrgArName;
            model.OrgEnName = dto.OrgEnName;
            model.LandLineNumber = dto.LandLineNumber;

        }
    }
}
