using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Permission
{
    [DataContract]
    public class HasPermissionResponseDTO : ResponseDTOBase
    {
        [DataMember]
        public bool HasPermission { get; set; }
    }
}
