// FileName:  Program.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 15:05
// Description:   

#region

using System;

#endregion

namespace YieldReturnDemo {

    internal class Program {

        private static void Main(string[] args) {
            Console.Clear();
            Console.WriteLine("到命令行下，切换到windbg目录，执行adplus -hang -pn highcpu.exe -o c:\\dumps");
            Console.WriteLine("如果要停止，按Ctrl+C结束程序");
            Console.WriteLine("====================================================");

            while (true) {
                Console.SetCursorPosition(0, 3);
                Console.Write(DateTime.Now.Ticks.ToString());
            }

            Console.ReadKey();
        }

    }

}