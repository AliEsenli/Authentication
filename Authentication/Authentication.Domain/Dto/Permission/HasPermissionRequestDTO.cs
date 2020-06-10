using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.Permission
{
    [DataContract]
    public class HasPermissionRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long ApplicationId { get; set; }

        [DataMember]
        public string ClientCode { get; set; }

        [DataMember]
        public string ClientPassword { get; set; }

        [DataMember]
        public string ControllerRoute { get; set; }
    }

}
