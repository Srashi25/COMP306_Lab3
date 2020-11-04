using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Group4_Lab3.DbData;
using Group4_Lab3.Models;
using Group4_Lab3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Lab3.Controllers
{
    public class ReviewsController : Controller
    {
        private static AmazonDynamoDBClient client;
        private static DynamoDBContext _context;

        private readonly MovieAppDbContext _movieContext;
        private static Review newReview;

        public ReviewsController(MovieAppDbContext context)
        {
            _movieContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReview(int id)
        {
            Movie movie = _movieContext.Movies.FirstOrDefault(m => m.MovieId == id);
            User loggedUser = _movieContext.Users.FirstOrDefault(u => u.Email == movie.UserEmail);
            if (movie != null)
            {
                MovieReview mrm = new MovieReview()
                {
                    MovieId = id,
                    Review = new Review() { UserEmail =  loggedUser.Email}
                };
                return View(mrm);
            }
            else
            {
                //TempData["message"] = $"{LoggedUser.UserName}, you can't add Review to your own recipe!";
                return RedirectToAction("DataPage");
            }
        }

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {

                await CreateTable("Review", "ReviewID", movieReview.Review, movieReview.MovieId);
                return RedirectToAction("Index", "Movies");
            }
            return View(movieReview);
        }

        private async Task CreateTable(string tabNam, string hashKey, Review review, int movId)
        {
            client = new AmazonDynamoDBClient(RegionEndpoint.USEast2);
            var tableResponse = await client.ListTablesAsync();
            if (!tableResponse.TableNames.Contains(tabNam))
            {
                await Task.Run(async () =>
                {
                    await client.CreateTableAsync(new CreateTableRequest
                    {
                        TableName = tabNam,
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 3,
                            WriteCapacityUnits = 1
                        },
                        KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = hashKey,
                            KeyType = KeyType.HASH
                        }
                    },
                        AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = hashKey, AttributeType=ScalarAttributeType.S }
                    }

                    });

                    bool isTableAvailable = false;
                    while (!isTableAvailable)
                    {
                        Console.WriteLine("Waiting for table to be active...");
                        Thread.Sleep(5000);
                        var tableStatus = await client.DescribeTableAsync(tabNam);
                        isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                    }
                });
                SaveReview(review, movId);

            }
            else
            {
                SaveReview(review, movId);
            }
        }

        public async void SaveReview(Review review, int movId)
        {
            //Set a local DB context
            _context = new DynamoDBContext(client);
            newReview = new Review {
                ReviewDescription = review.ReviewDescription,
                ReviewID = Guid.NewGuid().ToString(),
                MovieId = movId,
                Title = review.Title,
                UserEmail = review.UserEmail
            };
            //Save an review object
            await _context.SaveAsync<Review>(review);
          
        }
    }
}
