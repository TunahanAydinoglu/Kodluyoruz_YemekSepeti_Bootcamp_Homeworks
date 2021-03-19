using Odev8.Service.Dtos.SystemDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odev8.Service.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
    }
}
