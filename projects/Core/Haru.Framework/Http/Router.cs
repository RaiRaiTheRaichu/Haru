using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp.Net;
using Haru.Framework.Exceptions;
using Haru.Framework.Models;
using Haru.Framework.Helpers;
using Haru.Framework.Utils;

namespace Haru.Framework.Http
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
            try
            {
                controller = (T)_controllers.First(x => x.GetType() == typeof(T));
                return true;
            }
            catch (InvalidOperationException)
            {
                controller = null;
                return false;
            }
        }

        public void AddController<T>() where T : Controller, new()
        {
            if (GetController(out T controller))
            {
                throw new ControllerAlreadyAddedException(controller.ToString());
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
                throw new ControllerDoesNotExistException(typeof(T).ToString());
            }
        }

        public async Task Run(HttpListenerRequest request, HttpListenerResponse response)
        {
            var path = _requestHelper.GetPath(request);
            var context = new RouterContext()
            {
                Request = request,
                Response = response
            };

            await _log.Write(path);

            try
            {
                var controller = _controllers.First(x => x.IsMatch(context));
                await controller.Run(context);
            }
            catch (InvalidOperationException)
            {
                response.Close();
                throw new UrlPathNotFoundException(context.Request.Url);
            }
        }
    }
}