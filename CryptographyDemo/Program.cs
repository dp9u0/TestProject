using System;

namespace CryptographyDemo {

    public static class Program {
        public static void Main() {
            Test2();
        }


        private static void Test1() {
            RijndaelExample.Run();
        }

        private static void Test2() {
            Cryptographer cryptographer1 = new Cryptographer();
            Cryptographer cryptographer2 = new Cryptographer();
            var source = "hello world";
            var strencrypto= cryptographer1.Encrypto(source);
            var strdecrypto = cryptographer2.Decrypto(strencrypto);

            cryptographer1.Dispose();
            cryptographer2.Dispose();

            Console.WriteLine(source);
            Console.WriteLine(strencrypto);
            Console.WriteLine(strdecrypto);
        }
    }
   
}
