using Hospital.Domain.Enums;

namespace Hospital.Application.Commands.RegisterDoctor;

public record RegisterDoctorInput(
    string Name,
    string Crm,
    Stream CrmImage,
    List<Specialty> Specialty
);