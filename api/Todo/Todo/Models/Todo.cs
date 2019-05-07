using System;
using System.Collections.Generic;

namespace Todo.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public string Priority { get; set; }
        public bool? IsComplete { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UserId { get; set; }
    }
}
