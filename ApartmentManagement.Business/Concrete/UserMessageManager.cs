using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Aspects.Autofac;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Message;
using ApartmentManagement.Entities.Dtos.UserMessage;
using AutoMapper;

namespace ApartmentManagement.Business.Concrete
{
    public class UserMessageManager:IUserMessageService
    {
        private IUserMessageDal _userMessageDal;
        private IMessageService _messageManager;
        private IUserService _userManager;
        private IMapper _mapper;

        public UserMessageManager(IUserMessageDal userMessageDal, IMessageService messageManager, IMapper mapper, IUserService userManager)
        {
            _userMessageDal = userMessageDal;
            _messageManager = messageManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        //[TransactionScopeAspect]
        public IResult AddMessageForOne(UserMessageSendToOneDto messageSendToOneDto)
        {
            //alici olup olmadigi check ediliyor
            if (!_userManager.UserExists(messageSendToOneDto.RecipientId))
            {
                //yoksa aldici bulunamadi sonucu donuluyor
                return new ErrorResult(Messages.RecipientNotFound);
            }

            //userMessage entry si olusuruluyor ve UI dan gelen nesneden ilgili alan(aliciId) map ediliyor
            var newUserMessage = _mapper.Map<UserMessage>(messageSendToOneDto);

            //UI dan gelen nesnenin eklenecek mesaj ile ilgili olan kisimlari(subject ve messagetext) yeni message nesnesine map ediliyor
            var newMessage = _mapper.Map<MessageAddDto>(messageSendToOneDto);

            //message tablosuna yeni mesaj ekleniyor ve eklenen mesajin Id si aliniyor
            var messageId = _messageManager.Add(newMessage);

            //usermessage entrysindeki messageId bilgisi ekleniyor
            newUserMessage.MessageId = messageId;

            //newUserMessage.FromUserId = currentUserID;
            //newUserMessage.IUserId= currentUserID;
            //newUserMessage.Idate =DateTime.Now;

            _userMessageDal.Add(newUserMessage);

            return new SuccessResult(Messages.MessageSend);
        }

        //[TransactionScopeAspect]
        public IResult AddMessageForAll(UserMessageSendToAllDto messageSendToAllDto)
        {
            var newMessage = _mapper.Map<MessageAddDto>(messageSendToAllDto);
        }
    }
}
