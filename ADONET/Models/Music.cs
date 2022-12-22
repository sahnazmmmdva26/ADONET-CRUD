using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Models
{
    internal class Music
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public string DeletedTime { get; set; }
       
        public Music(int id,string name,int duration,int categoryid,string deletedTime)
        {
            ID = id;
            Name = name;
            Duration = duration;
            CategoriesId=categoryid;
            DeletedTime = deletedTime;
        }
    }
}
