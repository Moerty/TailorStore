using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Common.Mappings;

namespace TailorStore.Application.Fabric.Queries.GetFabricsQuery {
    public class GetFabricsQueryDto : IMapFrom<Domain.Entities.Fabric> {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Domain.Entities.Fabric, GetFabricsQueryDto>(MemberList.Destination);
        }
    }
}
