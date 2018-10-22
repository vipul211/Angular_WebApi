using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastucture.Models
{
    public class Employee:IModel
    {
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(maximumLength:10,MinimumLength =10)]
        public string PhoneNo { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedAt { get; set; }

        public Employee()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
