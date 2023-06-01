using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementStatement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management");
            //Product Review List
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductId = 1, UserId = 1, Rating =3, Review ="Good", IsLike = true },
                new ProductReview(){ProductId = 2, UserId = 2, Rating =2, Review ="Good", IsLike = false },
                new ProductReview(){ProductId = 3, UserId = 3, Rating =1, Review ="Bad", IsLike = false },
                new ProductReview(){ProductId = 4, UserId = 4, Rating = 5, Review = "nice", IsLike = true},
                new ProductReview(){ProductId = 5, UserId = 5, Rating = 0, Review = "Bad", IsLike = false},
                new ProductReview(){ProductId = 6, UserId = 6, Rating = 7, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 7, UserId = 7, Rating = 10, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 8, UserId = 8, Rating = 9, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 9, UserId = 9, Rating = 8, Review = "nice", IsLike = true},
                new ProductReview(){ProductId = 10, UserId = 10, Rating = 2, Review = "Good", IsLike = false},
                new ProductReview(){ProductId = 11, UserId = 11, Rating = 5, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 12, UserId = 12, Rating = 9, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 13, UserId = 13, Rating = 1, Review = "Good", IsLike = false},
                new ProductReview(){ProductId = 14, UserId = 14, Rating = 8, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 15, UserId = 15, Rating = 3, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 16, UserId = 16, Rating = 7, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 17, UserId = 17, Rating = 4, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 18, UserId = 18, Rating = 2, Review = "Bad", IsLike = false},
                new ProductReview(){ProductId = 19, UserId = 19, Rating = 3, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 20, UserId = 20, Rating = 1, Review = "Bad", IsLike = false},
                new ProductReview(){ProductId = 21, UserId = 21, Rating = 10, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 22, UserId = 22, Rating = 7, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 23, UserId = 23, Rating = 8, Review = "Good", IsLike = true},
                new ProductReview(){ProductId = 24, UserId = 24, Rating = 4, Review = "Average", IsLike = true},
                new ProductReview(){ProductId = 25, UserId = 25, Rating = 2, Review = "Bad", IsLike = false},
            };

            // UC8-- > Using DataTable
            //table
            DataTable dataTable = new DataTable();
            //columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));
            //rows
            dataTable.Rows.Add(1, 1, 3, "Bad", false);
            dataTable.Rows.Add(2, 2, 2, "Bad", false);
            dataTable.Rows.Add(3, 3, 1, "Bad", false);
            dataTable.Rows.Add(4, 4, 5, "Good", true);
            dataTable.Rows.Add(5, 5, 0, "Bad", false);
            dataTable.Rows.Add(6, 6, 7, "Good", true);
            dataTable.Rows.Add(7, 7, 10, "Best", true);
            dataTable.Rows.Add(8, 8, 9, "Best", true);
            dataTable.Rows.Add(9, 9, 8, "Best", true);
            dataTable.Rows.Add(10, 10, 2, "Bad", false);
            dataTable.Rows.Add(11, 11, 5, "Good", true);
            dataTable.Rows.Add(12, 12, 9, "Best", true);
            dataTable.Rows.Add(13, 13, 1, "Bad", false);
            dataTable.Rows.Add(14, 14, 8, "Best", true);
            dataTable.Rows.Add(15, 15, 3, "Bad", false);
            dataTable.Rows.Add(16, 16, 7, "Good", true);
            dataTable.Rows.Add(17, 17, 4, "Good", true);
            dataTable.Rows.Add(18, 18, 2, "Bad", false);
            dataTable.Rows.Add(19, 19, 3, "Bad", false);
            dataTable.Rows.Add(20, 19, 1, "Bad", false);
            dataTable.Rows.Add(21, 19, 10, "Best", true);
            dataTable.Rows.Add(22, 19, 7, "Good", true);
            dataTable.Rows.Add(23, 19, 8, "Best", true);
            dataTable.Rows.Add(24, 19, 4, "Good", true);
            dataTable.Rows.Add(25, 19, 2, "Bad", false);


            Console.WriteLine("Press 1: for Adding a Prodcut Review In list");
            Console.WriteLine("Press 2: for Retrieve top 3 records from the list");
            Console.WriteLine("Press 3: for gets products with id 1,4,9 whose rating is greater then 3");
            Console.WriteLine("Press 4: for Retrieve count of review present for each productID");
            Console.WriteLine("Press 5: for  Retrieve only productId and review from the list");
            Console.WriteLine("Press 6: for  Skips top 5 records from the list");
            Console.WriteLine("Press 7 :for read the datatable and print its rows");
            Console.WriteLine("Enter Option");
            int option = Convert.ToInt32(Console.ReadLine());
            //Creating a list for Product Review
            //List<ProductReview> productReviews = new List<ProductReview>();
            Management management = new Management();
            DataTable dataTables = management.AddToDataTable(productReviewList);
            switch (option)
            {
                case 1:
                    foreach (var list in productReviewList)
                    {
                        Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                            + "Review: " + list.Review + "IsLike: " + list.IsLike);
                    }
                    break;
                case 2:
                    management.TopRecords(productReviewList);
                    Console.ReadLine();
                    break;
                case 3:
                    management.SelectRecords(productReviewList);
                    break;
                case 4:
                    management.RetrieveCountOfRecords(productReviewList);
                    break;
                case 5:
                    management.RetrieveProductIdAndReview(productReviewList);
                    break;
                case 6:
                    management.RetrieveProductsBySkippingTop5(productReviewList); 
                    break;
                case 7:
                    //DataTable dataTable = management.AddToDataTable(productReviewList);
                    break;
                case 8:
                    management.PrintTrueTable(dataTable);
                    break;
                case 9:
                    management.AverageRating(dataTable);
                    break;
                case 10:
                    management.ReviewIsBest(dataTable);
                    break;
                case 11:
                    management.UserID(dataTable);
                    break;

            }

            Console.ReadLine() ;
        }
    }
}
