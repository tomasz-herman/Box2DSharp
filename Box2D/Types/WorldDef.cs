using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Types.Callbacks;

namespace Box2D.Types;

/// <summary>
/// World definition used to create a simulation world.
/// Must be initialized using b2DefaultWorldDef().
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct WorldDef
{
	public Vector2 Gravity;
	public float RestitutionThreshold;
	public float HitEventThreshold;
	public float ContactHertz;
	    public float ContactDampingRatio;
	    /// <summary>
	    /// This parameter controls how fast overlap is resolved and usually has units of meters per second. This only
	    /// puts a cap on the resolution speed. The resolution speed is increased by increasing the hertz and/or
	    /// decreasing the damping ratio.
	    /// </summary>
	    public float MaxContactPushSpeed;
	    public float MaximumLinearSpeed;	public FrictionCallback FrictionCallback;
	public RestitutionCallback RestitutionCallback;
	[MarshalAs(UnmanagedType.U1)] 
	public bool EnableSleep;
	[MarshalAs(UnmanagedType.U1)] 
	public bool EnableContinuous;
	public int WorkerCount;
	public EnqueueTaskCallback EnqueueTask;
	public FinishTaskCallback FinishTask;
	public void* UserTaskContext;
	public void* UserData;
	public int InternalValue;

	[LibraryImport("box2d", EntryPoint = "b2DefaultWorldDef")]
	public static partial WorldDef Default();
}