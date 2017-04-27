using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;
using ViewModel;

namespace Services.Mapping
{
    public static class ModuleMenuMapping
    {
        public static Expression<Func<ModuleMenu, ModuleMenuDTO>> ConvertToDTO()
        {
            return (it) => new ModuleMenuDTO() { 
                Id=it.Id,
                IsEnable=it.IsEnable,
                IsPage=it.IsPage,
                IsVisible=it.IsVisible,
                MenuCode=it.MenuCode,
                MenuName=it.MenuName,
                ModuleId=it.ModuleId,
                URL=it.URL
            };
        }
    }
}
