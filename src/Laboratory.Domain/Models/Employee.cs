using Laboratory.Core.DomainObjects;

namespace Laboratory.Domain.Models
{
    internal class Employee : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
        public string RegistrationCode { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public EmployeeStatus EmployeeStatus { get; private set; }

        protected Employee() { }

        public Employee(string name, string documentNumber, DateTime registrationDate)
        {
            Name = name;
            DocumentNumber = documentNumber;
            RegistrationDate = registrationDate;
            RegistrationCode = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            EmployeeStatus = EmployeeStatus.Active;

            Validate();
        }

        public void UpdateName(string name) => Name = name;
        public void UpdateDocumentNumber(string documentNumber) => DocumentNumber = documentNumber;
        public void UpdateRegistrationDate(DateTime registrationDate) => RegistrationDate = registrationDate;
        public void UpdateDepartureDate(DateTime departureDate) => DepartureDate = departureDate;
        public void InactivateEmployee() => EmployeeStatus = EmployeeStatus.Inactive;
        public void ActivateEmployee() => EmployeeStatus = EmployeeStatus.Active;

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The Name field cannot be empty.");
            Validations.ValidateIfEmpty(DocumentNumber, "The Document Number field cannot be empty.");
            Validations.ValidateIfNull(RegistrationDate, "The Registration Date field cannot be empty.");
        }
    }
}
