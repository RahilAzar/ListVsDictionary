using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("test started");
            var MockData = new ListBuilder();
            MockData.GenerateList();


            //var LinQTest = new CompareWithList();
            //LinQTest.Compare(MockData);

            //var LinQWithParallel = new CompareWithListInParallel();
            //LinQWithParallel.Compare(MockData);

            //var CompareDictionary = new CompareWithDictionary();
            //CompareDictionary.Compare(MockData);

            var CompareDictionaryInParalel = new CompareWithDictionaryInParallel();
            CompareDictionaryInParalel.Compare(MockData);
            Console.Read();
        }
    }
}
