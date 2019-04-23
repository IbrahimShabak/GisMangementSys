using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Employees;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Employee
{
    [DataContract]
    public class EmployeeOffTypeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int EmployeeOffTypeID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "نوع الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Work Off Type")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static EmployeeOffTypeMapper Mapper = new EmployeeOffTypeMapper();
        public EmployeeOffType GetOriginal(EmployeeOffType model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static EmployeeOffTypeDTO GetDTO(EmployeeOffType model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class EmployeeOffTypeMapper : MapperBase<EmployeeOffType, EmployeeOffTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<EmployeeOffType, EmployeeOffTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<EmployeeOffType, EmployeeOffTypeDTO>>)(p => new EmployeeOffTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    EmployeeOffTypeID = p.EmployeeOffTypeID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(EmployeeOffTypeDTO dto, EmployeeOffType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.EmployeeOffTypeID = dto.EmployeeOffTypeID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
