using System;

namespace CryptographyDemo {

    public static class Program {
        public static void Main() {
            Test1();
            Test2();
            Test3();
        }


        private static void Test1() {
            RijndaelExample.Run();
        }

        private static void Test2() {
            Cryptographer.Run();
        }

        private static void Test3() {
            RSAExample.Run();
        }
    }
   
}
