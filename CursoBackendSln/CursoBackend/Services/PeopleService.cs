using CursoBackend.Controllers;

namespace CursoBackend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            var isValid = !(string.IsNullOrEmpty(people.Name) || people.Name.Length > 100 || people.Name.Length < 3); 
            {
                
            };
            return isValid;
        }
    }
}