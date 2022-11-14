using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Message : BaseEntity
    {
        
        public String Content {get;set;}
        public DateTime CreateAt{get;set;} = DateTime.Now;
        
        public int SenderId {get;set;}
        public User SenderUser {get;set;}


        public int ReceiverId {get;set;}
        public User ReceiverUser {get;set;}
    
    }
}