using Hospital.Domain.Entities;
using Hospital.Domain.Shared;

namespace Hospital.Domain.Repositories;

public interface IPatientRepository : IRepositoryGeneric<Patient>
{
    Task<Patient> GetByDocument(string document);
}
