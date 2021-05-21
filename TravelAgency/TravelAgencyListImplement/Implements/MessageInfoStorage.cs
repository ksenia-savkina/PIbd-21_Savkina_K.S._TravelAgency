using System;
using System.Collections.Generic;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyListImplement.Models;

namespace TravelAgencyListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;

        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessagesInfo)
            {
                result.Add(CreateModel(messageInfo));
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            int takingMessages = model.SkippingMessages ?? 0;
            int skippingMessages = model.TakingMessages ?? source.MessagesInfo.Count;
            if (model == null)
            {
                return null;
            }
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            if (model.SkippingMessages.HasValue && model.TakingMessages.HasValue && !model.ClientId.HasValue)
            {
                foreach (var messageInfo in source.MessagesInfo)
                {
                    if (skippingMessages > 0)
                    {
                        skippingMessages--;
                        continue;
                    }
                    if (takingMessages > 0)
                    {
                        result.Add(CreateModel(messageInfo));
                        takingMessages--;
                    }
                }
                return result;
            }
            foreach (var messageInfo in source.MessagesInfo)
            {
                if ((model.ClientId.HasValue && messageInfo.ClientId == model.ClientId) ||
                (!model.ClientId.HasValue && messageInfo.DateDelivery.Date == model.DateDelivery.Date))
                {
                    if (skippingMessages > 0)
                    {
                        skippingMessages--;
                        continue;
                    }
                    if (takingMessages > 0)
                    {
                        result.Add(CreateModel(messageInfo));
                        takingMessages--;
                    }
                }
            }
            return result;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            MessageInfo tempMessageInfo = null;
            foreach (var messageInfo in source.MessagesInfo)
            {
                if (messageInfo.MessageId == model.MessageId)
                {
                    tempMessageInfo = messageInfo;
                    break;
                }
            }
            if (tempMessageInfo != null)
            {
                return;
            }
            source.MessagesInfo.Add(CreateModel(model, tempMessageInfo));
        }

        public int Count()
        {
            int k = 0;
            foreach (var messageInfo in source.MessagesInfo)
            {
                k++;
            }
            return k;
        }

        public List<MessageInfoViewModel> GetMessagesForPage(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessagesInfo)
            {
                if ((model.ClientId.HasValue && model.ClientId.Value == messageInfo.ClientId) || !model.ClientId.HasValue)
                {
                    result.Add(CreateModel(messageInfo));
                }
            }
            return result;
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            messageInfo.MessageId = model.MessageId;
            messageInfo.ClientId = model.ClientId;
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.DateDelivery = model.DateDelivery;
            messageInfo.Subject = model.Subject;
            messageInfo.Body = model.Body;
            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                DateDelivery = messageInfo.DateDelivery,
                Subject = messageInfo.Subject,
                Body = messageInfo.Body
            };
        }
    }
}