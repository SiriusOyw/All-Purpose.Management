using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Manage.Models.DTO;
using Zhaoxi.Manage.Models.Entity;

namespace Zhaoxi.Manage.BusinessInterface.MapConfig
{
    public class AutoMapperConfigs : Profile
    {
        /// <summary>
        /// 配置映射关系，在实例化当前这个类的时候，就要处理好
        /// </summary>
        public AutoMapperConfigs()
        {
            CreateMap<Sys_User, SysUserDTO>().ReverseMap();

            CreateMap<PagingData<Sys_User>, PagingData<SysUserDTO>>().ReverseMap();
        }
    }
}
