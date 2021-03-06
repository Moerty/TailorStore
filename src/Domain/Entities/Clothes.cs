using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;

namespace TailorStore.Domain.Entities {
    public class Clothes : AuditableEntity {
        public string Name { get; set; }
        public string Picture { get; set; }

        public Guid ApplicationUserId { get; set; }
        public Guid GroupId { get; set; }

        public IList<ClothesFabric> ClothesFabrics { get; set; }
        public IList<ClothesOption> ClothesOptions { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Group Group { get; set; }
    }
}
