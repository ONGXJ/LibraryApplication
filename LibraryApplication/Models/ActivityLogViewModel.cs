using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class ActivityLog : BaseViewModel
    {
        public int Id { get; set; }
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public string CauserId { get; set; }
        public string CauserName { get; set; }
        public string CauserType { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DateStart { get; internal set; }
        public string DateEnd { get; internal set; }
    }
}
