using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;

namespace TailorStore.Domain.Entities {
    public class Group : AuditableEntity {
        public string Namen { get; set; }
        
        public IList<Clothes> Clothes { get; set; }
    }
}
