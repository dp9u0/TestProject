using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent {
    class MyClass {
        public delegate void CompletedEventHandler();

        public event CompletedEventHandler WorkCompleted;
        public CompletedEventHandler WorkCompletedDelegate;

        public void Fire() {
            if (this.WorkCompleted != null) {
                this.WorkCompleted();
            }

            if (this.WorkCompletedDelegate != null) {
                this.WorkCompletedDelegate();
            }
        }
    }
    class Program {
        static void TestEvent() {
            Console.WriteLine("test event");
        }

        static void TestDelegate() {
            Console.WriteLine("test delegate");
        }

        static void Main(string[] args) {

            MyClass myObject = new MyClass();
            myObject.WorkCompletedDelegate += TestDelegate;
            myObject.WorkCompleted += TestEvent;

            myObject.Fire();
            myObject.WorkCompletedDelegate();
            /*
            错误	CS0070	事件“MyClass.WorkCompleted”只能出现在 += 或 -= 的左边(从类型“MyClass”中使用时除外)
            */
            //myObject.WorkCompleted();
        }
    }
}
