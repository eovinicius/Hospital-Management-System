namespace Hospital.Application.Services;

public interface IIamageStorage
{
    Task<string> Save(Stream file);
}
