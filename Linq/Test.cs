using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Linq {
    public class Test {

        static IEnumerable<MyModel> enumarable = null;
        static IQueryable<MyModel> queryable = null;

        public static void Test001() {
            // see ref Test003() 
            var result = from t in enumarable
                         select t.MyProperty;

        }

        public static void Test003() {
            var result = enumarable.Select(t => t.MyProperty);
        }



        public static void Test002() {
            // see ref Test004
            // see ref Test005
            var result2 = from t in queryable
                          select t.MyProperty;
        }

        public static void Test004() {
            var result = queryable.Select(t => t.MyProperty);
        }

        public static void Test005() {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(MyModel), "t");
            var indexExpression = Expression.Property(parameterExpression, "MyProperty", parameterExpression);
            var lambda = Expression.Lambda<Func<MyModel, string>>(indexExpression);
            var result = queryable.Select(lambda);
        }


    }


    public class MyModel {

        public string MyProperty {
            get; set;
        }
    }
}