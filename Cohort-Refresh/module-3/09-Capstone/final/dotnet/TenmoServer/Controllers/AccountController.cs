using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDAO accountDAO;
        private readonly ITransferDAO transferDAO;

        public AccountController(IAccountDAO _accountDAO, ITransferDAO _transferDAO)
        {
            accountDAO = _accountDAO;
            transferDAO = _transferDAO;
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Account a = accountDAO.GetAccountByUserId(userId.Value);
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a.Balance);
        }

        [HttpGet("transfers")]
        public IActionResult GetTransfers()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            return Ok(transferDAO.GetTransfersForUser(userId.Value));
        }

        [HttpGet("pending")]
        public IActionResult GetPendingTransfers()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            return Ok(transferDAO.GetPendingTransfersForUser(userId.Value));
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
