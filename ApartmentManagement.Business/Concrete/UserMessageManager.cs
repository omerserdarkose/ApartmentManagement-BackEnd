using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Constant;
using ApartmentManagement.Core.Aspects.Autofac;
using ApartmentManagement.Core.Extensions;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Message;
using ApartmentManagement.Entities.Dtos.UserMessage;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class UserMessageManager:IUserMessageService
    {
        private IUserMessageDal _userMessageDal;
        private IMessageService _messageManager;
        private IUserService _userManager;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;

        public UserMessageManager(IUserMessageDal userMessageDal, IMessageService messageManager, IMapper mapper, IUserService userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userMessageDal = userMessageDal;
            _messageManager = messageManager;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
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

            newUserMessage.FromUserId = _currentUserId; 
            newUserMessage.IuserId= _currentUserId;
            newUserMessage.Idate =DateTime.Now;

            _userMessageDal.Add(newUserMessage);

            return new SuccessResult(Messages.MessageSend);
        }

        //[SecuredOperation(Roles:("admin"))]
        //[TransactionScopeAspect]
        public IResult AddMessageForAll(UserMessageSendToAllDto messageSendToAllDto)
        {
            //UI dan gelen nesnenin mesaj bilgileri(subject ve messagetext) yeni message nesnesine map ediliyor
            var newMessage = _mapper.Map<MessageAddDto>(messageSendToAllDto);

            //message tablosuna yeni mesaj ekleniyor ve eklenen mesajin Id si aliniyor
            var messageId = _messageManager.Add(newMessage);
            //kullanici listesi getiriliyor
            var userList = _userManager.GetAll();
            //herbir kullanici icin mesaj entrysi olusturulup tabloya ekleniyor
            foreach (var user in userList.Data.ToArray())
            {
                _userMessageDal.Add(new UserMessage()
                {
                    FromUserId = _currentUserId,
                    ToUserId = user.Id,
                    MessageId = messageId,
                    IuserId = _currentUserId,
                    Idate = DateTime.Now
                });
                //hangfire'a islem ekle herkese yeni mesajiniz var emaili atsin
            }

            return new SuccessResult(Messages.MessageSendAll);
        }

        public IDataResult<List<UserMessageIncomingViewDto>> GetUserIncomingMessages()
        {
            var incomingMessages = _userMessageDal.GetIncomingMessages(_currentUserId);
            if (incomingMessages is null)
            {
                return new ErrorDataResult<List<UserMessageIncomingViewDto>>(Messages.UserMessageIncomingNotExist);
            }

            return new SuccessDataResult<List<UserMessageIncomingViewDto>>(incomingMessages);
        }

        public IDataResult<List<UserMessageSentViewDto>> GetUserSentMessages()
        {
            var sentMessages = _userMessageDal.GetSentMessages(_currentUserId);
            if (sentMessages is null)
            {
                return new ErrorDataResult<List<UserMessageSentViewDto>>(Messages.UserMessageSentNotExist);
            }

            return new SuccessDataResult<List<UserMessageSentViewDto>>(sentMessages);
        }
    }
}
