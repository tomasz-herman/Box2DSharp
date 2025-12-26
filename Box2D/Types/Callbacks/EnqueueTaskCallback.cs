namespace Box2D.Types.Callbacks;

/// <summary>
/// These functions can be provided to Box2D to invoke a task system. These are designed to work well with enkiTS.
/// Returns a pointer to the user's task object. May be nullptr. A nullptr indicates to Box2D that the work was executed
/// serially within the callback and there is no need to call b2FinishTaskCallback.
/// The itemCount is the number of Box2D work items that are to be partitioned among workers by the user's task system.
/// This is essentially a parallel-for. The minRange parameter is a suggestion of the minimum number of items to assign
/// per worker to reduce overhead. For example, suppose the task is small and that itemCount is 16. A minRange of 8 suggests
/// that your task system should split the work items among just two workers, even if you have more available.
/// In general the range [startIndex, endIndex) send to b2TaskCallback should obey:
/// endIndex - startIndex >= minRange
/// The exception of course is when itemCount < minRange.
/// </summary>
public readonly unsafe struct EnqueueTaskCallback(delegate*<TaskCallback, int, int, void*, void*, void*> ptr)
{
    private readonly delegate*<TaskCallback, int, int, void*, void*, void*> _ptr = ptr;

    public static implicit operator EnqueueTaskCallback(delegate*<TaskCallback, int, int, void*, void*, void*> ptr) => new EnqueueTaskCallback(ptr);

    public static implicit operator delegate*<TaskCallback, int, int, void*, void*, void*>(EnqueueTaskCallback callback) => callback._ptr;
    
    public void* Invoke(TaskCallback task, int itemCount, int minRange, void* taskContext, void* userContext) => _ptr(task, itemCount, minRange, taskContext, userContext);
}