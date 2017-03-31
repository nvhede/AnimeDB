using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeDB.Models.Requests
{
    public class UpdateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}