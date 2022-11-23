using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Mail;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class MailDialogListController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/mail/dialog/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = MailService.GetConversations();
            var body = new ResponseModel<MailModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}