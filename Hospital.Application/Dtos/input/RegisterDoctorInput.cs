using Hospital.Domain.Enums;

namespace Hospital.Application.Dtos.input;

public record RegisterDoctorInput(
    string Name,
    string CRM,
    Specialty Specialty,
    string Email,
    string Phone,
    string Password,
    string ConfirmPassword);