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
    public class TaskOperationDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المهمة")]
        [Key]
        public int TaskID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "وصف المهمة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string TaskName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المنشئ")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> CreatorEmp { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنشاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> CreationDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ البدء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تاريخ الإنتهاء")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<System.DateTime> EndDate { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم المهمة الاب")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> ParentID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم التسليمه")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> DeliverableID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "حالة المهمة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<bool> TaskStatus { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "تصنيف المهمة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> TaskType { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "الأهمية")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> TaskProierty { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المرفقات")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string Attachments { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public static TaskOperationMapper Mapper = new TaskOperationMapper();
        public TaskOperation GetOriginal(TaskOperation model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static TaskOperationDTO GetDTO(TaskOperation model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class TaskOperationMapper : MapperBase<TaskOperation, TaskOperationDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<TaskOperation, TaskOperationDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<TaskOperation, TaskOperationDTO>>)(p => new TaskOperationDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    TaskID = p.TaskID,
                    TaskName = p.TaskName,
                    CreatorEmp = p.CreatorEmp,
                    CreationDate = p.CreationDate,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ParentID = p.ParentID,
                    DeliverableID = p.DeliverableID,
                    TaskStatus = p.TaskStatus,
                    TaskType = p.TaskType,
                    TaskProierty = p.TaskProierty,
                    Attachments = p.Attachments
                }));
            }
        }

        public override void MapToModel(TaskOperationDTO dto, TaskOperation model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.TaskID = dto.TaskID;
            model.TaskName = dto.TaskName;
            model.CreatorEmp = dto.CreatorEmp;
            model.CreationDate = dto.CreationDate;
            model.StartDate = dto.StartDate;
            model.EndDate = dto.EndDate;
            model.ParentID = dto.ParentID;
            model.DeliverableID = dto.DeliverableID;
            model.TaskStatus = dto.TaskStatus;
            model.TaskType = dto.TaskType;
            model.TaskProierty = dto.TaskProierty;
            model.Attachments = dto.Attachments;

        }
    }
}
