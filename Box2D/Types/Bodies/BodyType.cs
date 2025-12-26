namespace Box2D.Types.Bodies;

/// <summary>
/// The body simulation type.
/// Each body is one of these three types. The type determines how the body behaves in the simulation.
/// </summary>
public enum BodyType
{
    StaticBody, KinematicBody, DynamicBody, BodyTypeCount
}