#region

using System;
using System.Collections.Generic;

#endregion

namespace YieldReturnDemo {
    public class MyList2 {
        private static Random rand = new Random(DateTime.Now.Millisecond);

        public IEnumerable<string> Get1() {
            for (int i = 0; i < 15; i++) {
                yield return "Test_" + i;
            }
        }


        public IEnumerable<string> Get2() {
            var test1 = "";
            Console.WriteLine(test1);
            for (int i = 0; i < 15; i++) {
                var test2 = rand.Next().ToString();
                test1 += test2;
                Console.WriteLine(test1);
                yield return "Test_" + i + "_" + test2;
            }
        }


        public IEnumerable<string> Get3() {
            yield return "Test";
        }
    }
}