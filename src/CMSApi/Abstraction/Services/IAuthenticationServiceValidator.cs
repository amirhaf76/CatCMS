using System.ComponentModel.DataAnnotations;

namespace CMSApi.Abstraction.Services
{
    public interface IAuthenticationServiceValidator
    {
        ValidationResult Validate();
    }
}
