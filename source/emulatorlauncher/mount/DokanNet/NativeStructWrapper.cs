﻿using System.Runtime.InteropServices;

namespace DokanNet
{
    internal static class NativeStructWrapper
    {
        public static NativeStructWrapper<T> Wrap<T>(T obj) where T : class
        {
            return new NativeStructWrapper<T>(obj);
        }
    }
    /// <summary>
    /// This class allocates unmanaged memory for a native structure and initializes
    /// that memory by marshalling a managed object. It gurantees that the managed
    /// object stays alive and the unmanaged memory block is valid for at least the
    /// lifetime of this object and that the unmanaged memory is released when this
    /// object is disposed.
    /// 
    /// Since this class derives form SafeBuffer there are many instance methods
    /// available to read and modify the unmanaged buffer in a safe way and when
    /// marshalled to native code in for example a P/Invoke call, it gets automatically
    /// translated to the address of the unmanaged memory block. It also uses reference
    /// counting and is guaranteed to stay alive during such calls.
    /// <see cref="SafeBuffer"/>
    /// </summary>
    /// <typeparam name="T">Type of managed object</typeparam>
    internal class NativeStructWrapper<T> : SafeBuffer where T : class
    {
        /// <summary>
        /// Initializes a new instance by allocating unmanaged memory and marshalling
        /// the supplied managed object to that memory.
        /// </summary>
        /// <param name="obj">Managed object to marshal to unmanaged memory</param>
        public NativeStructWrapper(T obj) : base(ownsHandle: true)
        {
            var size = Marshal.SizeOf(obj);
            SetHandle(Marshal.AllocHGlobal(size));
            Initialize((ulong)size);
            Object = obj;
            Marshal.StructureToPtr(obj, handle, false);
        }

        /// <summary>
        /// Initializes an empty instance. Used internally by native marshaller and
        /// not intended to be used directly from user code.
        /// </summary>
        internal NativeStructWrapper() : base(ownsHandle: true) { }

        /// <summary>
        /// Managed object that was originally marshalled to unmanaged memory.
        /// </summary>
        public T Object { get; private set; }

        /// <summary>
        /// Releases unmanaged memory used by this instance.
        /// </summary>
        /// <returns>Always returns true</returns>
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }
    }
}
