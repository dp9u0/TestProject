// FileName:  Program.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180329 11:07
// Description:   

#region

using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

#endregion

namespace Unmanaged {

    internal static class Program {

        private static void Main(string[] args) {

            var array1 = new long[2515];
            var array2 = new long[2515];
            var array3 = new long[2515];
            var array4 = new long[2515];

            Console.WriteLine(array1[1]);
            Console.WriteLine(array2[1]);
            Console.WriteLine(array3[1]);
            Console.WriteLine(array4[1]);

            Console.WriteLine(array1[2500]);
            Console.WriteLine(array2[2500]);
            Console.WriteLine(array3[2500]);
            Console.WriteLine(array4[2500]);

            Do(() => {
                Fill(array1, 1111L);
            }
                , "Fill");

            Do(() => {
                Fill2(array2, 2222L);
            }
                , "Fill2");

            Do(() => {
                 Fill3(array3, 3333L);
            }
                , "Fill3");

            Do(() => {
                Fill4(array4, 4444L);
            }
                , "Fill4");

            Console.WriteLine(array1[1]);
            Console.WriteLine(array2[1]);
            Console.WriteLine(array3[1]);
            Console.WriteLine(array4[1]);

            Console.WriteLine(array1[2500]);
            Console.WriteLine(array2[2500]);
            Console.WriteLine(array3[2500]);
            Console.WriteLine(array4[2500]);

            Console.ReadLine();
        }

        static void Do(Action action, string name) {
            var wathch = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++) {
                action();
            }
            wathch.Stop();
            Console.WriteLine(name + " 耗时：" + wathch.Elapsed);
        }

        static void Fill(long[] array, long value) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = value;
            }
        }

        static void Fill2(long[] array, long value) {
            var i = 0;
            var end = array.Length - 1;
            while (i < end) {
                array[i] = value;
                array[i + 1] = value;
                i += 2;
            }
            if (array.Length % 4 == 3) {
                array[array.Length - 3] = value;
                array[array.Length - 2] = value;
                array[array.Length - 1] = value;
            } else if ((array.Length % 4) == 2) {
                array[array.Length - 2] = value;
                array[array.Length - 1] = value;
            } else if (array.Length % 4 == 1) {
                array[array.Length - 1] = value;
            }
        }


        static void Fill3(long[] array, long value) {
            Vector<long> v = new Vector<long>(value);
            var i = 0;
            var end = array.Length - 3;
            var leng = Vector<long>.Count;
            while (i < end) {
                v.CopyTo(array, i);
                i += leng;
            }
            if (array.Length % leng == 3) {
                array[array.Length - 3] = value;
                array[array.Length - 2] = value;
                array[array.Length - 1] = value;
            } else if ((array.Length % leng) == 2) {
                array[array.Length - 2] = value;
                array[array.Length - 1] = value;
            } else if (array.Length % leng == 1) {
                array[array.Length - 1] = value;
            }
        }

        static  void Fill4(long[] array, long value) {
            Util.Memset(array, value, array.Length);
        }


        public static class Util {
            static Util() {
                var dynamicMethod = new DynamicMethod("Memset", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard,
                    null, new[] { typeof(IntPtr), typeof(long), typeof(int) }, typeof(Util), true);

                var generator = dynamicMethod.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldarg_1);
                generator.Emit(OpCodes.Ldarg_2);
                generator.Emit(OpCodes.Initblk);
                generator.Emit(OpCodes.Ret);
                MemsetDelegate = (Action<IntPtr, long, int>)dynamicMethod.CreateDelegate(typeof(Action<IntPtr, long, int>));
            }

            public static void Memset(long[] array, long what, int length) {
                var gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                MemsetDelegate(gcHandle.AddrOfPinnedObject(), what, length);
                gcHandle.Free();
            }

            private static readonly Action<IntPtr, long, int> MemsetDelegate;

        }


    }

}