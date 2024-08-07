using CursoBackend.Controllers;

namespace CursoBackend.Services
{
    public class People2Service : IPeopleService
    {
        public bool Validate(People people)
        {
            var isValid = !(string.IsNullOrEmpty(people.Name) || people.Name.Length > 100 ); 
            {
                
            };
            return isValid;
        }
    }
}