using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Common.Mappings;

namespace TailorStore.Application.Clothes.Queries.GetClothesQuery {
    public class GetClothesQueryDto : IMapFrom<Domain.Entities.Clothes> {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Picture { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Domain.Entities.Clothes, GetClothesQueryDto>(MemberList.Destination);
        }
    }
}
