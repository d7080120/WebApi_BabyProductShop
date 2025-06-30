using AutoMapper;
using BabyProductShop;
using DTOEntities;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class UserServies : IUserServies
    {
        private readonly IUserRepositroy userRepositroy;
        private readonly IMapper mapper;//_mapper
        private readonly ILogger<UserServies> _logger;

        public UserServies(IUserRepositroy ur ,IMapper mapper, ILogger<UserServies>logger)
        {
            userRepositroy = ur;
            this.mapper = mapper;//_mapper = mapper
            _logger = logger;
        }
       
        public async Task<UserDTO> updateAsync(UserDTO userToUpdate, int id)//UpdateAsync
        {
            if (userToUpdate.Username == null || userToUpdate.Password == null || userToUpdate.FirstName == null || userToUpdate.LastName == null)
            {
                return null;
            }
            List<User> users = await userRepositroy.getAllUsersAsync();
            foreach (var item in users)
            {
                if (userToUpdate.Username == item.Username&&userToUpdate.Id!=item.Id)
                    return null;
            }
            int powerPassword = powerOfPassword(userToUpdate.Password);
            if (powerPassword >= 3)
            {
                User user = mapper.Map<User>(userToUpdate);
                user=await userRepositroy.updateAsync(user, id);
                UserDTO userDTO=mapper.Map<UserDTO>(user);
                return userDTO;
            }
            else
                throw new Exception("password is not strong");
        }

        public async Task<UserDTO> loginAsync(LoginUserDTO user)//LoginAsync
        {
            if (user.Username == null || user.Password == null)
            {
                return null;
            }
            _logger.LogInformation($"Login attempted with user Name , {user.Username} and password {user.Password}");
            User u = await userRepositroy.loginAsync(user);
            UserDTO userDTO = mapper.Map<UserDTO>(u);
            return userDTO;
        }

        public async Task<UserDTO> registerAsync(UserDTO user)//RegisterAsync
        {
            if (user.Username == null || user.Password == null || user.FirstName == null || user.LastName == null)
            {
                return null;
            }
            string emailValidation = emailValdator(user.Username);
            if (emailValidation != "email is valid")
            {
                return null;
            }
            List<User> users = await userRepositroy.getAllUsersAsync();
            foreach (var item in users)
            {
                if (user.Username==item.Username && user.Id != item.Id)
                    return null;
            }
            int powerPassword = powerOfPassword(user.Password);
            if (powerPassword >= 3)
            {
                User u = mapper.Map<User>(user);
                u= await userRepositroy.registerAsync(u);
                UserDTO userDTO=mapper.Map<UserDTO>(u);
                return userDTO;

            }
            else
                throw new Exception("password is not strong");
        }
        public string emailValdator(string email)//EmailValdator
        {
            if (email == null || email == "")
            {
                return "email is empty";
            }
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return "email is valid";
            }
            catch (FormatException)
            {
                return "email is not valid";
            }
        }
        public int powerOfPassword(string password)//PowerOfPassword
        {
            if (password == null || password == "")
            {
                return -1;
            }
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }

        public async Task<List<UserDTO>> getAllUsersAsync()//GetAllUsersAsync
        {
            List<User> users= await userRepositroy.getAllUsersAsync();
            return mapper.Map<List<UserDTO>>(users);
        }

    }
}
