using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCP.WebUI.Modules
{
    public class LoginModules:IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            
        }

        #endregion
    }
}