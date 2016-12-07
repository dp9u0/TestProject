using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambda {
    class Program {
        static void Main() {
            Console.WriteLine("-----------------------");
            new Program().Main1();
            Console.WriteLine("-----------------------");
            new Program().Main2();
            Console.WriteLine("-----------------------");
            new Program().Main3();
            Console.WriteLine("-----------------------");
            new Program().Main4();
            Console.WriteLine("-----------------------");
            Test2.Test();
            Console.Read();

        }



        void Main1() {
            Action<string> DoSomethingLambda = (s) => {
                Console.WriteLine(s);
            };
        }

        void Main2() {

            int local = 5;

            Action<string> DoSomethingLambdaClosure = (s) => {
                Console.WriteLine(s + local);
            };

            local += 1;

            global = local;

            DoSomethingLambdaClosure("Test 1");
            DoSomethingNormalClosure("Test 2");
        }

        void Main3() {
            int local = 5;

            Action<string> DoSomethingLambdaClosure = (s) => {
                Console.WriteLine(s + global);
            };

            local += 1;

            global = local;

            DoSomethingLambdaClosure("Test 1");
            DoSomethingNormalClosure("Test 2");
        }

        void Main4() {
            /*           
            错误	CS0834	无法将具有语句体的 lambda 表达式转换为表达式树
             *  */
            //Expression<Func<MyModel, int>> expr = (model) => { return model.MyProperty;};
            Expression<Func<MyModel, int>> expr = (model) => model.MyProperty;
            var member = expr.Body as MemberExpression;
            var propertyName = member.Member.Name;
            Console.WriteLine("PropertyName:" + propertyName);
        }

        int global;

        void DoSomethingNormalClosure(string s) {
            Console.WriteLine(s + global);
        }



        void DoSomethingNormal(string s) {
            Console.WriteLine(s);
        }

    }
    public class MyModel {
        public int MyProperty {
            get; set;
        }
    }
}
