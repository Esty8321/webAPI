using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
  public record OrderDTO(int Id,Double ?price ,DateTime ?date);
}
