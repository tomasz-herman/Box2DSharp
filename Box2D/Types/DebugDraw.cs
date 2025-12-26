using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Types;

/// <summary>
/// This struct holds callbacks you can implement to draw the Box2D world.
/// </summary>
public unsafe struct DebugDraw
{
    public delegate*<Vector2*, int, HexColor, void*, void> DrawPolygonFcn;
    public delegate*<Transform, Vector2*, int, float, HexColor, void*, void> DrawSolidPolygonFcn;
    public delegate*<Vector2, float, HexColor, void*, void> DrawCircleFcn;
    public delegate*<Transform, Vector2, float, HexColor, void*, void> DrawSolidCircleFcn;
    public delegate*<Vector2, Vector2, float, HexColor, void*, void> DrawSolidCapsuleFcn;
    public delegate*<Vector2, Vector2, HexColor, void*, void> DrawSegmentFcn;
    public delegate*<Transform, void*, void> DrawTransformFcn;
    public delegate*<Vector2, float, HexColor, void*, void> DrawPointFcn;
    public delegate*<Vector2, byte*, HexColor, void*, void> DrawStringFcn;
    
    public Aabb DrawingBounds;
    [MarshalAs(UnmanagedType.U1)]
    public bool UseDrawingBounds;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawShapes;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawJoints;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawJointExtras;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawBounds;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawMass;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawBodyNames;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContacts;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawGraphColors;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContactNormals;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContactImpulses;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawContactFeatures;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawFrictionImpulses;
    [MarshalAs(UnmanagedType.U1)]
    public bool DrawIslands;
    public void* Context;
    
    [DllImport("box2d", EntryPoint = "b2DefaultDebugDraw")]
    public static extern DebugDraw Default();
}