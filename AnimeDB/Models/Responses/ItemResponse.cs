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
        public T Item { get; set; }
    }
}