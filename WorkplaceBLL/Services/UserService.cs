using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;
using WorkplaceBLL.MapProfiles;
using WorkplaceDAL;
using WorkplaceDAL.Interfaces;
using WorkplaceDAL.Models;

namespace WorkplaceBLL.Services
{
    public class UserService:IUserServices
    {
        readonly IUnitOfWork unit;

        public UserService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyProfile());
        });
        public async Task UpdateUser(UserDTO user)
        {
            var mapper = new Mapper(config);
            var tempUser = await unit.Users.Get(user.Id);

            if (user.Password == null)
            {
                user.Password = tempUser.Password;
            }

            await Task.Run(() =>
            {
                unit.Users.Update(mapper.Map<UserDTO,User>(user));
                unit.Save();
            });
        }

        

        public async Task<UserDTO> GetUser(int? id)
        {
            var mapper = new Mapper(config);
            var user = await unit.Users.Find(temp=>temp.Id == id);
            return mapper.Map<User,UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var mapper = new Mapper(config);
            var users = await unit.Users.GetAll();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
