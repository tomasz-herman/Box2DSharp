namespace Box2D.Collision;

/// <summary>
/// Describes the TOI output
/// </summary>
public enum ToiState
{
    Unknown,
    Failed,
    Overlapped,
    Hit,
    Separated
}