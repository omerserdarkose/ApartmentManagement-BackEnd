using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Business.Concrete
{
    public class MessageManager:IMessageService
    {
        private IMessageDal _messageDal;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private int _currentUserId;

        public MessageManager(IMessageDal messageDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _messageDal = messageDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        }
        
        //[TransactionScopeAspect]
        public int Add(MessageAddDto messageAddDto)
        {
            var newMessage = _mapper.Map<Message>(messageAddDto);
            
            newMessage.IuserId = _currentUserId;
            newMessage.Idate=DateTime.Now;

            _messageDal.Add(newMessage);
            var lastMessage = GetMessageByDate(newMessage.Idate);

            return lastMessage.Id;
        }

        public Message GetMessageByDate(DateTime messageDate)
        {
            return _messageDal.Get(x => x.Idate == messageDate);
        }
    }
}
