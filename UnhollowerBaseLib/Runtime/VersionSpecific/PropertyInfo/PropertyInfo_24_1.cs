﻿using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.PropertyInfo
{
    [ApplicableToUnityVersionsSince("2018.3.0")]
    public unsafe class NativePropertyInfoStructHandler_24_1 : INativePropertyInfoStructHandler
    {
        public unsafe int Size() => sizeof(Il2CppPropertyInfo_24_1);
        public INativePropertyInfoStruct CreateNewPropertyInfoStruct()
        {
            var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppPropertyInfo_24_1>());

            *(Il2CppPropertyInfo_24_1*)pointer = default;

            return new NativePropertyInfoStruct(pointer);
        }

        public INativePropertyInfoStruct Wrap(Il2CppPropertyInfo* propertyInfoPointer)
        {
            if ((IntPtr)propertyInfoPointer == IntPtr.Zero) return null;
            else return new NativePropertyInfoStruct((IntPtr)propertyInfoPointer);
        }

        public IntPtr il2cpp_property_get_name(IntPtr prop) => ((Il2CppPropertyInfo_24_1*)prop)->name;
        public IntPtr il2cpp_property_get_parent(IntPtr prop) => (IntPtr)((Il2CppPropertyInfo_24_1*)prop)->parent;
        public IntPtr il2cpp_property_get_get_method(IntPtr prop) => (IntPtr)((Il2CppPropertyInfo_24_1*)prop)->get;
        public IntPtr il2cpp_property_get_set_method(IntPtr prop) => (IntPtr)((Il2CppPropertyInfo_24_1*)prop)->set;

#if DEBUG
        public string GetName() => "NativePropertyInfoStructHandler_24_1";
#endif

        [StructLayout(LayoutKind.Sequential)]
        internal struct Il2CppPropertyInfo_24_1
        {
            public Il2CppClass* parent;
            public IntPtr name; // const char*
            public Il2CppMethodInfo* get; // const
            public Il2CppMethodInfo* set; // const
            public uint attrs;
            public uint token;
        }

        internal class NativePropertyInfoStruct : INativePropertyInfoStruct
        {
            public NativePropertyInfoStruct(IntPtr pointer)
            {
                Pointer = pointer;
            }

            public IntPtr Pointer { get; }

            public Il2CppPropertyInfo* PropertyInfoPointer => (Il2CppPropertyInfo*)Pointer;

            private Il2CppPropertyInfo_24_1* NativeProperty => (Il2CppPropertyInfo_24_1*)Pointer;

            public ref IntPtr Name => ref NativeProperty->name;

            public ref Il2CppClass* Parent => ref NativeProperty->parent;

            public ref Il2CppMethodInfo* Get => ref NativeProperty->get;

            public ref Il2CppMethodInfo* Set => ref NativeProperty->set;

            public ref uint Attrs => ref NativeProperty->attrs;
        }
    }
}
