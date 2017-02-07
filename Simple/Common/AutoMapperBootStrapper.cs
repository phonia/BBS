using AutoMapper;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.Models;
using Simple.ViewModel;

namespace Simple.Common
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class AutoMapperBootStrapper
    {
        public static void Start()
        {
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();

        }
    }
}
