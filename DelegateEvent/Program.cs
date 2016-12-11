#region

using System;

#endregion

namespace DelegateEvent {
    internal class MyClass {
        public delegate void CompletedEventHandler();

        public CompletedEventHandler WorkCompletedDelegate;

        public event CompletedEventHandler WorkCompleted;

        public void Fire() {
            if (WorkCompleted != null) {
                WorkCompleted();
            }

            if (WorkCompletedDelegate != null) {
                WorkCompletedDelegate();
            }
        }
    }

    internal class Program {
        private static void TestEvent() {
            Console.WriteLine("test event");
        }

        private static void TestDelegate() {
            Console.WriteLine("test delegate");
        }

        private static void Main(string[] args) {
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