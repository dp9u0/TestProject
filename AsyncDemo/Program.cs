#region

using System;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Demo {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("测试开始！:{0}", Thread.CurrentThread.ManagedThreadId);
            AsyncMethod(0);
            Console.WriteLine("测试结束！:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        // 异步操作
        private static async void AsyncMethod(int input) {
            //同步执行
            Console.WriteLine("进入异步操作！:{0}", Thread.CurrentThread.ManagedThreadId);
            //此处会开新线程处理 AsyncWork 任务，然后方法马上返回  
            var result = await AsyncWork(input);
            //这之后的所有代码都会被封装成委托，在 AsyncWork 任务完成时调用  
            Console.WriteLine("最终结果{0}:{1}", result, Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("退出异步操作！:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        // 模拟耗时操作（异步方法）
        private static async Task<int> AsyncWork(int val) {
            for (int i = 0; i < 5; ++i) {
                //延迟100ms 后执行下面的任务
                await Task.Delay(100);
                Console.WriteLine("耗时操作{0}:{1}", i, Thread.CurrentThread.ManagedThreadId);
                val++;
            }
            return val;
        }
    }

}