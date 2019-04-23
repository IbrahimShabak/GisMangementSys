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
    public class NationalityTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int NationalityID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الجنسية")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Nationality")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static NationalityTBLMapper Mapper = new NationalityTBLMapper();
        public NationalityTBL GetOriginal(NationalityTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static NationalityTBLDTO GetDTO(NationalityTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class NationalityTBLMapper : MapperBase<NationalityTBL, NationalityTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<NationalityTBL, NationalityTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<NationalityTBL, NationalityTBLDTO>>)(p => new NationalityTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    NationalityID = p.NationalityID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(NationalityTBLDTO dto, NationalityTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.NationalityID = dto.NationalityID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
