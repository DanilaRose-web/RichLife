using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RIchLife.Utilites.Page;

namespace RichLife.IUserServices.Models.Request
{
    public class ListOfUsersRequest:IPageRequest
    {
        public string Search { get; set; }
        [Required]
        public int Skip { get; set; }
        [Required]
        public int Take { get; set; }
    }
}
