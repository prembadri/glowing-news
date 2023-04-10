using NEWS.BAL;
using System;

namespace glowing.news.tester
{
    public class Program
    {
        static void Main(string[] args)
        {
            NEWSParser newsParser = new NEWSParser("7b7509d6364e4930873f7b3ae16ef788", "Fj5N3rRS4Zf0XOxNVL4TQe1OpnqeZN24EdvftYFTNKM");
            //foreach (var item in newsParser.TopHeadlines())
            //{
            //    Console.WriteLine(item);

            //    Console.WriteLine();
            //}

            foreach (var item in newsParser.TopHeadLinesNewsCatcher())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
