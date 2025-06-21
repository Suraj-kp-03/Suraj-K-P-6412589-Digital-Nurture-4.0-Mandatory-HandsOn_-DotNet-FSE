using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * The process in which a function calls itself directly or indirectly is know as recursion, this function is know as recursive function.
 * The recursive function must have a base case, which is the condition that stops the recursion.
 * The recursive function uses the same logic as the iterative function, but it is implemented in a different way.
 * The result calculated in each recursive call is used in the next recursive call or the previous recursive call.
 
 * Recusrive method is used here because it is simple to implemnent and understand.
 * We can calcualte the furure value, in a seperate recusrive method by passing present value, past growth rate, years as parameters.
 * Similarly, we can calculate the present value, Compound growth, and the value of increase using the past growth rates.
  */

// Compound growth: FV = PV*(1+r)^n
// PV - Present Value
// FV - Future Value
// r - Rate of growth
// n - Number of years
// (1+r)^n - Compound growth factor

namespace FinancialForecastUsingRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double presentValue = 1000;
            double[] pastRate = { 0.05, 0.07, 0.06, 0.3, -0.2 };
            Console.WriteLine("Enter the time in year to calculate the forecast: ");
            int futureYears = Convert.ToInt32(Console.ReadLine());

            double ForecastedFutureValue = Forecast(presentValue, pastRate, futureYears);
            Console.WriteLine("\nTHE FUTURE FINANCIAL FORECAST PREDICTED VALUE IS CALCULATED\n");
            Console.WriteLine($"Present Value: {presentValue}");
            Console.WriteLine($"Past Growth Rates: {string.Join(", ", pastRate)}");
            Console.WriteLine($"Forecast Period: {futureYears}");
            Console.WriteLine($"Forecasted Future Value: {ForecastedFutureValue}");
            Console.ReadLine();


        }
        static double ApplyRates(double presentValue, double[] rates, int ind) // This method applies the past growth rates to the present value recursively.
        {
            if (rates == null || ind < 0 || rates.Length == 0)
            {
                return presentValue;
            }
            double previousValue = ApplyRates(presentValue, rates, ind - 1);
            return previousValue * (1 + rates[ind]);
        }

        static double CompoundGrowthFactor(double baseVal, int yearExponent) // This method calculates the compound growth factor recursively.
        {
            if (yearExponent == 0)
            {
                return 1.0;
            }
            if (yearExponent % 2 == 0)
            {
                double half = CompoundGrowthFactor(baseVal, yearExponent / 2);
                return half * half;
            }
            else
            {
                double half = CompoundGrowthFactor(baseVal, (yearExponent - 1) / 2);
                return half * half * baseVal;
            }

        }
        static double SumsOfRates(double[] rates, int ind) // This method calculates the sum of past growth rates recursively.
        {
            if (rates == null || ind < 0 || rates.Length == 0)
                return 0.0;
            return rates[ind] + SumsOfRates(rates, ind - 1);
        }
        static double Forecast(double presentValue, double[] rates, int futureYears) // This method calculates the forecasted future value based on the present value, past growth rates, and future years recursively.
        {
            double valueAfterHistory;
            if(rates.Length != 0 && rates != null)
            {
                valueAfterHistory = ApplyRates(presentValue, rates, rates.Length - 1);
            }
            else
            {
                valueAfterHistory = ApplyRates(presentValue, rates, -1);
            }
            double avgRate = 0;
            if (rates != null && rates.Length > 0)
            {
                double sumRates = SumsOfRates(rates, rates.Length - 1);
                avgRate = sumRates / rates.Length;
            }
            double futureGrowthFactor = CompoundGrowthFactor(1 + avgRate, futureYears);
            return valueAfterHistory * futureGrowthFactor;
        }
    }
}

// The calcuation performed is based on the formula: FV = PV * (1 + r)^n, which is refered in the resources available in the internet. 


// Time Complxity:
/*
 > ApplyRates: O(n) - n depends on the number of past rates
 > CompoundGrowthFactor: O(log n) - uses divide and conquer approach, n is the exponent i.e., years
 > SumsOfRates: O(n) - n depends on the number of past rates
 > Forecast: O(n + log n) - O(n) for ApplyRates and SumsOfRates, O(log n) for CompoundGrowthFactor

 // OPTIMIZATION: 
 > We can use loops for ApplyRates and SumsOfRates to reduce the time complexity to O(n) for both, and the space complexity to O(1).
 > Can utilize the math functions to calculate the compound growth factor directly without recursion.
*/