using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DTOEntities
{
    public record ProductDTO(int Id,string Image,string Description,string Name,int CategoryId);

}

