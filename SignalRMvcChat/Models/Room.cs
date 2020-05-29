using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SignalRMvcChat.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public virtual ApplicationUser UserAccount { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}