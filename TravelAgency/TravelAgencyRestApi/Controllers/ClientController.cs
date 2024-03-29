using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.BusinessLogics;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;

        private readonly MailLogic _mailLogic;

        private readonly int _passwordMaxLength = 50;

        private readonly int _passwordMinLength = 10;

        private readonly int messagesOnPage = 5;

        public ClientController(ClientLogic logic, MailLogic mailLogic)
        {
            _logic = logic;
            _mailLogic = mailLogic;
            if (messagesOnPage < 1)
            {
                messagesOnPage = 5;
            }
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel { Email = login, Password = password })?[0];

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page)
        {
            var messages = _mailLogic.Read(new MessageInfoBindingModel { ClientId = clientId, SkippingMessages = (page - 1) * messagesOnPage, TakingMessages = messagesOnPage + 1 });
            return (messages.Take(messagesOnPage).ToList(), !(messages.Count() <= messagesOnPage));
        }

        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        private void CheckData(ClientBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"^[A-Za-z0-9]+(?:[._%+-])?[A-Za-z0-9._-]+[A-Za-z0-9]@[A-Za-z0-9]+(?:[.-])?[A-Za-z0-9._-]+\.[A-Za-z]{2,6}$"))
            {
                throw new Exception("� �������� ������ ������ ���� ������� �����");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"������ ������ ����� ����� �� {_passwordMinLength} �� {_passwordMaxLength}, �������� �� ����, ���� � ����������� ��������");
            }
        }
    }
}