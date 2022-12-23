using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Mail;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class MailDialogListController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly MailService _mailService;

        public MailDialogListController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _mailService = new MailService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/mail/dialog/list";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _mailService.GetConversations();
            var body = new ResponseModel<MailModel[]>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}