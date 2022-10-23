using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public double AskingPrice { get; set; }

        public string Condition { get; set; }

        public string UsedTime { get; set; }

        public string Catagory { get; set; }




    }
}
