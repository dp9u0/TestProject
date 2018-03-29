// FileName:  NativeMethods.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180206 17:37
// Description:   

#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Unmanaged {

    /// <summary>
    /// NativeMethod Wrapper
    /// </summary>
    public static unsafe class NativeMethod {

        /// <summary>
        ///     .NET wrapper to native call of 'memcpy'. Requires Microsoft Visual C++ Runtime installed
        /// </summary>
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl
            , SetLastError = false)]
        public static extern IntPtr Memcpy(IntPtr dest, IntPtr src, ulong count);

        /// <summary>
        ///     .NET wrapper to native call of 'memcpy'. Requires Microsoft Visual C++ Runtime installed
        /// </summary>
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl
            , SetLastError = false)]
        public static extern IntPtr Memcpy(void* dest, void* src, ulong count);

        /// <summary>
        ///     .NET wrapper to native call of 'memset'. Requires Microsoft Visual C++ Runtime installed
        /// </summary>
        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl
            , SetLastError = false)]
        public static extern IntPtr Memset(IntPtr dest, int value, ulong count);

        /// <summary>
        ///     .NET wrapper to native call of 'memset'. Requires Microsoft Visual C++ Runtime installed
        /// </summary>
        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl
            , SetLastError = false)]
        public static extern IntPtr Memset(void* dest, int value, ulong count);

        /// <summary>
        ///     Set Window Visible Or Invisible
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        ///     Find Window By Title
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    }

}