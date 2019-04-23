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
    public class OegTypeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int OrgTypeID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "أسم النوع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string TypeArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Organization Type Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string TypeEnName { get; set; }
        [DataMember]
        public IEnumerable<OrganizationsProjectDTO> OrganizationsProjects { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static OegTypeMapper Mapper = new OegTypeMapper();
        public OegType GetOriginal(OegType model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static OegTypeDTO GetDTO(OegType model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class OegTypeMapper : MapperBase<OegType, OegTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private OrganizationsProjectMapper _organizationsProjectMapper = new OrganizationsProjectMapper();
        public override Expression<Func<OegType, OegTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<OegType, OegTypeDTO>>)(p => new OegTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    OrgTypeID = p.OrgTypeID,
                    TypeArName = p.TypeArName,
                    TypeEnName = p.TypeEnName,
                    OrganizationsProjects = p.OrganizationsProjects.AsQueryable().Select(this._organizationsProjectMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(OegTypeDTO dto, OegType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.OrgTypeID = dto.OrgTypeID;
            model.TypeArName = dto.TypeArName;
            model.TypeEnName = dto.TypeEnName;

        }
    }
}
