using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo {
    class Test {

        public static void Test001() {
            Expression<Func<int, int>> expr = x => x + 1;
            Console.WriteLine(expr.ToString());  // x=> (x + 1)
            var func = expr.Compile();
            Console.WriteLine(func(123123));
            /*
            错误	CS0834	无法将具有语句体的 lambda 表达式转换为表达式树
             */
            // 下面的代码编译不通过
            //Expression<Func<int, int, int>> expr2 = (x, y) => {
            //    return x + y;
            //};
            //Expression<Action<int>> expr3 = x => {
            //};
        }



        public static void Test002() {
            Expression<Func<int, int>> expr = x => x + 1;
            Console.WriteLine(expr.ToString());  // x=> (x + 1)

            var lambdaExpr = expr; // is LambdaExpression;
            Console.WriteLine(lambdaExpr.Body);   // (x + 1)
            Console.WriteLine(lambdaExpr.ReturnType.ToString());  // System.Int32

            foreach (var parameter in lambdaExpr.Parameters) {
                Console.WriteLine("Name:{0}, Type:{1}, ", parameter.Name, parameter.Type.ToString());
            }
            //定义Assembly
            AssemblyBuilder builder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Test"),
                AssemblyBuilderAccess.RunAndSave);
            //定义Modlue
            ModuleBuilder moduleBuilder = builder.DefineDynamicModule("Test", "Test.exe");
            //创建Class:TestClass
            TypeBuilder typeBuilder = moduleBuilder.DefineType("TestClass", TypeAttributes.Public);
            //为TestClass创建静态方法 Begin
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Begin",
                MethodAttributes.Public | MethodAttributes.Static, typeof(int),
                new[] { typeof(int) });
            lambdaExpr.CompileToMethod(methodBuilder);
            Type type = typeBuilder.CreateType();
            builder.SetEntryPoint(type.GetMethod("Begin"));
            builder.Save("Test.exe");
        }

    }
}
