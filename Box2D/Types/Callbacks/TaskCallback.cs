namespace Box2D.Types.Callbacks;

/// <summary>
/// Task interface
/// </summary>
/// <code>
/// void Task(int startIndex, int endIndex, uint threadIndex, void* context);
/// </code>
public readonly unsafe struct TaskCallback(delegate*<int, int, uint, void*, void> ptr)
{
    private readonly delegate*<int, int, uint, void*, void> _ptr = ptr;

    public static implicit operator TaskCallback(delegate*<int, int, uint, void*, void> ptr) => new TaskCallback(ptr);

    public static implicit operator delegate*<int, int, uint, void*, void>(TaskCallback callback) => callback._ptr;
    
    public void Invoke(int startIndex, int endIndex, uint workerIndex, void* taskContext) => _ptr(startIndex, endIndex, workerIndex, taskContext);
}