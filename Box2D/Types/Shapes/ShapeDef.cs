using System.Runtime.InteropServices;

namespace Box2D.Types.Shapes;

/// <summary>
/// Used to create a shape.
/// This is a temporary object used to bundle shape creation parameters. You may use
/// the same shape definition to create multiple shapes.
/// Must be initialized using b2DefaultShapeDef().
/// </summary>
public unsafe struct ShapeDef
{
    public void* UserData;
    public SurfaceMaterial Material;
    public float Density;
    public Filter Filter;
    [MarshalAs(UnmanagedType.U1)] 
    public bool IsSensor;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnableSensorEvents;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnableContactEvents;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnableHitEvents;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnablePreSolveEvents;
    [MarshalAs(UnmanagedType.U1)] 
    public bool InvokeContactCreation;
    [MarshalAs(UnmanagedType.U1)] 
    public bool UpdateBodyMass;
    private int _internalValue;
    
    [DllImport("box2d", EntryPoint = "b2DefaultShapeDef")]
    public static extern ShapeDef Default();
}