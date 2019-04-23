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
    public class PositionInProjectDTO
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
        [Display(Name = "الوظيفة بالمشروع")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Position In The Project")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        [DataMember]
        public IEnumerable<ProjectEmployeeDTO> ProjectEmployees { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static PositionInProjectMapper Mapper = new PositionInProjectMapper();
        public PositionInProject GetOriginal(PositionInProject model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static PositionInProjectDTO GetDTO(PositionInProject model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

    }

    public class PositionInProjectMapper : MapperBase<PositionInProject, PositionInProjectDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ProjectEmployeeMapper _projectEmployeeMapper = new ProjectEmployeeMapper();
        public override Expression<Func<PositionInProject, PositionInProjectDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<PositionInProject, PositionInProjectDTO>>)(p => new PositionInProjectDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    ProjectEmployees = p.ProjectEmployees.AsQueryable().Select(this._projectEmployeeMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(PositionInProjectDTO dto, PositionInProject model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
