using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;

namespace TailorStore.Domain.Entities {
    public class Option : AuditableEntity {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public Type Type { get; set; }
        public IList<ClothesOption> ClothesOptions { get; set; }
    }
}
