using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Lab3.Controllers
{
    public class ReviewsController : Controller
    {
        private static AmazonDynamoDBClient client;
        private static DynamoDBContext _context;
        private Review newReview;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(Review review)
        {
            if (ModelState.IsValid)
            {

                await CreateTable("Review", "ReviewID", review);
                return RedirectToAction("Index", "Movies");
            }
            return View(review);
        }

        private async Task CreateTable(string tabNam, string hashKey, Review review)
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
                SaveReview(review);

            }
            else
            {
                SaveReview(review);
            }
        }

        public async void SaveReview(Review review)
        {
            //Set a local DB context
            _context = new DynamoDBContext(client);
            newReview = new Review {
                ReviewDescription = review.ReviewDescription,
                ReviewID = Guid.NewGuid().ToString(),
                Movie = review.Movie,
                MovieId = review.MovieId,
                Title = review.Title
            };
            //Save an review object
            await _context.SaveAsync<Review>(review);
          
        }
    }
}
