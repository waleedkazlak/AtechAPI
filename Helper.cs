using AtechAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI
{
    /// <summary>
    /// Helper class <meaningful name> and static class and method to use without creating instance of class
    /// </summary>
    public static class Helper
    {
        // constant integer could be changes any time for not using direct value in method code implementation <meaningful name>
        const int NUMBER_TO_COMPARE = 10;

        /// <summary>
        /// check the addition of two numbers result compared with the constant value <meaningful name of method and its parameter>
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static string CheckAdditionNumbers(int firstNumber, int secondNumber)
        {
            // use one line of code with ternary statement
            return (firstNumber + secondNumber > NUMBER_TO_COMPARE) ? $"The result greater than {NUMBER_TO_COMPARE}"
                                                                   : $"The result less than or equal to {NUMBER_TO_COMPARE}";
        }
    }

    public class ProductsMockupSingletone
    {
        static List<Product> instance;


        private static object locker = new object();

        private protected ProductsMockupSingletone()
        {

        }

        private static void PopulateList()
        {
            instance = new List<Product>();
            for (int i = 1; i < 30; i++)
            {
                instance.Add(new Product { Id = i, Name = $"Product {i}", Description = $"This is dummy product number: {i}", Price = 10 + i });
            }
        }

        public static List<Product> GetProductsMockup()
        {

            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        PopulateList();
                    }
                }
            }
            return instance;
        }

    }
}
