using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionDao();
            }
            else
            {
                dao = auctionDao;
            }
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "" && currentBid_lte > 0)
            {
                return dao.SearchByTitleAndPrice(title_like, currentBid_lte);
            }
            else if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            else if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }
            else
            {
                return dao.List();
            }
        }

        [HttpGet("{id}")]
        public Auction Get(int id)
        {
            Auction auction = dao.Get(id);
            return auction;
        }

        [HttpPost]
        public Auction Create(Auction auction)
        {
            Auction returnAuction = dao.Create(auction);
            if (returnAuction.IsValid)
            {
                return returnAuction;
            }
            return null;
        }
    }
}
