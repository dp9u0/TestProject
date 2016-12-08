using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace ExpressionDemo {
    public static class Test {
        public static void Run() {
            Console.WriteLine("------------------------------");
            Test.Test001();
            Console.WriteLine("------------------------------");
            Test.Test002();
            Console.WriteLine("------------------------------");
            Test.Test003();
            Console.WriteLine("------------------------------");
            Test.Test004();
            Console.WriteLine("------------------------------");
            Test.Test005();
            Console.WriteLine("------------------------------");
            Test.Test006();
            Console.WriteLine("------------------------------");
            Test.Test007();
            Console.WriteLine("------------------------------");
            Test.Test008();
            Console.WriteLine("==============================");
        }

        public static void Test001() {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
            Expression<Func<int, int>> expr = Expression.Lambda<Func<int, int>>(Expression.Add(parameterExpression, Expression.Constant(1, typeof(int))), new ParameterExpression[]
            {
                parameterExpression
            });
            Func<int, int> func = expr.Compile();
            Console.WriteLine(expr.ToString());
            Console.WriteLine(func(123123));
            expr.SaveToAssembly("Test001", typeof(int), new Type[]
            {
                typeof(int)
            });
        }

        public static void Test002() {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
            Expression<Func<int, int>> expr = Expression.Lambda<Func<int, int>>(Expression.Add(parameterExpression, Expression.Constant(1, typeof(int))), new ParameterExpression[]
            {
                parameterExpression
            });
            Console.WriteLine(expr.ToString());
            Expression<Func<int, int>> lambdaExpr = expr;
            Console.WriteLine(lambdaExpr.Body);
            Console.WriteLine(lambdaExpr.ReturnType.ToString());
            foreach (ParameterExpression parameter in lambdaExpr.Parameters) {
                Console.WriteLine("Name:{0}, Type:{1}, ", parameter.Name, parameter.Type.ToString());
            }
            lambdaExpr.SaveToAssembly("Test002", typeof(int), new Type[]
            {
                typeof(int)
            });
        }

        public static void Test003() {
            LoopExpression loop = Expression.Loop(Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[]
            {
                typeof(string)
            }), new Expression[]
            {
                Expression.Constant("Hello")
            }));
            BlockExpression block = Expression.Block(new Expression[]
            {
                loop
            });
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block, Array.Empty<ParameterExpression>());
            lambdaExpression.SaveToAssembly("Test003", null, null);
        }

        public static void Test004() {
            ConstantExpression left = Expression.Constant(1);
            ConstantExpression right = Expression.Constant(2);
            BinaryExpression addExpression = Expression.Add(left, right);
            LambdaExpression lambdaE = Expression.Lambda(addExpression, Array.Empty<ParameterExpression>());
            lambdaE.SaveToAssembly("Test004_0", typeof(int), null);
            Expression<Func<int>> lambdaExpression = Expression.Lambda<Func<int>>(addExpression, Array.Empty<ParameterExpression>());
            lambdaExpression.SaveToAssembly("Test004_1", typeof(int), null);
        }

        public static void Test005() {
            LabelTarget labelBreak = Expression.Label("label");
            ParameterExpression loopIndex = Expression.Parameter(typeof(int), "index");
            BlockExpression block = Expression.Block(new ParameterExpression[]
            {
                loopIndex
            }, new Expression[]
            {
                Expression.Assign(loopIndex, Expression.Constant(1)),
                Expression.Loop(Expression.IfThenElse(Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)), Expression.Block(Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[]
                {
                    typeof(string)
                }), new Expression[]
                {
                    Expression.Constant("Hello")
                }), Expression.PostIncrementAssign(loopIndex)), Expression.Break(labelBreak)), labelBreak)
            });
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block, Array.Empty<ParameterExpression>());
            lambdaExpression.SaveToAssembly("Test005", null, null);
        }

        private static void Test006() {
            ParameterExpression inputParamExp = Expression.Parameter(typeof(object), "input");
            TypeBinaryExpression typeBinaryExpression = Expression.TypeIs(inputParamExp, typeof(int));
            var lambdaExr = Expression.Lambda<Func<object, bool>>(typeBinaryExpression, inputParamExp);
            lambdaExr.SaveToAssembly("Test006", typeof(bool), new[] { typeof(object) });
        }




        private static void Test007() {
            LabelTarget returnTarget = Expression.Label(typeof(int));
            LabelExpression returnLabel = Expression.Label(returnTarget, Expression.Constant(998, typeof(int)));
            ParameterExpression inParam1 = Expression.Parameter(typeof(int));
            ParameterExpression inParam2 = Expression.Parameter(typeof(int));
            ParameterExpression inParam3 = Expression.Parameter(typeof(int));
            BlockExpression block3 = Expression.Block(
                new[] { inParam1, inParam2 },
                Expression.AddAssign(inParam2, Expression.Constant(67677)),
                Expression.IfThen(
                    Expression.GreaterThan(inParam3, Expression.Constant(999)),
                    Expression.Block(
                        Expression.AddAssign(inParam3, Expression.Constant(10)),
                        Expression.Return(returnTarget, inParam3))),

                 Expression.IfThen(
                    Expression.Equal(inParam3, Expression.Constant(962)),
                    Expression.Block(
                        Expression.AddAssign(inParam1, Expression.Constant(112340)),
                        Expression.Return(returnTarget, inParam1))),

                returnLabel);
            /*             
        int num2;
		num2 += 67677;
		if (num > 999)
		{
			num += 10;
			return num;
		}
		if (num == 962)
		{
			int num3;
			num3 += 112340;
			return num3;
		}
		return 998;
        */
            var lambdaExpression = Expression.Lambda<Func<int, int>>(block3, new[] { inParam3 });
            lambdaExpression.SaveToAssembly("Test007", typeof(int), new[] { typeof(int) });
        }


        private static void Test008() {

        }

        private static void SaveToAssembly(this LambdaExpression lambdaExpr, string assemblyName, Type returnType, Type[] paramTypes) {
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName, assemblyName + ".dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(assemblyName + "Class", TypeAttributes.Public);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(assemblyName + "Method", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, returnType, paramTypes);
            lambdaExpr.CompileToMethod(methodBuilder);
            Type type = typeBuilder.CreateType();
            assemblyBuilder.Save(assemblyName + ".dll");
        }
    }
}
