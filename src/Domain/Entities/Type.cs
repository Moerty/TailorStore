using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;

namespace TailorStore.Domain.Entities {
    public class Type : AuditableEntity {
        public string Name { get; set; }

        public IList<Option> Options { get; set; }
    }
}
