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
    public class EventTypeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public string EnName { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static EventTypeMapper Mapper = new EventTypeMapper();
        public EventType GetOriginal(EventType model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static EventTypeDTO GetDTO(EventType model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class EventTypeMapper : MapperBase<EventType, EventTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<EventType, EventTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<EventType, EventTypeDTO>>)(p => new EventTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(EventTypeDTO dto, EventType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
