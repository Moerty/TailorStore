using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Common.Mappings;

namespace TailorStore.Application.ClothesOption.Queries.GetClothesOptionsQuery
{
    public class GetClothesOptionsQueryDto : IMapFrom<Domain.Entities.ClothesOption> {
        public Guid ClothesId { get; set; }
        public Guid OptionId { get; set; }
        public string SKU { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Domain.Entities.ClothesOption, GetClothesOptionsQueryDto>(MemberList.Destination);
        }
    }
}
