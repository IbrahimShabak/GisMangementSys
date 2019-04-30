using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities.Fininchal;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DAL.Operations.DTO.Fininchal
{
    [DataContract]
    public class InvoiceTypeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public string EnName { get; set; }
    }

    public class InvoiceTypeMapper : MapperBase<InvoiceType, InvoiceTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<InvoiceType, InvoiceTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<InvoiceType, InvoiceTypeDTO>>)(p => new InvoiceTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    TypeID = p.TypeID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(InvoiceTypeDTO dto, InvoiceType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.TypeID = dto.TypeID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
