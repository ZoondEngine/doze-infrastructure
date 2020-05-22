﻿using Doze.Process.Native.Enumerations;
using Doze.Process.Native.Handles;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Doze.Process.Native.Imports
{
    internal static class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process(SafeProcessHandle processHandle, out bool isWow64Process);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(SafeProcessHandle processHandle, IntPtr baseAddress, out byte buffer, int size, out int numberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAllocEx(SafeProcessHandle processHandle, IntPtr baseAddress, int size, AllocationType allocationType, ProtectionType protectionType);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualFreeEx(SafeProcessHandle processHandle, IntPtr baseAddress, int size, FreeType freeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtectEx(SafeProcessHandle processHandle, IntPtr baseAddress, int size, ProtectionType protectionType, out ProtectionType oldProtectionType);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int WaitForSingleObject(SafeWin32Handle handle, int milliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(SafeProcessHandle processHandle, IntPtr baseAddress, in byte buffer, int size, out int numberOfBytesWritten);
    }
}
