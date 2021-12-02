namespace Challenge;

/// <summary>
/// Represent a cartesian map point.
/// </summary>
public struct MapPoint
{
    /// <summary>
    /// X Axis.
    /// </summary>
    public int X;

    /// <summary>
    /// Y Axis.
    /// </summary>
    public int Y;

    /// <summary>
    /// Constructor for new point definition.
    /// </summary>
    /// <param name="x"> X Axis</param>
    /// <param name="y">Y Axis</param>
    public MapPoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}

