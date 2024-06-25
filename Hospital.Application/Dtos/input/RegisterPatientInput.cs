namespace Hospital.Application.Dtos.input;

public record RegisterPatientInput(string Name, string Document, string Email, string Phone, string Address, Guid? MedicalInsuranceId = null);
