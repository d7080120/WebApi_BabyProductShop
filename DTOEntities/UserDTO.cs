using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOEntities
{
   public record UserDTO(string Username, string Password,string FirstName,string LastName,int Id);
}
