using CursoBackend.Controllers;

namespace CursoBackend.Services.Interfaces
{
    public interface IPeopleService
    {
        bool Validate(People people);
    }
}