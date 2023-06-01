using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementStatement
{
    public class Management
    {
        //UC-02----->  Retrieve top 3 records from the list who’s rating is high
        public void TopRecords(List<ProductReview> productReviewList)
        {
            //var result = this.productReviews.OrderByDescending(x => x.Rating).Take(3);
            var recordedData = (from productReviews in productReviewList
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        //UC-03----> gets products with id 1,4,9 whose rating is greater then 3
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        //var result = this.productReviews.Where(x => x.Rating > 3 && (x.ProductId == 1 || x.ProductId == 3 || x.ProductId == 9));

        // UC-04----> groups the products by reviews
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Count);
            }
            /*var result = this.listProductReview.GroupBy(x => x.ProductId);
             foreach (var data in result)
             {
                 Console.WriteLine("No Of Reviews For ProductId {0}:{1}", data.Key, data.Count());
                 PrintList(data.ToList());
             }*/
        }
        // UC-05----> Retrieve only productId and review from the list
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               select new
                               {
                                   productReviews.ProductId,
                                   productReviews.Review
                               };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id:- " + list.ProductId + " " + "Review: " + list.Review);
                Console.WriteLine("Product Id:- " + list.ProductId + " " + "Review: " + list.Review);
            }
            /*var result = listProductReview.Select(x => new { x.ProductId, x.Rating });
            foreach (var data in result)
            {
                Console.WriteLine("ProductId:" + data.ProductId + " " + "Rating:" + data.Rating);
            }*/
        }
        // UC-06----> Skips top 5 records from the list
        public void RetrieveProductsBySkippingTop5(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
            //var result = listProductReview.OrderByDescending(x => x.Rating).Skip(5);
        }
        // UC-08-------> Using DataTable 
        public DataTable AddToDataTable(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("UserId", typeof(int));
            table.Columns.Add("Rating", typeof(double));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("IsLike", typeof(bool));
            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductId, product.UserId, product.Rating, product.Review, product.IsLike);
            }
            return table;
        }
        public void PrintDataTable(EnumerableRowCollection<(int, int, int, string, bool)> products)
        {
            Console.WriteLine("ProductID  UserID  Rating  Review  Like");
            foreach (var item in products)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2 + " " + item.Item3 + " " + item.Item4 + " " + item.Item5);
            }
        }
        //UC-09------> method to print rows whose isLike is true
        public void PrintTrueTable(DataTable dataTable)
        {
            var products = from product in dataTable.AsEnumerable()
                           where (product.Field<bool>("isLike") == true)
                           select (product.Field<int>("ProductID"), product.Field<int>("UserID"), product.Field<int>("Rating"),
                           product.Field<string>("Review"), product.Field<bool>("isLike"));
            PrintDataTable(products);
        }
        //UC-10------> Find average rating of the each productId
        public  void AverageRating(DataTable dataTable)
        {
            var average = (from product in dataTable.AsEnumerable()
                           select (product.Field<int>("Rating"))).Average();
            Console.WriteLine(average.ToString());
        }
        //UC-11------> Retreive all records from the list who’s review message contain “Best”
        public void ReviewIsBest(DataTable dataTable)
        {
            var products = from product in dataTable.AsEnumerable()
                           where (product.Field<string>("Review").Contains("Best"))
                           select (product.Field<int>("ProductID"), product.Field<int>("UserID"), product.Field<int>("Rating"),
                           product.Field<string>("Review"), product.Field<bool>("isLike"));
            PrintDataTable(products);
        }
        // UC-12-------> print only products whose userid is 10
        public void UserID(DataTable dataTable)
        {
            var products = from product in dataTable.AsEnumerable()
                           where (product.Field<int>("UserID") == 10)
                           select (product.Field<int>("ProductID"), product.Field<int>("UserID"), product.Field<int>("Rating"),
                           product.Field<string>("Review"), product.Field<bool>("isLike"));
            PrintDataTable(products);
        }
    }
}
