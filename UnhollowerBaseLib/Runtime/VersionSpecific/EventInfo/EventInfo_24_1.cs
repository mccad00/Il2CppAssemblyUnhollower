﻿using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.EventInfo
{
    [ApplicableToUnityVersionsSince("2018.3.0")]
    public unsafe class NativeEventInfoStructHandler_24_1 : INativeEventInfoStructHandler
    {
        public unsafe int Size() => sizeof(Il2CppEventInfo_24_1);
        public INativeEventInfoStruct CreateNewEventInfoStruct()
        {
            var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppEventInfo_24_1>());

            *(Il2CppEventInfo_24_1*)pointer = default;

            return new NativeEventInfoStruct(pointer);
        }

        public INativeEventInfoStruct Wrap(Il2CppEventInfo* eventInfoPointer)
        {
            if ((IntPtr)eventInfoPointer == IntPtr.Zero) return null;
            else return new NativeEventInfoStruct((IntPtr)eventInfoPointer);
        }

#if DEBUG
        public string GetName() => "NativeEventInfoStructHandler_24_1";
#endif

        [StructLayout(LayoutKind.Sequential)]
        internal struct Il2CppEventInfo_24_1
        {
            public IntPtr name; // const char*
            public Il2CppTypeStruct* eventType; // const
            public Il2CppClass* parent; // non const
            public Il2CppMethodInfo* add; // const
            public Il2CppMethodInfo* remove; // const
            public Il2CppMethodInfo* raise; // const
            public uint token;
        }

        internal class NativeEventInfoStruct : INativeEventInfoStruct
        {
            public NativeEventInfoStruct(IntPtr pointer)
            {
                Pointer = pointer;
            }

            public IntPtr Pointer { get; }

            public Il2CppEventInfo* EventInfoPointer => (Il2CppEventInfo*)Pointer;

            private Il2CppEventInfo_24_1* NativeEvent => (Il2CppEventInfo_24_1*)Pointer;

            public ref IntPtr Name => ref NativeEvent->name;

            public ref Il2CppTypeStruct* EventType => ref NativeEvent->eventType;

            public ref Il2CppClass* Parent => ref NativeEvent->parent;

            public ref Il2CppMethodInfo* Add => ref NativeEvent->add;

            public ref Il2CppMethodInfo* Remove => ref NativeEvent->remove;

            public ref Il2CppMethodInfo* Raise => ref NativeEvent->raise;
        }
    }
}
