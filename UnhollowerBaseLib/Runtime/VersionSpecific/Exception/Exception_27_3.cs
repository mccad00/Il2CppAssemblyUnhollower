﻿using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.Exception
{
    [ApplicableToUnityVersionsSince("2021.2.0")]
    public unsafe class NativeExceptionStructHandler_27_3 : INativeExceptionStructHandler
    {
        public unsafe int Size() => sizeof(Il2CppException_27_3);
        public INativeExceptionStruct CreateNewExceptionStruct()
        {
            var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppException_27_3>());

            *(Il2CppException_27_3*)pointer = default;

            return new NativeExceptionStruct(pointer);
        }

        public INativeExceptionStruct Wrap(Il2CppException* exceptionPointer)
        {
            if ((IntPtr)exceptionPointer == IntPtr.Zero) return null;
            else return new NativeExceptionStruct((IntPtr)exceptionPointer);
        }

#if DEBUG
        public string GetName() => "NativeExceptionStructHandler_27_3";
#endif

        [StructLayout(LayoutKind.Sequential)]
        internal struct Il2CppException_27_3
        {
            Il2CppObject @object;
            public IntPtr /* Il2CppString* */ className;
            public IntPtr /* Il2CppString* */ message;
            public IntPtr /* Il2CppObject* */ _data;
            public Il2CppException* inner_ex;
            public IntPtr /* Il2CppString* */ _helpURL;
            public IntPtr /* Il2CppArray* */ trace_ips;
            public IntPtr /* Il2CppString* */ stack_trace;
            public IntPtr /* Il2CppString* */ remote_stack_trace;
            public int remote_stack_index;
            public IntPtr /* Il2CppObject* */ _dynamicMethods;
            public int hresult;
            public IntPtr /* Il2CppString* */ source;
            public IntPtr /* Il2CppObject* */ safeSerializationManager;
            public IntPtr /* Il2CppArray* */ captured_traces;
            public IntPtr /* Il2CppArray* */ native_trace_ips;
            public int caught_in_unmanaged;
        }

        internal class NativeExceptionStruct : INativeExceptionStruct
        {
            public NativeExceptionStruct(IntPtr pointer)
            {
                Pointer = pointer;
            }

            public IntPtr Pointer { get; }

            public Il2CppException* ExceptionPointer => (Il2CppException*)Pointer;

            private Il2CppException_27_3* NativeException => (Il2CppException_27_3*)Pointer;

            public ref Il2CppException* InnerException => ref NativeException->inner_ex;

            public INativeExceptionStruct InnerExceptionWrapped
            {
                get
                {
                    IntPtr ptr = (IntPtr)NativeException->inner_ex;
                    if (ptr == IntPtr.Zero) return null;
                    else return new NativeExceptionStruct(ptr);
                }
            }

            public ref IntPtr Message => ref NativeException->message;

            public ref IntPtr HelpLink => ref NativeException->_helpURL;

            public ref IntPtr ClassName => ref NativeException->className;

            public ref IntPtr StackTrace => ref NativeException->stack_trace;

            public ref IntPtr RemoteStackTrace => ref NativeException->remote_stack_trace;
        }
    }
}