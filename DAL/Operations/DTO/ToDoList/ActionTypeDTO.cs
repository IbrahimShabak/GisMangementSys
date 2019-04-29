using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.ToDoList;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.ToDoList
{
    [DataContract]
    public class ActionTypeDTO
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
        [Display(Name = "اسم الإجراء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Action Name")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "نسبة الإنجاز")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<decimal> PercentageAdd { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static ActionTypeMapper Mapper = new ActionTypeMapper();
        public ActionType GetOriginal(ActionType model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ActionTypeDTO GetDTO(ActionType model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class ActionTypeMapper : MapperBase<ActionType, ActionTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ActionType, ActionTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ActionType, ActionTypeDTO>>)(p => new ActionTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ArName = p.ArName,
                    EnName = p.EnName,
                    PercentageAdd = p.PercentageAdd
                }));
            }
        }

        public override void MapToModel(ActionTypeDTO dto, ActionType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;
            model.PercentageAdd = dto.PercentageAdd;

        }
    }
}
