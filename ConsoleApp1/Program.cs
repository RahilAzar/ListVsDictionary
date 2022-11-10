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

            //var ListTest = new CompareWithList();
            //ListTest.Compare(MockData);

            //var ListWithParallel = new CompareWithListInParallel();
            //ListWithParallel.Compare(MockData);

            //var CompareDictionary = new CompareWithDictionary();
            //CompareDictionary.Compare(MockData);

            var CompareDictionaryInParalel = new CompareWithDictionaryInParallel();
            CompareDictionaryInParalel.Compare(MockData);

            Console.Read();
        }
    }
}
