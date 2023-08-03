using AutoMapper;
using Service.Mappings.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    internal class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
