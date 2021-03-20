using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace Api.Services {
    public class CurrentUserService : ICurrentUserService {
        public string UserId => "test";
    }
}
