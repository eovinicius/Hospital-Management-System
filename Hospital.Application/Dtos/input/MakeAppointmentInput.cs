namespace Hospital.Application.Dtos.input;

public record MakeAppointmentInput(DateTime Date, decimal Price, string Description, Guid PatientId, Guid DoctorId);
