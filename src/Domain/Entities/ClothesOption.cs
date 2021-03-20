using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;

namespace TailorStore.Domain.Entities {
    public class ClothesOption : AuditableEntity {
        public Guid ClothesId { get; set; }
        public Guid OptionId { get; set; }

        public Option Option { get; set; }
        public Clothes Clothes { get; set; }
    }
}
