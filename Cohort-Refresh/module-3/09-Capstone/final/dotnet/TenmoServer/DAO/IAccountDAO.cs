using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        Account GetAccountByUserId(int userId);
    }
}
