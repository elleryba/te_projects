using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        Transfer GetTransferById(int transferId);

        Transfer AddTransfer(NewTransfer transfer, int fromAcctId, int toAcctId);

        List<Transfer> GetTransfersForUser(int userId);

        List<Transfer> GetPendingTransfersForUser(int userId);

        bool ApproveTransfer(int transferId);

        bool RejectTransfer(int transferId);
    }
}
