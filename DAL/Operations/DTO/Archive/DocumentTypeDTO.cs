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
    public class DocumentTypeDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ArName { get; set; }
        [DataMember]
        public string EnName { get; set; }
    }

    public class DocumentTypeMapper : MapperBase<DocumentType, DocumentTypeDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<DocumentType, DocumentTypeDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<DocumentType, DocumentTypeDTO>>)(p => new DocumentTypeDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    ArName = p.ArName,
                    EnName = p.EnName
                }));
            }
        }

        public override void MapToModel(DocumentTypeDTO dto, DocumentType model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.ArName = dto.ArName;
            model.EnName = dto.EnName;

        }
    }
}
