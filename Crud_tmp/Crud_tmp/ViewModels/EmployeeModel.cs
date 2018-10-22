using Infrastucture.Models;
using System;

namespace Crud_tmp.ViewModels
{
    public class EmployeeModel : IModelConverter<Employee, EmployeeModel>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public EmployeeModel ConvertTo(Employee model) => new EmployeeModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            PhoneNo = model.PhoneNo,
            Email = model.Email,
            CreatedAt = model.CreatedAt,
            ModifiedAt = model.ModifiedAt
        };

        public Employee ConvertFrom(EmployeeModel model) => new Employee
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            PhoneNo = model.PhoneNo,
            Email = model.Email,
            CreatedAt = model.CreatedAt,
            ModifiedAt = model.ModifiedAt
        };
    }
}
