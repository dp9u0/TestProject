using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambda {
    class Class1 {

        public void Test0() {
            //Create anonymous object
            var person = new {
                Name = "Jesse",
                Age = 28,
                /*
                //错误	CS0828	无法将 lambda 表达式 赋予匿名类型属性	DelegateLambda       
                Ask = (string question) => {
                    Console.WriteLine("The answer to `" + question + "` is certainly 42!");
                }*/
            };

            //Execute function
            //person.Ask("Why are you doing this?");
        }
        public void Test1() {
            var person = new {
                Name = "Florian",
                Age = 28,
                Ask = (Action<string>)((string question) => {
                    Console.WriteLine("The answer to `" + question + "` is certainly 42!");
                })
            };
            //Execute function
            person.Ask("Why are you doing this?");
        }



        public void Test2() {

            dynamic person = null;
            person = new {
                Name = "Jesse",
                Age = 28,
                Ask = (Action<string>)((string question) => {
                    Console.WriteLine("The answer to `" + question + "` is certainly 42! My age is " + person.Age + ".");
                })
            };

            //Execute function
            person.Ask("Why are you doing this?");
        }
    }
}
