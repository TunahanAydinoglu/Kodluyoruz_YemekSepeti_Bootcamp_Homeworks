using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Odev8.Data.Context;
using Odev8.Service.Dtos.SystemDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Odev8.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private IConfiguration _configuration;

        public UserService(AppDbContext context,
                           IMapper mapper,
                           IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserInfo> Authenticate(TokenRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.LoginUser) ||
               string.IsNullOrWhiteSpace(req.LoginPassword))
            {
                return null;
            }

            var user = await _context
                             .Users
                             .SingleOrDefaultAsync(user => user.LoginName == req.LoginUser &&
                                                           user.Password == req.LoginPassword);

            if (user == null)
                return null;

            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesc = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var newToken = tokenHandler.CreateToken(tokenDesc);

            var userInfo = _mapper.Map<UserInfo>(user);
            userInfo.ExpireTime = tokenDesc.Expires ?? DateTime.Now.AddHours(1); 
            userInfo.Token = tokenHandler.WriteToken(newToken);

            return userInfo;
        }
    }
}
