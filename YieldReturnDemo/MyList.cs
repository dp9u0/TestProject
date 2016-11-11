#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

#endregion

namespace YieldReturnDemo {

    public class MyList {

        private static Random rand = new Random(DateTime.Now.Millisecond);

        public IEnumerable<string> Get1() {
            //for (int i = 0; i < 15; i++) {
            //    yield return "Test_" + i;
            //}
            Get1d__0 Get1d__ = new Get1d__0(-2);
            Get1d__.__4__this = this;
            return Get1d__;
        }

        public IEnumerable<string> Get2() {
            //var test1 = "";
            //Console.WriteLine(test1);
            //for (int i = 0; i < 15; i++) {
            //    var test2 = rand.Next().ToString();
            //    test1 += test2;
            //    Console.WriteLine(test1);
            //    yield return "Test_" + i + "_" + test2;
            //}
            Get2d__4 Get2d__ = new Get2d__4(-2);
            Get2d__.__4__this = this;
            return Get2d__;
        }

        public IEnumerable<string> Get3() {
            //yield return "Test";
            Get3d__a Get1d__ = new Get3d__a(-2);
            Get1d__._4__this = this;
            return Get1d__;
        }

        #region Nested type: Get1d__0

        [CompilerGenerated]
        private sealed class Get1d__0 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable {

            private int __1__state;
            private string __2__current;

            public MyList __4__this;
            private int __l__initialThreadId;

            public int i5__1;

            [DebuggerHidden]
            public Get1d__0(int __1__state) {
                this.__1__state = __1__state;
                __l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            #region IEnumerable<string> Members

            [DebuggerHidden]
            IEnumerator<string> IEnumerable<string>.GetEnumerator() {
                return InternalGetEnumerator();
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() {
                return InternalGetEnumerator();
            }

            #endregion

            #region IEnumerator<string> Members

            string IEnumerator<string>.Current {
                [DebuggerHidden]
                get {
                    return __2__current;
                }
            }

            object IEnumerator.Current {
                [DebuggerHidden]
                get {
                    return __2__current;
                }
            }

            bool IEnumerator.MoveNext() {
                switch (__1__state) {
                    case 0:
                        __1__state = -1;
                        i5__1 = 0;
                        break;
                    case 1:
                        __1__state = -1;
                        i5__1++;
                        break;
                    default:
                        goto IL_7A;
                }
                bool result;
                if (i5__1 < 15) {
                    __2__current = "Test_" + i5__1;
                    __1__state = 1;
                    result = true;
                    return result;
                }
                IL_7A:
                result = false;
                return result;
            }

            [DebuggerHidden]
            void IEnumerator.Reset() {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose() {
            }

            #endregion

            private IEnumerator<string> InternalGetEnumerator() {
                Get1d__0 Get1d__;
                if (Thread.CurrentThread.ManagedThreadId == __l__initialThreadId && __1__state == -2) {
                    __1__state = 0;
                    Get1d__ = this;
                }
                else {
                    Get1d__ = new Get1d__0(0);
                    Get1d__.__4__this = __4__this;
                }
                return Get1d__;
            }

        }

        #endregion

        #region Nested type: Get2d__4

        [CompilerGenerated]
        private sealed class Get2d__4 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable {

            private int __1__state;
            private string __2__current;

            public MyList __4__this;
            private int __l__initialThreadId;

            public int i5__6;
            public string test15__5;

            public string test25__7;

            [DebuggerHidden]
            public Get2d__4(int __1__state) {
                this.__1__state = __1__state;
                __l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            #region IEnumerable<string> Members

            [DebuggerHidden]
            IEnumerator<string> IEnumerable<string>.GetEnumerator() {
                return InternalGetEnumerator();
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() {
                return InternalGetEnumerator();
            }

            #endregion

            #region IEnumerator<string> Members

            string IEnumerator<string>.Current {
                [DebuggerHidden]
                get {
                    return __2__current;
                }
            }

            object IEnumerator.Current {
                [DebuggerHidden]
                get {
                    return __2__current;
                }
            }

            bool IEnumerator.MoveNext() {
                switch (__1__state) {
                    case 0:
                        __1__state = -1;
                        test15__5 = "";
                        i5__6 = 0;
                        break;
                    case 1:
                        __1__state = -1;
                        i5__6++;
                        break;
                    default:
                        goto IL_E1;
                }
                bool result;
                if (i5__6 < 15) {
                    test25__7 = rand.Next().ToString();
                    test15__5 += test25__7;
                    __2__current = string.Concat(new object[] {
                        "Test_",
                        i5__6,
                        "_",
                        test25__7
                    });
                    __1__state = 1;
                    result = true;
                    return result;
                }
                IL_E1:
                result = false;
                return result;
            }

            [DebuggerHidden]
            void IEnumerator.Reset() {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose() {
            }

            #endregion

            private IEnumerator<string> InternalGetEnumerator() {
                Get2d__4 Get2d__;
                if (Thread.CurrentThread.ManagedThreadId == __l__initialThreadId && __1__state == -2) {
                    __1__state = 0;
                    Get2d__ = this;
                }
                else {
                    Get2d__ = new Get2d__4(0);
                    Get2d__.__4__this = __4__this;
                }
                return Get2d__;
            }

        }

        #endregion

        #region Nested type: Get3d__a

        [CompilerGenerated]
        private sealed class Get3d__a : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable {

            private int _1__state;
            private string _2__current;

            public MyList _4__this;
            private int _l__initialThreadId;

            [DebuggerHidden]
            public Get3d__a(int _1__state) {
                this._1__state = _1__state;
                _l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            #region IEnumerable<string> Members

            [DebuggerHidden]
            IEnumerator<string> IEnumerable<string>.GetEnumerator() {
                return InternalGetEnumerator();
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator() {
                return InternalGetEnumerator();
            }

            #endregion

            #region IEnumerator<string> Members

            string IEnumerator<string>.Current {
                [DebuggerHidden]
                get {
                    return _2__current;
                }
            }

            object IEnumerator.Current {
                [DebuggerHidden]
                get {
                    return _2__current;
                }
            }

            bool IEnumerator.MoveNext() {
                bool result;
                switch (_1__state) {
                    case 0:
                        _1__state = -1;
                        _2__current = "Test";
                        _1__state = 1;
                        result = true;
                        return result;
                    case 1:
                        _1__state = -1;
                        break;
                }
                result = false;
                return result;
            }

            [DebuggerHidden]
            void IEnumerator.Reset() {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose() {
            }

            #endregion

            private IEnumerator<string> InternalGetEnumerator() {
                Get3d__a Get3d__a;
                if (Thread.CurrentThread.ManagedThreadId == _l__initialThreadId && _1__state == -2) {
                    _1__state = 0;
                    Get3d__a = this;
                }
                else {
                    Get3d__a = new Get3d__a(0);
                    Get3d__a._4__this = _4__this;
                }
                return Get3d__a;
            }

        }

        #endregion
    }

}