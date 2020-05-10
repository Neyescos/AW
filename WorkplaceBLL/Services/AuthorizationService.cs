using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;
using WorkplaceBLL.MapProfiles;
using WorkplaceDAL.Interfaces;
using WorkplaceDAL.Models;

namespace WorkplaceBLL.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        readonly IUnitOfWork unit;

        public AuthorizationService(IUnitOfWork unit)
        {
            this.unit = unit;   
        }
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyProfile());
        });
        public async Task Registration(UserDTO user)
        {
            
             var result =await unit.Users.Find(x => x.Name == user.Name);
            

            if(result==null)
            {
                var mapper = new Mapper(config);
                user.Role = "User";
                unit.Users.Create(mapper.Map<UserDTO, User>(user));
                unit.Save();

            }
            else
            {
                bool isCancelled = true;
                await Task.FromCanceled(new CancellationToken(isCancelled));
            }
        }
        public async Task<UserDTO> Login(string password, string name)
        {
            
            var mapper = new Mapper(config);
            UserDTO foundedUser = mapper.Map<UserDTO>(await unit.Users.Find(us => us.Name == name));
            if (foundedUser.Password == password)
            {
                return foundedUser;
            }
            return null;
            
        }

        
    }
}
