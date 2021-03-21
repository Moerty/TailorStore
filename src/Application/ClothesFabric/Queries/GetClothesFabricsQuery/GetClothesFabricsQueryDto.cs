using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Common.Mappings;
using TailorStore.Domain.Enums;

namespace TailorStore.Application.ClothesFabric.Queries.GetClothesFabricsQuery {
    public class GetClothesFabricsQueryDto : IMapFrom<Domain.Entities.ClothesFabric> {
        public Guid ClothesId { get; set; }
        public Guid FabricId { get; set; }

        public ColorType ColorType { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Domain.Entities.ClothesFabric, GetClothesFabricsQueryDto>(MemberList.Destination);
        }
    }
}
