using Hospital.Domain.Enums;

namespace Hospital.Application.Dtos.input;

public record MedicalSchedulingInput(
    DateTime Date,
    decimal Price,
    string Description,
    Guid PatientId,
    Guid DoctorId,
    TypeScheduling TypeScheduling);
