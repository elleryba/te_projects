using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly ITransferDAO transferDAO;
        private readonly IAccountDAO accountDAO;

        public TransfersController(ITransferDAO _transferDAO, IAccountDAO _accountDAO)
        {
            transferDAO = _transferDAO;
            accountDAO = _accountDAO;
        }

        [HttpGet("{id}")]
        public IActionResult GetTransfer(int id)
        {
            Transfer t = transferDAO.GetTransferById(id);
            if (t != null)
            {
                return Ok(t);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateTransfer(NewTransfer transfer)
        {
            IActionResult result = BadRequest();

            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Account fromAcct = accountDAO.GetAccountByUserId(transfer.UserFrom);
            Account toAcct = accountDAO.GetAccountByUserId(transfer.UserTo);
            if (fromAcct == null || toAcct == null)
            {
                return NotFound();
            }
            if (fromAcct.Balance < transfer.Amount)
            {
                return StatusCode(402); //402 = Payment Required, could be BadRequest
            }

            Transfer newTransfer = transferDAO.AddTransfer(transfer, fromAcct.AccountId, toAcct.AccountId);
            if (newTransfer != null)
            {
                result = Created("transfers/" + newTransfer.TransferId, newTransfer);
            }

            return result;
        }

        [HttpPut("{id}/approve")]
        public IActionResult ApproveTransfer(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Transfer transfer = transferDAO.GetTransferById(id);

            if (transfer == null)
            {
                return NotFound();
            }
            if (transfer.TransferType == TransferType.Request && transfer.AccountFrom.UserId == userId)
            {
                if (transfer.TransferStatus != TransferStatus.Pending)
                {
                    return Conflict();
                }
                else if (transferDAO.ApproveTransfer(id))
                {
                    return Ok(transferDAO.GetTransferById(id)); //return newly approved transaction
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Conflict(); //or BadRequest
            }
        }

        [HttpPut("{id}/reject")]
        public IActionResult RejectTransfer(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Transfer transfer = transferDAO.GetTransferById(id);

            if (transfer == null)
            {
                return NotFound();
            }
            if (transfer.TransferType == TransferType.Request && transfer.AccountFrom.UserId == userId)
            {
                if (transfer.TransferStatus != TransferStatus.Pending)
                {
                    return Conflict();
                }
                else if(transferDAO.RejectTransfer(id))
                {
                    return Ok(transferDAO.GetTransferById(id)); //return newly rejected transaction
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Conflict(); //or BadRequest
            }
        }

        private int? GetCurrentUserId()
        {
            string userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return null;
            int.TryParse(userId, out int userIdInt);
            return userIdInt;
        }
    }
}
