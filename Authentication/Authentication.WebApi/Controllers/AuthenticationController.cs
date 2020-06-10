using Authentication.Application.Services;
using Authentication.Common.DTO;
using Authentication.Domain.Dto.Application;
using Authentication.Domain.Dto.Permission;
using Authentication.Domain.Dto.Role;
using Authentication.Domain.Dto.RolePermission;
using Authentication.Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Authentication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.AuthenticationService = authenticationService;
        }
        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertUserAsync")]
        public async Task<InsertUserResponseDTO> InsertUserAsync(InsertUserRequestDTO request)
        {
            return await AuthenticationService.InsertUserAsync(request);
        }

      
        [HttpPost]
        [Route("/api/v1/InsertApplicationAsync")]
        public async Task<InsertApplicationResponseDTO> InsertApplicationAsync(InsertApplicationRequestDTO request)
        {
            return await AuthenticationService.InsertApplicationAsync(request);
        }

        [HttpPost]
        [Route("/api/v1/ValidateUserAsync")]
        public async Task<ValidateUserResponseDTO> ValidateUserAsync(ValidateUserRequestDTO request)
        {
            return await AuthenticationService.ValidateUserAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/GetUsers")]
        public GetUserListResponseDTO GetUsers(GetUserRequestDTO request)
        {
            return AuthenticationService.GetUsers(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/HasPermission")]
        public Task<HasPermissionResponseDTO> HasPermission(HasPermissionRequestDTO request)
        {
            return AuthenticationService.HasPermission(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertRoleAsync")]
        public Task<InsertRoleResponseDTO> InsertRoleAsync(InsertRoleRequestDTO request)
        {
            return AuthenticationService.InsertRoleAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertPermissionAsync")]
        public Task<InsertPermissionResponseDTO> InsertPermissionAsync(InsertPermissionRequestDTO request)
        {
            return AuthenticationService.InsertPermissionAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertRolePermissionAsync")]
        public Task<InsertRolePermissionResponseDTO> InsertRolePermissionAsync(InsertRolePermissionRequestDTO request)
        {
            return AuthenticationService.InsertRolePermissionAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertRoleGroupAsync")]
        public Task<InsertRoleGroupResponseDTO> InsertRoleGroupAsync(InsertRoleGroupRequestDTO request)
        {
            return AuthenticationService.InsertRoleGroupAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertUserGroupAsync")]
        public Task<InsertUserGroupResponseDTO> InsertUserGroupAsync(InsertUserGroupRequestDTO request)
        {
            return AuthenticationService.InsertUserGroupAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/InsertUserRoleAsync")]
        public Task<InsertUserRoleResponseDTO> InsertUserRoleAsync(InsertUserRoleRequestDTO request)
        {
            return AuthenticationService.InsertUserRole(request);
        }
    }
}
