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
    public class JobTitleTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "رقم")]
        [Key]
        public int JobTitleID { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "المسمى الوظيفي")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string ArName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        [DataMember]
        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "يجب ادخال {0}")]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static JobTitleTBLMapper Mapper = new JobTitleTBLMapper();
        public JobTitleTBL GetOriginal(JobTitleTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static JobTitleTBLDTO GetDTO(JobTitleTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class JobTitleTBLMapper : MapperBase<JobTitleTBL, JobTitleTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<JobTitleTBL, JobTitleTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<JobTitleTBL, JobTitleTBLDTO>>)(p => new JobTitleTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    JobTitleID = p.JobTitleID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(JobTitleTBLDTO dto, JobTitleTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.JobTitleID = dto.JobTitleID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
