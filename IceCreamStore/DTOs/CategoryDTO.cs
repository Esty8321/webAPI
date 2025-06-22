

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
   public record CategoryDTO(int ID,String CategoryName,List<ProductDTO>Products);
}
