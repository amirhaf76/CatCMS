namespace CMS.Application.Abstraction.Services
{
    public interface IUserProvider
    {
        /// <summary>
        /// Throw exception, if it wasn't found userId.
        /// </summary>
        /// <exception cref="UserNotFoundException">If user id is not found, it will throw exception</exception>
        int UserId { get; }
    }


}
