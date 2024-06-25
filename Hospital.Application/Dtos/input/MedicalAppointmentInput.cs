namespace Hospital.Application.Dtos.input;

public record MedicalAppointmentInput(DateTime Date, decimal Price, string Description, Guid PatientId, Guid DoctorId);
