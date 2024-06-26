namespace Hospital.Application.Dtos.input;

public record MedicalAppointmentInput(string Name, string Description, DateTime Date, Guid DoctorId, Guid PatientId, decimal Price);