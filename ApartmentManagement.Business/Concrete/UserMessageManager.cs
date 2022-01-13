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

        
        public void Add(UserMessageAddDto userMessageAddDto)
        {
            var newUserMessage = _mapper.Map<UserMessage>(userMessageAddDto);

            newUserMessage.FromUserId = _currentUserId;
            newUserMessage.IuserId = _currentUserId;
            newUserMessage.Idate=DateTime.Now;
            newUserMessage.IsNew = true;
            newUserMessage.IsRead = false;
            newUserMessage.IsActiveFuser = true;
            newUserMessage.IsActiveToUser = true;
            _userMessageDal.Add(newUserMessage);
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
