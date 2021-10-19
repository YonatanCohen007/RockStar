using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsAPI;
using NewsAPI.Models;
using Rockstar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rockstar.Services
{
    public class Worker : IWorker
    {
        private NewsApiClient _newsApiClient;
        private IConfiguration _configuration;
        private readonly IServiceProvider _provider;
        private RockStarDbContext _rockStarDbContext;
        private DateTime _oneWeekAgo = DateTime.Now.AddDays(-(int) DateTime.Now.DayOfWeek - 7);

        public Worker(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _provider = serviceProvider;
            _configuration = configuration;
            _newsApiClient = new NewsApiClient(_configuration.GetSection("NewsApiKey").Value);
            
            Initialize();
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                //Models.Source c = new Models.Source(){
                //    Id = "test",
                //    Name = "test author",
                //    Category = "test title",
                //    Description = "test desc",
                //    Url = "test url",
                //    Country = "test img",
                //    Language = "test content"
                //};
                //_rockStarDbContext.Source.Add(c);
                //_rockStarDbContext.SaveChanges();
                string a = _configuration.GetSection("NewsApiKey").Value;
                await Task.Delay(5000);
            }
        }

        private void Initialize()
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                _rockStarDbContext = scope.ServiceProvider.GetService<RockStarDbContext>();
                //Models.Source c = new Models.Source()
                //{
                //    Id = "test",
                //    Name = "test author",
                //    Category = "test title",
                //    Description = "test desc",
                //    Url = "test url",
                //    Country = "test img",
                //    Language = "test content"
                //};
                //_rockStarDbContext.Source.Add(c);

                //_rockStarDbContext.SaveChanges();
                try
                {
                    Models.Source c = _rockStarDbContext.Source.FirstOrDefault();
                }
                catch (Exception e)
                {

                    throw;
                }
                
            }
            
            //if (_rockStarDbContext.Source.FirstOrDefault() == null)
            //{
            //    foreach (NewsAPI.Models.Source source in _newsApiClient.GetAllSources().Result.Sources)
            //    {
            //        _rockStarDbContext.Add(new Models.Source()
            //        {
            //            Id = source.Id,
            //            Name = source.Name,
            //            Description = source.Description,
            //            Url = source.Url,
            //            Category = source.Category,
            //            Language = source.Language,
            //            Country = source.Country
            //        });
            //    }

            //}

            //if (_rockStarDbContext.Article.FirstOrDefault() == null)
            //{
            //    EverythingRequest everythingRequest = new EverythingRequest()
            //    {
            //        Q = _configuration.GetSection("KeyWordFilter").Value,
            //        SortBy = NewsAPI.Constants.SortBys.PublishedAt,
            //        Language = NewsAPI.Constants.Languages.EN,
            //        From = _oneWeekAgo
            //    };
            //    foreach (NewsAPI.Models.Article article in _newsApiClient.GetEverything(everythingRequest).Articles)
            //    {
            //        _rockStarDbContext.Add(new Models.Article()
            //        {
            //            Source = article.Source.Id,
            //            Author = article.Author,
            //            Title = article.Title,
            //            Description = article.Description,
            //            Url = article.Url,
            //            UrlToImage = article.UrlToImage,
            //            PublishedAt = article.PublishedAt,
            //            Content = article.Content
            //        });
            //    }
            //}

            
        }
    }
}