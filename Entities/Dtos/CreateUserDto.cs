using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator AppUser(CreateUserDto createUser)
        {
            return new AppUser
            {
                Email = createUser.Email,
                UserName = createUser.UserName
            };
        }
    }
}
