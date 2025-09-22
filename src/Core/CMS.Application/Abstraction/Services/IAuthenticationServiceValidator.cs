using System.ComponentModel.DataAnnotations;

namespace CMS.Application.Abstraction.Services
{
    public interface IAuthenticationServiceValidator
    {
        ValidationResult Validate();
    }
}
