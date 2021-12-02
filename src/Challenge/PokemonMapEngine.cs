using Challenge;

namespace ChallengePokemon;

/// <summary>
/// PokmenonMapaEngine clas that handle bidmensional movements.
/// </summary>
public class PokemonMapEngine
{
    /// <summary>
    /// Map cardinal direction with value.
    /// </summary>
    private readonly Dictionary<char, CardinalAxis> _positionValueMap;

    /// <summary>
    /// Positions that Ash already caputre pokemons.
    /// </summary>
    private readonly HashSet<MapPoint> _capturedPositions;

    /// <summary>
    /// Struct that relation cardinal unit value and axis.
    /// </summary>
    /// <param name="cardinalValue"></param>
    /// <param name="axis"></param>
    private record struct CardinalAxis(int cardinalValue, Axis axis);

    /// <summary>
    /// Struct represent a map point.
    /// </summary>
    /// <param name="x"> X Axis</param>
    /// <param name="y">Y Axis</param>
    private record struct MapPoint(int x, int y);

    /// <summary>
    /// PokemonMapEngine constructor.
    /// </summary>
    public PokemonMapEngine()
    {
        _capturedPositions = new HashSet<MapPoint>();
        _positionValueMap = new Dictionary<char, CardinalAxis>()
        {
            { 'N', new CardinalAxis(1, Axis.Y) }, //North unit value and axis.
            { 'S', new CardinalAxis(-1,Axis.Y) }, //South unit value and axis.
            { 'E', new CardinalAxis(1, Axis.X) }, //East unit value and axis.
            { 'O', new CardinalAxis(-1,Axis.X) }, //West unit value and axis.
         };
    }

    /// <summary>
    /// Execute movemnt based on input.
    /// </summary>
    /// <param name="directions">directions input.</param>
    /// <returns>Number of pokmenons captured.</returns>
    /// <exception cref="ArgumentNullException">Excpetion occurs when input is null or empty.</exception>
    /// <exception cref="InvalidOperationException">InvalidOperationException occurs when user entar an invalid input.</exception>
    public void DoMovement(string directions)
    {
        if (string.IsNullOrWhiteSpace(directions))
        {
            throw new ArgumentNullException($"{nameof(directions)} is null or empy");
        }

        // Start poisition coordinates is  0,0
        MapPoint currentPositionPoint = new MapPoint(0, 0);

        _capturedPositions.Add(currentPositionPoint);

        foreach (var direction in directions)
        {
            if (!_positionValueMap.ContainsKey(direction))
            {
                throw new IndexOutOfRangeException($"{direction} is not configured");
            }

            var directionAxis = _positionValueMap[direction];

            currentPositionPoint = new MapPoint(directionAxis.axis == Axis.X ? currentPositionPoint.x + (directionAxis.cardinalValue) : currentPositionPoint.x,
                                        directionAxis.axis == Axis.Y ? currentPositionPoint.y + (directionAxis.cardinalValue) : currentPositionPoint.y);

            if (!_capturedPositions.Contains(currentPositionPoint))
                _capturedPositions.Add(currentPositionPoint);

        }
    }

    /// <summary>
    /// Get number of captured pokemons
    /// </summary>
    public int GetCapturedPokemons() => _capturedPositions.Count();

    /// <summary>
    /// Reset all current positions.
    /// </summary>
    public void ResetPositions() => _capturedPositions.Clear();

}
