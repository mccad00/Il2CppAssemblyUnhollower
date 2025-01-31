﻿using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.Image
{
    [ApplicableToUnityVersionsSince("5.3.2")]
    public unsafe class NativeImageStructHandler_19_0 : INativeImageStructHandler
    {
        public unsafe int Size() => sizeof(Il2CppImage_19_0);
        public INativeImageStruct CreateNewImageStruct()
        {
            var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppImage_19_0>());

            *(Il2CppImage_19_0*)pointer = default;

            return new NativeImageStruct(pointer);
        }

        public INativeImageStruct Wrap(Il2CppImage* imagePointer)
        {
            if ((IntPtr)imagePointer == IntPtr.Zero) return null;
            else return new NativeImageStruct((IntPtr)imagePointer);
        }

#if DEBUG
        public string GetName() => "NativeImageStructHandler_19_0";
#endif

        [StructLayout(LayoutKind.Sequential)]
        internal struct Il2CppImage_19_0
        {
            public IntPtr name;      // const char*
            public /*AssemblyIndex*/ int assemblyIndex;

            public /*TypeDefinitionIndex*/ int typeStart;
            public uint typeCount;
            
            public /*MethodIndex*/ int entryPointIndex;

            public /*Il2CppNameToTypeDefinitionIndexHashTable **/ IntPtr nameToClassHashTable;

            public uint token;
        }

        internal class NativeImageStruct : INativeImageStruct
        {
            private static byte dynamicDummy;

            public NativeImageStruct(IntPtr pointer)
            {
                Pointer = pointer;
            }

            public IntPtr Pointer { get; }

            public Il2CppImage* ImagePointer => (Il2CppImage*)Pointer;

            private Il2CppImage_19_0* NativeImage => (Il2CppImage_19_0*)Pointer;

            public ref Il2CppAssembly* Assembly => throw new NotSupportedException();

            public ref byte Dynamic => ref dynamicDummy;

            public ref IntPtr Name => ref NativeImage->name;

            public bool HasNameNoExt => false;

            public ref IntPtr NameNoExt => throw new NotSupportedException();
        }
    }
}