using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface
{
    public interface ISysService:IDomainService
    {
        void InitDataBase();
        void ReInitDataBase();
    }
}
