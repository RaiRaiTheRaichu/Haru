using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp.Net;
using Haru.Exceptions;
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
            // log path
            var path = _requestHelper.GetPath(request);
            await _log.Write(path);

            // run controller
            var context = new RouterContext()
            {
                Request = request,
                Response = response
            };
            var controller = _controllers.First(x => x.IsMatch(context));
            await controller.Run(context);
        }
    }
}