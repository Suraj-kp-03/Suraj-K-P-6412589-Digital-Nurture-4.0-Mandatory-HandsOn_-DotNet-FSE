using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Big O Notation:
 * Big O notation helps us to analize the effeciency of the algorithm, by calculating the time or space complexity.
 * This calculation is varies upon the number of inputs, the positon of the result found and how we utilized in implementing the algorithm.
 * This measure in  not the actul time taken, it is a theoritical measure which is being calculated based on the input size.
  

 * LINEAR SEARCH: 
 > BEST CASE - O(1) -- FOUND AT FIRST ITERATION
 > WORST CASE - O(n) -- FOUND AT THE LAST OR NOT IN THE LIST 
 > AVERAGE CASE - O(n) -- FOUND SOME WHERE IN THE LIST

 * BINARY SEARCH: 
 > BEST CASE - O(1) -- FOUND AT THE MID INDEXED ELEMENT 
 > WORST CASE - O(log n) -- FOUND AT THE LAST ITERATION OR NOT FOUND 
 > AVERAGE CASE - O(log n) -- FOUND IN LEFT HALF OF THE LIST OR RIGHT HALF OF THE LIST


// I use Open/Close Principle in this code. Creating a new class for Products allows us to extend functionality without modifying existing code.
// Basically, Ive created a class named Products that holds product details like ProductId, ProductName, and Category.
// Then base abstract class with abstract method Search which will be implemented by derived classes to provide specific search functionality(Linear Search, Binary Search)
*/

namespace ECommercePlatformSearchFunction
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Products(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }
    }

    public abstract class SearchingAlgorithm
    {
        public abstract List<Products> Searching(List<Products> products, string searchItem); // This method will be overridden in derived class to perfor the searching process based on the instance created.
    }

    public class LinearSearch : SearchingAlgorithm
    {
        public override List<Products> Searching(List<Products> products, string searchItem)
        {
            List<Products> result = new List<Products>(); // Use a new list to store results, not a single product. As well as to prevent Type mismatch. This will allow us to return multiple products if needed.
            foreach (var prod in products)
            {
                if (prod.ProductName.Equals(searchItem, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(prod);

                }
            }
            return result;
        }
    }

    public class BinarySearch : SearchingAlgorithm
    {
        public override List<Products> Searching(List<Products> products, string searchItem)
        {
            products.Sort((p1, p2) => p1.ProductName.CompareTo(p2.ProductName)); // Sorting by product name, This syntax uses a lambda expression to define the comparison logic and sorts the list in ascending order based on the ProductName property.
            List<Products> result = new List<Products>();
            int left = 0;
            int right = products.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int cmpVal = String.Compare(products[mid].ProductName, searchItem, true); // This line returns -1,0,1 that indicates whetaher the mid product name is less than, equal to, or greater than the searching product name.
                if (cmpVal == 0)
                {
                    result.Add(products[mid]);
                    break; // Found match, can break the loop.

                    /*
                     int i = mid-1;
                    // If we found a match, we can also check for duplicates on both sides of the mid index.
                    while (i >= left && String.Compare(products[i].ProductName, searchingProducts, true) == 0) // Searching duplicates for left side of the mid element.
                    {
                        result.Add(products[i]);
                        i--;
                    }
                    i = mid + 1; 
                    while(i<= right && String.Compare(products[i].ProductName, searchingProducts, true) == 0) // Searching duplicates for right side of the mid element.
                    {
                        result.Add(products[i]);
                        i++;
                    }
                    break;*/

                    // The above commented code can be used to find all duplicates of the searched product name.
                }
                else if (cmpVal > 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Products> products = new List<Products>
                {
                    new Products(101, "Laptop", "Electronics"),
                    new Products(102, "T-Shirt", "Clothing"),
                    new Products(103, "Shoes", "Footwear"),
                    new Products(104, "Mobile", "Electronics"),
                    new Products(105, "Headphones", "Electronics"),
                    new Products(106, "Mobile", "Electronics")
                };
            Console.WriteLine("Enter the product name to search:");
            string searchItem = Console.ReadLine();
            Console.WriteLine("LINEAR SEARCH RESULTS: ");
            SearchingAlgorithm linearsearch = new LinearSearch();
            List<Products> linearSearchResults = linearsearch.Searching(products, searchItem);
            if (linearSearchResults.Count == 0)
            {
                Console.WriteLine("No products found with the given name.");
                return; // Exit if no products found.
            }
            else
            {
                foreach (var prods in linearSearchResults)
                {
                    Console.WriteLine($"ProductId: {prods.ProductId}, ProductName: {prods.ProductName}, Category: {prods.Category}");
                }
            }
            Console.WriteLine("\nBINARY SEARCH RESULTS: ");
            SearchingAlgorithm binarysearch = new BinarySearch();
            List<Products> binarysearchresults = binarysearch.Searching(products, searchItem);
            if (binarysearchresults.Count == 0)
            {
                Console.WriteLine("No products found with the given name.");
            }
            else
            {
                foreach (var prods in binarysearchresults)
                {
                    Console.WriteLine($"ProductId: {prods.ProductId}, ProductName: {prods.ProductName}, Category: {prods.Category}");
                }
            }
            Console.ReadKey();
        }
    }
}

/* 
 * TIME COMPLEXITY:
   > Linear Search: O(n) - In the worst case, we may have to check every product in the list.
        >There are no sorting or additional operations that would increase the time complexity.

   > Binary Search: O(log n) - The list is sorted, so we can eliminate half of the remaining elements in each step.
        >The list must be sorted before performing the search operation, which takes O(n log n) time in the worst case.

SPACE COMPLEXITY:
   > Linear Search: O(1) - We are using a constant amount of space for the result list.
   > Binary Search: O(1) - We are using a constant amount of space for the result list, but we also sort the list which takes O(n log n) time and O(n) space in the worst case.

>> My platform suggests to use Linear Search for the products that have duplicate names, as it will return all matching products.
>> If you want to search products that are unique, you can use Binary Search for better performance.
>> However, you can also use Binary Search for duplicate names, it adds additional time complexity for returing all duplicates.
>> Preferable is to use Linear Search for all the products lists in the names and Binary Search for unique names and in larger datasets.
*/
