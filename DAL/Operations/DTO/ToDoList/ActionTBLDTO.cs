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
    public class ActionTBLDTO
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
        [Display(Name = "إجراءات المستخدمين")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> EmployeeActionID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الإجراء المتخذ")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> ActionTaken { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإجراء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> ActionDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "التعليق")]
        public string Notes { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المرفقات")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string Attachments { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static ActionTBLMapper Mapper = new ActionTBLMapper();
        public ActionTBL GetOriginal(ActionTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ActionTBLDTO GetDTO(ActionTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class ActionTBLMapper : MapperBase<ActionTBL, ActionTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ActionTBL, ActionTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ActionTBL, ActionTBLDTO>>)(p => new ActionTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    EmployeeActionID = p.EmployeeActionID,
                    ActionTaken = p.ActionTaken,
                    ActionDate = p.ActionDate,
                    Notes = p.Notes,
                    Attachments = p.Attachments
                }));
            }
        }

        public override void MapToModel(ActionTBLDTO dto, ActionTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.EmployeeActionID = dto.EmployeeActionID;
            model.ActionTaken = dto.ActionTaken;
            model.ActionDate = dto.ActionDate;
            model.Notes = dto.Notes;
            model.Attachments = dto.Attachments;

        }
    }
}
