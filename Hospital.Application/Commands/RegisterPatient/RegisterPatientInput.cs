namespace Hospital.Application.Commands.RegisterPatient;

public record RegisterPatientInput(
    string Name,
    string Document,
    Stream DocumentImage,
    string Address,
    Guid? InsurancePlainId = null);
