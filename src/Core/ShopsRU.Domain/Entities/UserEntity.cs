using ShopRU.Domain.Enums;
using ShopsRU.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            CreatedDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        public UserTypes UserType { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public Employee Employee { get; set; }
        [NotMapped]

        public Affiliate Affiliate { get; set; }
        [NotMapped]

        public Customer Customer { get; set; }

    }
}
