using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Rockstar.Models;

namespace Rockstar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private RockStarDbContext _dbContext;
        
        public ArticleController(IConfiguration configuration, RockStarDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> Get()
        {
            try
            {
                return Ok(_dbContext.Article.ToList());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetArticlesByKeyWord(string keyword)
        {
            try
            {
                return Ok(_dbContext.Article.Where(article => article.Title.ToLower().Contains(keyword.ToLower())
                || article.Description.ToLower().Contains(keyword.ToLower())
                || article.Content.ToLower().Contains(keyword.ToLower())).ToList());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
