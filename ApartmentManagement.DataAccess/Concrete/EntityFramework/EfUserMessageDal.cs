using System;
using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApartmentManagement.DataAccess.Context;
using ApartmentManagement.Entities.Dtos.UserMessage;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfUserMessageDal : EfEntityRepositoryBase<UserMessage, ApartmentManagementDbContext>, IUserMessageDal
    {
        public List<UserMessageIncomingViewDto> GetIncomingMessages(int userId)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = (from um in context.UserMessages
                              join u in context.Users
                                  on um.FromUserId equals u.Id
                              join uc in context.UserClaims
                                  on u.Id equals uc.UserId
                              join c in context.Claims
                                  on uc.ClaimId equals c.Id
                              join a in context.Apartments
                                  on u.Id equals a.OwnerId
                              join b in context.Blocks
                                  on a.BlockId equals b.Id
                              join m in context.Messages
                                  on um.MessageId equals m.Id
                              where um.ToUserId == userId && um.IsActiveToUser==true
                              select new UserMessageIncomingViewDto()
                              {
                                  Id = um.Id,
                                  FromUserClaim = c.Name,
                                  FromUserName = u.FirstName + " " + u.LastName,
                                  FromUserBlock = b.Letter,
                                  FromUserDoorNumber = a.DoorNumber,
                                  MessageId = m.Id,
                                  MessageSubject = m.Subject,
                                  MessageDate = m.Idate,
                                  IsNew = um.IsNew,
                                  IsRead = um.IsRead,
                                  IsActive = um.IsActiveToUser,
                                  FromUserId = um.FromUserId,
                              }).Union(from um in context.UserMessages
                                       join u in context.Users
                                           on um.FromUserId equals u.Id
                                       join uc in context.UserClaims
                                           on u.Id equals uc.UserId
                                       join c in context.Claims
                                           on uc.ClaimId equals c.Id
                                       join a in context.Apartments
                                           on u.Id equals a.HirerId
                                       join b in context.Blocks
                                           on a.BlockId equals b.Id
                                       join m in context.Messages
                                           on um.MessageId equals m.Id
                                       where um.ToUserId == userId && um.IsActiveToUser == true
                                       select new UserMessageIncomingViewDto()
                                       {
                                           Id = um.Id,
                                           FromUserClaim = c.Name,
                                           FromUserName = u.FirstName + " " + u.LastName,
                                           FromUserBlock = b.Letter,
                                           FromUserDoorNumber = a.DoorNumber,
                                           MessageId = m.Id,
                                           MessageSubject = m.Subject,
                                           MessageDate = m.Idate,
                                           IsNew = um.IsNew,
                                           IsRead = um.IsRead,
                                           IsActive = um.IsActiveToUser,
                                           FromUserId = um.FromUserId,
                                       }).Distinct().OrderByDescending(x=>x.MessageDate);
                return result.ToList();
            }
        }

        public List<UserMessageSentViewDto> GetSentMessages(int userId)
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = (from um in context.UserMessages
                              join u in context.Users
                                  on um.ToUserId equals u.Id
                              join uc in context.UserClaims
                                  on u.Id equals uc.UserId
                              join c in context.Claims
                                  on uc.ClaimId equals c.Id
                              join a in context.Apartments
                                  on u.Id equals a.OwnerId
                              join b in context.Blocks
                                  on a.BlockId equals b.Id
                              join m in context.Messages
                                  on um.MessageId equals m.Id
                              where um.FromUserId == userId && um.IsActiveFuser == true
                              select new UserMessageSentViewDto()
                              {
                                  Id = um.Id,
                                  ToUserClaim = c.Name,
                                  ToUserName = u.FirstName + " " + u.LastName,
                                  ToUserBlock = b.Letter,
                                  ToUserDoorNumber = a.DoorNumber,
                                  MessageId = m.Id,
                                  MessageSubject = m.Subject,
                                  MessageDate = m.Idate,
                                  IsNew = um.IsNew,
                                  IsActive = um.IsActiveFuser,
                                  ToUserId = um.ToUserId,
                              }).Union(from um in context.UserMessages
                                       join u in context.Users
                                           on um.ToUserId equals u.Id
                                       join uc in context.UserClaims
                                           on u.Id equals uc.UserId
                                       join c in context.Claims
                                           on uc.ClaimId equals c.Id
                                       join a in context.Apartments
                                           on u.Id equals a.HirerId
                                       join b in context.Blocks
                                           on a.BlockId equals b.Id
                                       join m in context.Messages
                                           on um.MessageId equals m.Id
                                       where um.FromUserId == userId && um.IsActiveFuser == true
                                       select new UserMessageSentViewDto()
                                       {
                                           Id = um.Id,
                                           ToUserClaim = c.Name,
                                           ToUserName = u.FirstName + " " + u.LastName,
                                           ToUserBlock = b.Letter,
                                           ToUserDoorNumber = a.DoorNumber,
                                           MessageId = m.Id,
                                           MessageSubject = m.Subject,
                                           MessageDate = m.Idate,
                                           IsNew = um.IsNew,
                                           IsActive = um.IsActiveFuser,
                                           ToUserId = um.ToUserId,
                                       }).Distinct().OrderByDescending(x => x.MessageDate);
                return result.ToList();
            }
        }
    }
}
