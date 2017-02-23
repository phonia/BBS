using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface ISectionService
    {
        bool RegisterSecion(String title, String description);
        bool UpdateSection(Int32 id, String title, String description);
        bool UnRegisterSection(Int32 id);
        SectionDTO GetById(Int32 id);
        List<SectionDTO> GetAll();
    }
}