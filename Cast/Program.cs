using System;

namespace CastDemo {
    class Program {
        static void Main(string[] args) {
            Run();
        }



        static void Run() {
            A_1 a1 = new A_1();
            A_2 a2 = new A_2();
            //OK
            A_1 temp1 = a2;
            //OK
            A_2 temp2 = (A_2)temp1;
            //Running Error : Invalid Cast
            try {
                A_2 temp3 = (A_2)a1;
            } catch (Exception ex) {
                ConsoleWriteLine(ex);
            }

            B_1 b1 = (B_1)a1;

            B_2 b2 = (B_2)a2;

            //Cannot Complie
            //B_2 b1 = (B_1)a1;

            //explicit
            C_2 c1 = (C_2)new B_2();
            //implicit
            C_2 c2 = new A_2();
        }

        static void ConsoleWriteLine(Exception ex) {
            Console.WriteLine(ex.Message);
        }

    }

    public class A_1 {

        public int F1;

    }

    public sealed class A_2 : A_1 {

        public int F2;
    }

    public class B_1 {


        public static explicit operator B_1(A_1 source) {
            return new B_1() { F1 = source.F1 };
        }


        public int F1;
    }

    public sealed class B_2 : B_1 {

        public static explicit operator B_2(A_2 source) {
            return new B_2() { F1 = source.F1, F2 = source.F2 };
        }

        public int F2;
    }

    public class C_1 {

        public int F1;
    }


    public sealed class C_2 : C_1 {

        public static explicit operator C_2(B_2 source) {
            return new C_2() {
                F1 = source.F1
                , F2 = source.F2
            };
        }

        public static implicit operator C_2(A_2 source) {
            return new C_2() {
                F1 = source.F1
                , F2 = source.F2
            };
        }
        public int F2;
    }
}
