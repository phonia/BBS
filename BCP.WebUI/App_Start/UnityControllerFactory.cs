using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BCP.WebUI.App_Start
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        public UnityBootStrapper _unityBootStrapper = null;

        public UnityControllerFactory()
        {
            _unityBootStrapper = new UnityBootStrapper();
            _unityBootStrapper.Bindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_unityBootStrapper.UnityContainer
                .Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _unityBootStrapper.UnityContainer.Teardown(controller);
        }
    }
}