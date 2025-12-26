using System.Runtime.InteropServices;
namespace Box2D.Base;

/// <summary>
/// Prototype for user free function
/// </summary>
/// <param name="mem">the memory previously allocated through `b2AllocFcn`</param>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FreeFcn(delegate*<void*, void> ptr)
{
    private readonly delegate*<void*, void> _ptr = ptr;

    public static implicit operator FreeFcn(delegate*<void*, void> ptr) => new FreeFcn(ptr);

    public static implicit operator delegate*<void*, void>(FreeFcn fcn) => fcn._ptr;
    
    public void Invoke(void* mem) => _ptr(mem);
}