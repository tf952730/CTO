using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D01.A01.Entities
{
   public interface IEntity: IEntityBase
    {
        string Name { get; set; }
        string Description { get; set; }
        string SortCode { get; set; }
    }
}
