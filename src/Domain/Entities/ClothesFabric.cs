using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Common;
using TailorStore.Domain.Enums;

namespace TailorStore.Domain.Entities {
    public class ClothesFabric : AuditableEntity {
        public Guid ClothesId { get; set; }
        public Guid FabricId { get; set; }

        public ColorType ColorType { get; set; }

        public Clothes Clothes { get; set; }
        public Fabric Fabric { get; set; }
    }
}
