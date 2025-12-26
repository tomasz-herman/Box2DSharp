namespace Box2D.Base;

/// <summary>
/// Prototype for the user assert callback. Return 0 to skip the debugger break.
/// </summary>
public unsafe struct AssertFcn(delegate*<byte*, byte*, int, int> ptr)
{
    private readonly delegate*<byte*, byte*, int, int> _ptr = ptr;

    public static implicit operator AssertFcn(delegate*<byte*, byte*, int, int> ptr) => new AssertFcn(ptr);

    public static implicit operator delegate*<byte*, byte*, int, int>(AssertFcn fcn) => fcn._ptr;
    
    public int Invoke(byte* condition, byte* fileName, int lineNumber) => _ptr(condition, fileName, lineNumber);
}