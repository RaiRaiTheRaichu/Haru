using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Haru.Extensions;
using Haru.Models;
using Haru.Server.Helpers;
using Haru.Utils;

namespace Haru.Server.Http
{
    public class Router
    {
        private readonly List<Controller> _controllers;

        public Router()
        {
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
            var misses = 0;
            var path = RequestHelper.GetPath(request);
            var context = new RouterContext()
            {
                Request = request,
                Response = response,
                HasBody = (request.HttpMethod == "POST")
            };

            Log.Write(path);

            foreach (var controller in _controllers)
            {
                if (controller.IsMatch(context))
                {
                    await controller.Run(context);
                }
                else
                {
                    ++misses;
                }
            }

            if (misses == _controllers.Count)
            {
                throw new UrlPathNotFoundException(context.Request.Url);
            }

            response.Close();
        }
    }
}