namespace CMS.Application.Abstraction.Services
{
    public interface IExceptionCaseService
    {
        Exception CreateUsernameOrPasswordIsIncorrectException();
    }
}
