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
    public class EmployeeTaskDTO
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
        [Display(Name = "رقم مهمة العمل")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> TaskID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم الموظف")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> EmpID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "دورة بالمهمة")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public Nullable<int> RoleInTask { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static EmployeeTaskMapper Mapper = new EmployeeTaskMapper();
        public EmployeeTask GetOriginal(EmployeeTask model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static EmployeeTaskDTO GetDTO(EmployeeTask model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class EmployeeTaskMapper : MapperBase<EmployeeTask, EmployeeTaskDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<EmployeeTask, EmployeeTaskDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<EmployeeTask, EmployeeTaskDTO>>)(p => new EmployeeTaskDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    TaskID = p.TaskID,
                    EmpID = p.EmpID,
                    RoleInTask = p.RoleInTask
                }));
            }
        }

        public override void MapToModel(EmployeeTaskDTO dto, EmployeeTask model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.TaskID = dto.TaskID;
            model.EmpID = dto.EmpID;
            model.RoleInTask = dto.RoleInTask;

        }
    }
}
