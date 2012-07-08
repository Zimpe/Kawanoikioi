
namespace Kawanoikioi.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.ServiceModel.DomainServices.EntityFramework;
    using Kawanoikioi.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data;
    using System.Data.Entity;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class ChatDomainService : DbDomainService<KawanoikioiDbContext>
    {
        public IQueryable<ChatRooms> GetChatRooms()
        {
            return this.DbContext.ChatRooms;
        }

        public ChatRooms GetChatRoom(int id)
        {
            return (from r in this.DbContext.ChatRooms
                    where r.ID == id
                    select r).SingleOrDefault();
        }

        public void CreateChatRoom(ChatRooms chatRoom)
        {
            DbEntityEntry<ChatRooms> entityEntry = this.DbContext.Entry(chatRoom);

            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.ChatRooms.Add(chatRoom);
            }
        }

        public void UpdateChatRoom(ChatRooms chatRoom)
        {
            this.DbContext.ChatRooms.AttachAsModified(chatRoom, this.DbContext);
        }

        public void RemoveChatRoom(ChatRooms chatRoom)
        {
            DbEntityEntry<ChatRooms> entityEntry = this.DbContext.Entry(chatRoom);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.ChatRooms.Attach(chatRoom);
                this.DbContext.ChatRooms.Remove(chatRoom);
            }
        }

        public IQueryable<ChatMessages> GetMessages(int roomID)
        {
            return this.DbContext.ChatMessages.Where(msg => msg.ChatRoomID == roomID);
        }

        public void CreateChatMessage(ChatMessages newMsg)
        {
            DbEntityEntry<ChatMessages> entityEntry = this.DbContext.Entry(newMsg);

            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.ChatMessages.Add(newMsg);
            }
        }

        protected override void OnError(DomainServiceErrorInfo errorInfo)
        {
            throw new DomainException(errorInfo.Error.Message, errorInfo.Error.InnerException);
        }
    }
}


