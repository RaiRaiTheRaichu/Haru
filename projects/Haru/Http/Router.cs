using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Haru.Extensions;
using Haru.Models;
using Haru.Helpers;
using Haru.Utils;

namespace Haru.Http
{
    public class Router
    {
        private readonly RequestHelper _requestHelper;
        private readonly Log _log;
        private readonly List<Controller> _controllers;

        public Router()
        {
            _requestHelper = new RequestHelper();
            _log = new Log();
            _controllers = new List<Controller>();
        }

        public bool GetController<T>(out T controller) where T : Controller, new()
        {
            foreach (var item in _controllers)
            {
                if (item.GetType() == typeof(T))
                {
                    controller = (T)item;
                    return true;
                }
            }

            controller = null;
            return false;
        }

        public void AddController<T>() where T : Controller, new()
        {
            if (GetController(out T controller))
            {
                throw new ControllerAlreadyAddedException(
                    controller.ToString());
            }
            else
            {
                _controllers.Add(new T());
            }
        }

        public void RemoveController<T>() where T : Controller, new()
        {
            if (GetController(out T controller))
            {
                _controllers.Remove(controller);
            }
            else
            {
                throw new ControllerDoesNotExistException(
                    typeof(T).ToString());
            }
        }

        public async Task Run(
            HttpListenerRequest request, HttpListenerResponse response)
        {
            Controller target = null;
            var path = _requestHelper.GetPath(request);
            var context = new RouterContext()
            {
                Request = request,
                Response = response
            };

            _log.Write(path);

            foreach (var controller in _controllers)
            {
                if (controller.IsMatch(context))
                {
                    target = controller;
                    break;
                }
            }

            if (target != null)
            {
                await target.Run(context);
            }
            else
            {
                response.Close();
                throw new UrlPathNotFoundException(context.Request.Url);
            }
        }
    }
}