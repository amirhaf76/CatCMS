namespace CMSApi.Abstraction.Services
{
    public interface IExceptionCaseService
    {
        Exception CreateUsernameOrPasswordIsIncorrectException();
    }
}
