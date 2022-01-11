using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                              where um.ToUserId == userId
                              select new UserMessageIncomingViewDto()
                              {
                                  Id = um.Id,
                                  FromUserClaim = c.Name,
                                  FromUserName = u.FirstName + " " + u.LastName,
                                  FromUserBlock = b.Letter,
                                  FromUserDoorNumber = a.DoorNumber,
                                  MessageSubject = m.Subject,
                                  MessageText = m.MessageText,
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
                                       where um.ToUserId == userId
                                       select new UserMessageIncomingViewDto()
                                       {
                                           Id = um.Id,
                                           FromUserClaim = c.Name,
                                           FromUserName = u.FirstName + " " + u.LastName,
                                           FromUserBlock = b.Letter,
                                           FromUserDoorNumber = a.DoorNumber,
                                           MessageSubject = m.Subject,
                                           MessageText = m.MessageText,
                                           MessageDate = m.Idate,
                                           IsNew = um.IsNew,
                                           IsRead = um.IsRead,
                                           IsActive = um.IsActiveToUser,
                                           FromUserId = um.FromUserId,
                                       }).Distinct();
                return result.ToList();
            }
            return new List<UserMessageIncomingViewDto>();
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
                              where um.FromUserId == userId
                              select new UserMessageSentViewDto()
                              {
                                  Id = um.Id,
                                  ToUserClaim = c.Name,
                                  ToUserName = u.FirstName + " " + u.LastName,
                                  ToUserBlock = b.Letter,
                                  ToUserDoorNumber = a.DoorNumber,
                                  MessageSubject = m.Subject,
                                  MessageText = m.MessageText,
                                  MessageDate = m.Idate,
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
                                       where um.FromUserId == userId
                                       select new UserMessageSentViewDto()
                                       {
                                           Id = um.Id,
                                           ToUserClaim = c.Name,
                                           ToUserName = u.FirstName + " " + u.LastName,
                                           ToUserBlock = b.Letter,
                                           ToUserDoorNumber = a.DoorNumber,
                                           MessageSubject = m.Subject,
                                           MessageText = m.MessageText,
                                           MessageDate = m.Idate,
                                           IsActive = um.IsActiveFuser,
                                           ToUserId = um.ToUserId,
                                       }).Distinct();
                return result.ToList();
            }
        }
    }
}
