using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Models
{
    public interface IModel
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}
