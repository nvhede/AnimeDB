using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Generic Class: Allows us to retrieve item of any type
/// </summary>
namespace AnimeDB.Models.Responses
{
    public class ItemResponse<T>: SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}