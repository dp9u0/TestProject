// FileName:  Program.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180508 14:08
// Description:   

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

#endregion

namespace Dynamic {

    internal class Program {

        private static void Main(string[] args) {
            Console.WriteLine("==========Test1=========================");
            Test1();

            Console.WriteLine("==========Test2=========================");
            Test2();

            Console.WriteLine("===========Test3========================");
            Test3();
        }

        private static void Test2() {
            dynamic dynEo = new ExpandoObject();
            dynEo.number = 10;
            dynEo.Increment = new Action(() => { dynEo.number++; });

            Console.WriteLine(dynEo.number);
            dynEo.Increment();
            Console.WriteLine(dynEo.number);

            ((INotifyPropertyChanged) dynEo).PropertyChanged += Program_PropertyChanged;

            dynEo.name = "changed";
            dynEo.name = "another";

            Console.ReadLine();
        }

        private static void Test3() {
            dynamic dynProduct = new DynamicProduct();

            dynProduct.name = "n1"; //调用TrySetMember方法
            dynProduct.Id = 1;
            dynProduct.Id = dynProduct.Id + 3;
            dynProduct.ShowProduct();
            Console.ReadLine();
        }

        private static void Program_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            Console.WriteLine("属性{0} 已更改", e.PropertyName);
        }

        private static void Test1() {
            //dynamic对象
            dynamic dynProduct = new Product();

            //设置name字段
            dynProduct.name = "n1";

            //设置Id属性
            dynProduct.Id = 1;
            dynProduct.Id = dynProduct.Id + 3;

            //调用ShowProduct方法
            dynProduct.ShowProduct();

            Console.ReadLine();
        }

    }

    internal class Product {

        public string name;

        public int Id { get; set; }

        public void ShowProduct() {
            Console.WriteLine("Id={0} ,Name={1}", Id, name);
        }

    }

    internal class DynamicProduct : DynamicObject {

        public string name;

        public int Id { get; set; }

        public void ShowProduct() {
            Console.WriteLine("Id={0} ,Name={1}", Id, name);
        }

        #region Override DynamicObject 的方法

        public override IEnumerable<string> GetDynamicMemberNames() {
            return base.GetDynamicMemberNames();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            Console.WriteLine("TryGetMember被调用了,Name:{0}", binder.Name);
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {
            Console.WriteLine("TrySetMember被调用了,Name:{0}", binder.Name);
            return base.TrySetMember(binder, value);
        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result) {
            Console.WriteLine("TryInvoke被调用了");
            return base.TryInvoke(binder, args, out result);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
            Console.WriteLine("TryInvokeMember被调用了,Name:{0}", binder.Name);
            return base.TryInvokeMember(binder, args, out result);
        }

        #endregion

    }

}