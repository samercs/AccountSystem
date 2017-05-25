using System.ComponentModel.DataAnnotations;
using AccountSystem.Entities.Enum;

namespace AccountSystem.Entities
{
    public class Account : EntityBase
    {
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public decimal InitalBalance { get; set; }
        public AccountType Type { get; set; }
        public string Note { get; set; }

    }
}