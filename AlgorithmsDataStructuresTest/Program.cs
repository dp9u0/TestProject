#region

using System;
using System.Collections.Generic;

#endregion

namespace AlgorithmsDataStructuresTest {
    internal class Program {
        private const int count = 10;
        private static Random random = new Random();
        private static List<int> inputs1 = new List<int>();
        private static List<int> inputs2 = new List<int>();

        private static void Main(string[] args) {
            var heap1 = new LHeap();
            var heap2 = new LHeap();
            while (inputs1.Count < count) {
                var input = random.Next(10, 99);
                if (!inputs1.Contains(input)) {
                    inputs1.Add(input);
                    heap1.Insert(input);
                }
            }

            Console.WriteLine("Inputs1:");
            foreach (var item in inputs1) {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();

            Console.WriteLine("LHeap1:");
            heap1.Print();

            while (inputs2.Count < count) {
                var input = random.Next(10, 99);
                if (!inputs1.Contains(input) && !inputs2.Contains(input)) {
                    inputs2.Add(input);
                    heap2.Insert(input);
                }
            }

            Console.WriteLine("Inputs2:");
            foreach (var item in inputs2) {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();

            Console.WriteLine("LHeap2:");
            heap2.Print();

            LHeap heapResult = new LHeap();

            heapResult.Merge(heap1);
            Console.WriteLine("After Merge LHeap1 :");
            heapResult.Print();

            heapResult.Merge(heap2);
            Console.WriteLine("After Merge LHeap2 :");
            heapResult.Print();
        }
    }
}