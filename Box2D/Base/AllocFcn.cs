using System.Runtime.InteropServices;
namespace Box2D.Base;

/// <summary>
/// Prototype for user allocation function
/// </summary>
/// <param name="size">the allocation size in bytes</param>
/// <param name="alignment">the required alignment, guaranteed to be a power of 2</param>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AllocFcn(delegate*<uint, int, void*> ptr)
{
    private readonly delegate*<uint, int, void*> _ptr = ptr;

    public static implicit operator AllocFcn(delegate*<uint, int, void*> ptr) => new AllocFcn(ptr);

    public static implicit operator delegate*<uint, int, void*>(AllocFcn fcn) => fcn._ptr;
    
    public void* Invoke(uint size, int alignment) => _ptr(size, alignment);
}