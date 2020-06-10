using Authentication.Common.DTO;
using Authentication.Common.Enum;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Application
{
    [DataContract]
    public class InsertApplicationRequestDTO : RequestDTOBase
    {
        [DataMember]
        public string ApplicationName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
