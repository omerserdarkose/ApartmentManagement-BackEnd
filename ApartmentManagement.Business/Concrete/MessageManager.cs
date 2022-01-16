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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        private IUserService _userManager;
        private IApartmentService _apartmentManager;
        private IUserMessageService _userMessageManager;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public MessageManager(IMessageDal messageDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userManager, IUserMessageService userMessageManager, IApartmentService apartmentManager)
        {
            _messageDal = messageDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userMessageManager = userMessageManager;
            _apartmentManager = apartmentManager;
        }

        //[TransactionScopeAspect]
        public void Add(MessageAddDto messageAddDto)
        {
            var newMessage = _mapper.Map<Message>(messageAddDto);

            newMessage.IuserId = _httpContextAccessor.HttpContext.User.GetLoggedUserId();
            newMessage.Idate = DateTime.Now;

            _messageDal.Add(newMessage);
        }

        //[SecuredOperation(Roles:("admin"))]
        [TransactionScopeAspect]
        public IResult SendMessageToAll(MessageAddDto messageAddForAllDto)
        {
            //UI dan gelen nesnenin mesaj bilgileri(subject ve messagetext) yeni mesaj olarak message tablosuna ekleniyor
            Add(messageAddForAllDto);
            //eklenen mesajin Id si aliniyor
            var messageId = GetLastMessageId();
            //kullanici listesi getiriliyor
            var userList = _apartmentManager.GetAllResident();
            //herbir kullanici icin mesaj entrysi olusturulup tabloya ekleniyor
            foreach (var user in userList.Data.ToArray())
            {
                _userMessageManager.Add(new UserMessageAddDto()
                {
                    MessageId = messageId,
                    ToUserId = user.Id,
                });
                //hangfire'a islem ekle herkese yeni mesajiniz var emaili atsin
            }

            return new SuccessResult(Messages.MessageSendAll);
        }

        [TransactionScopeAspect]
        public IResult SendMessageToOne(MessageAddForOneDto messageAddForOneDto)
        {
            //alici olup olmadigi check ediliyor
            if (!_userManager.UserExistsId(userId: messageAddForOneDto.RecipientId))
            {
                //yoksa aldici bulunamadi sonucu donuluyor
                return new ErrorResult(Messages.RecipientNotFound);
            }

            //UI dan gelen nesnenin eklenecek mesaj ile ilgili olan kisimlari(subject ve messagetext) yeni messageadd nesnesine map ediliyor
            var newMessage = _mapper.Map<MessageAddDto>(messageAddForOneDto);

            //message tablosuna yeni mesaj ekleniyor ve eklenen mesajin Id si aliniyor
            Add(newMessage);

            //eklenen mesajin Id si aliniyor
            var messageId = GetLastMessageId();

            _userMessageManager.Add(new UserMessageAddDto()
            {
                MessageId = messageId,
                ToUserId = messageAddForOneDto.RecipientId,
            });

            return new SuccessResult(Messages.MessageSend);
        }

        public int GetLastMessageId()
        {
            return _messageDal.GetLastMessageId();
        }


    }
}
