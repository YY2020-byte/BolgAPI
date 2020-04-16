using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolgAPI.Models
{
    public class BlogModel
    {
        public int Id       { get; set; }
        public string UserName { get; set; }
        public string Pwd      { get; set; }
        public string UserTel { get; set; }

        public int MId      { get; set; }
        public int UserId  { get; set; }
        public string Content { get; set; }
        public DateTime Mtime   { get; set; }
        public int Mstate { get; set; }

        public int RId       { get; set; }
        public int RmId      { get; set; }
        public string Rcontent { get; set; }
        public DateTime Rtime    { get; set; }
        public int UId { get; set; }
    }
}