using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    /// <summary>
    /// Base class for all entities. May be extended with shared properties.
    /// </summary>
    public class Entity
    {
        public int Id { get; set; }
    }
}
