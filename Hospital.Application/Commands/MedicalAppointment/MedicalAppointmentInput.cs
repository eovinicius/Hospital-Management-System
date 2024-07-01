namespace Hospital.Application.Commands.MedicalAppointment;

public record MedicalAppointmentInput(string Name, string Description, DateTime Date, Guid DoctorId, Guid PatientId, decimal Price, List<MedicalReportInput> MedicalReportInputs);

public record MedicalReportInput(string Diagnosis, string Treatment, string Recommendations);