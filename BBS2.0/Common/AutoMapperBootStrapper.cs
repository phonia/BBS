using AutoMapper;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS2._0.Models;
using BBS2._0.ViewModel;

namespace BBS2._0.Common
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class AutoMapperBootStrapper
    {
        public static void Start()
        {
            //Mapper.CreateMap<User, UserDTO>();
            //Mapper.CreateMap<UserDTO, User>();
            //Mapper.CreateMap<Post, PostDTO>();
            //Mapper.CreateMap<PostDTO, Post>();
            Mapper.CreateMap<Account, AccountDTO>();
            Mapper.CreateMap<AccountDTO, Account>();
            Mapper.CreateMap<Section, SectionDTO>();
            Mapper.CreateMap<SectionDTO, Section>();
            Mapper.CreateMap<Post, PostDTO>();
            Mapper.CreateMap<PostDTO, Post>();
            Mapper.CreateMap<Reply, ReplyDTO>();
            Mapper.CreateMap<ReplyDTO, Reply>();

            //
            Mapper.CreateMap<SysModule, ModuleDTO>();
            Mapper.CreateMap<ModuleDTO, SysModule>();
        }
    }
}
