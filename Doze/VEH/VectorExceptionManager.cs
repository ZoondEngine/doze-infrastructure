using Doze.VectoredExceptions.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Doze.VectoredExceptions
{
    [Obsolete("Obsolete and unsafe VEH custom handler. Dont use in production")]
    public static unsafe class VectorExceptionManager
    {
        public const uint ExceptionStackOverflow = 0xC00000FD;
        public const uint Err = 0xF00000FD;

        private static List<PVECTORED_EXCEPTION_HANDLER> VectoredExceptionHandlers { get; set; } = new List<PVECTORED_EXCEPTION_HANDLER>();

        [Obsolete("Obsolete and unsafe VEH custom handler. Dont use in production")]
        public static void AddCustomVectoredExceptionHandler(PVECTORED_EXCEPTION_HANDLER handler)
        {
            VectoredExceptionHandlers.Add(handler);
        }

        [Obsolete("Obsolete and unsafe VEH custom handler. Dont use in production")]
        public static void Initialize()
        {
            var baseHandler = Kernel32.AddVectoredExceptionHandler(IntPtr.Zero, BaseHandler);

            if (baseHandler == IntPtr.Zero)
                throw new Win32Exception("AddVectoredExceptionHandler failed");

            var size = 32768;
            if (!Kernel32.SetThreadStackGuarantee(&size))
                throw new InsufficientExecutionStackException("SetThreadStackGuarantee failed", new Win32Exception());

            if (Msvcrt._resetstkoflw() == 0)
                throw new InvalidOperationException("_resetstkoflw failed");
        }

        [Obsolete("Obsolete and unsafe VEH custom handler. Dont use in production")]
        private static VEH BaseHandler(ref EXCEPTION_POINTERS pointers)
        {
            if (pointers.ExceptionRecord == null)
                return VEH.EXCEPTION_CONTINUE_SEARCH;

            var record = pointers.ExceptionRecord;
            if (record->ExceptionCode != ExceptionStackOverflow)
                return VEH.EXCEPTION_CONTINUE_SEARCH;

            foreach(var handler in VectoredExceptionHandlers)
            {
                handler?.Invoke(ref pointers);
            }

            return VEH.EXCEPTION_EXECUTE_HANDLER;
        }
    }
}
