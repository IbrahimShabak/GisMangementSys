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
    public class ArchiveTBLDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public Nullable<int> ProjectID { get; set; }
        [DataMember]
        public Nullable<int> DocumentType { get; set; }
        [DataMember]
        public string FilePathLink { get; set; }
        [DataMember]
        public Nullable<System.DateTime> AddDate { get; set; }
        [DataMember]
        public Nullable<bool> WithHardCopy { get; set; }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static ArchiveTBLMapper Mapper = new ArchiveTBLMapper();
        public ArchiveTBL GetOriginal(ArchiveTBL model)
        {
            Mapper.MapToModel(this, model);
            return model;
        }
        public static ArchiveTBLDTO GetDTO(ArchiveTBL model)
        {
            var result = Mapper.GetDTO(model);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
    }

    public class ArchiveTBLMapper : MapperBase<ArchiveTBL, ArchiveTBLDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ArchiveTBL, ArchiveTBLDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ArchiveTBL, ArchiveTBLDTO>>)(p => new ArchiveTBLDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    ID = p.ID,
                    Details = p.Details,
                    ProjectID = p.ProjectID,
                    DocumentType = p.DocumentType,
                    FilePathLink = p.FilePathLink,
                    AddDate = p.AddDate,
                    WithHardCopy = p.WithHardCopy
                }));
            }
        }

        public override void MapToModel(ArchiveTBLDTO dto, ArchiveTBL model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.ID = dto.ID;
            model.Details = dto.Details;
            model.ProjectID = dto.ProjectID;
            model.DocumentType = dto.DocumentType;
            model.FilePathLink = dto.FilePathLink;
            model.AddDate = dto.AddDate;
            model.WithHardCopy = dto.WithHardCopy;

        }
    }
}
