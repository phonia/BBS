using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.ViewModel;

namespace Simple.Services
{
    public interface ISectionService
    {
        List<SectionDTO> GetAllSections();
        SectionDTO GetById(Int32 id);
    }
}