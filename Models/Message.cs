using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiperForBsk.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public string Key { get; set; }
        public int Step { get; set; }
        public int Counter { get; set; }
    }
}
