﻿using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Mail;
using Haru.Framework.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class MailDialogListController : Controller
    {
        private readonly MailService _mailService;

        public MailDialogListController()
        {
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