using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Archive;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Archive
{
    [DataContract]
    public class FollowUpDocumentsCircleDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int ArchiveID { get; set; }
        [DataMember]
        public System.DateTime EventDatetime { get; set; }
        [DataMember]
        public Nullable<int> EmpID { get; set; }
        [DataMember]
        public Nullable<int> EventType { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static FollowUpDocumentsCircleMapper Mapper = new FollowUpDocumentsCircleMapper();
        public FollowUpDocumentsCircle GetOriginal(FollowUpDocumentsCircle model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static FollowUpDocumentsCircleDTO GetDTO(FollowUpDocumentsCircle model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class FollowUpDocumentsCircleMapper : MapperBase<FollowUpDocumentsCircle, FollowUpDocumentsCircleDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<FollowUpDocumentsCircle, FollowUpDocumentsCircleDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<FollowUpDocumentsCircle, FollowUpDocumentsCircleDTO>>)(p => new FollowUpDocumentsCircleDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ArchiveID = p.ArchiveID,
                    EventDatetime = p.EventDatetime,
                    EmpID = p.EmpID,
                    EventType = p.EventType
                }));
            }
        }

        public override void MapToModel(FollowUpDocumentsCircleDTO dto, FollowUpDocumentsCircle model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ArchiveID = dto.ArchiveID;
            model.EventDatetime = dto.EventDatetime;
            model.EmpID = dto.EmpID;
            model.EventType = dto.EventType;

        }
    }
}
