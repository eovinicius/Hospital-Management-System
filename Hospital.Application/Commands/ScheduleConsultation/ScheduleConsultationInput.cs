using Hospital.Domain.Enums;

namespace Hospital.Application.Commands.MedicalScheduling;

public record ScheduleConsultationInput(
    DateTime Date,
    decimal Price,
    string Description,
    Guid PatientId,
    Guid DoctorId,
    SchedulingType SchedulingType);
