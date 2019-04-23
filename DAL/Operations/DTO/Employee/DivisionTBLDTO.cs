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
    public class DivisionTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم القسم")]
        [Key]
        public int DivisionID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "مسمى القسم")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Division Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static DivisionTBLMapper Mapper = new DivisionTBLMapper();
        public DivisionTBL GetOriginal(DivisionTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static DivisionTBLDTO GetDTO(DivisionTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class DivisionTBLMapper : MapperBase<DivisionTBL, DivisionTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<DivisionTBL, DivisionTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<DivisionTBL, DivisionTBLDTO>>)(p => new DivisionTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    DivisionID = p.DivisionID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(DivisionTBLDTO dto, DivisionTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.DivisionID = dto.DivisionID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
