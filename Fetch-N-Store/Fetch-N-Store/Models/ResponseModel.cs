using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fetch_N_Store.Models
{
    public class ResponseModel
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public int StatusCode { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public DateTime ResponseTime { get; set; }
    }
}