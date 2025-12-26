namespace Box2D.Types.Callbacks;

/// <summary>
/// These are thread-safe and can be used to synchronize tasks.
/// </summary>
public readonly unsafe struct FinishTaskCallback(delegate*<void*, void*, void> ptr)
{
    private readonly delegate*<void*, void*, void> _ptr = ptr;

    public static implicit operator FinishTaskCallback(delegate*<void*, void*, void> ptr) => new FinishTaskCallback(ptr);

    public static implicit operator delegate*<void*, void*, void>(FinishTaskCallback callback) => callback._ptr;
    
    public void Invoke(void* userTask, void* userContext) => _ptr(userTask, userContext);
}