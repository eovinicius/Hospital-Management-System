using Hospital.Application.Dtos.input;
using Hospital.Domain.Repositories;

namespace Hospital.Application.Commands;

public class RegisterDoctor
{
    private readonly IDoctorRepository _doctorRepository;

    public RegisterDoctor(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task Execute(RegisterDoctorInput input)
    {
        var doctorAlreadyExists = await _doctorRepository.GetByCRM(input.CRM);
        if (doctorAlreadyExists != null || doctorAlreadyExists?.Phone.Value == input.Phone)
        {
            throw new Exception("Doctor already exists");
        }
    }
}
