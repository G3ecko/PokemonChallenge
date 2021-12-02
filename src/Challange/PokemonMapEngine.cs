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
    private readonly Dictionary<CardinalPosition, int> _positionValueMap;

    /// <summary>
    /// Positions that Ash already caputre pokemons.
    /// </summary>
    private readonly HashSet<MapPoint> _capturedPositions;

    /// <summary>
    /// PokemonMapEngine constructor.
    /// </summary>
    public PokemonMapEngine()
    {
        _capturedPositions = new HashSet<MapPoint>();
        _positionValueMap = new Dictionary<CardinalPosition, int>()
        {
            { CardinalPosition.N,  1 }, //North value
            { CardinalPosition.S, -1 }, //South value
            { CardinalPosition.E,  1 }, //East value
            { CardinalPosition.O, -1 }, //West value
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
            bool directionExists = Enum.TryParse(direction.ToString(), out CardinalPosition cardinalPosition);
            if (!directionExists)
            {
                throw new InvalidOperationException($"{direction} is not valid");
            }

            var directionAxis = GetDirectionAxis(cardinalPosition);

            currentPositionPoint = new MapPoint(directionAxis == Axis.X ? currentPositionPoint.X + (_positionValueMap[cardinalPosition]) : currentPositionPoint.X,
                                        directionAxis == Axis.Y ? currentPositionPoint.Y + (_positionValueMap[cardinalPosition]) : currentPositionPoint.Y);


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

    /// <summary>
    /// Get direction axis.
    /// </summary>
    /// <param name="direction">direction</param>
    /// <returns>Axis</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private Axis GetDirectionAxis(CardinalPosition direction) => direction switch
    {
        CardinalPosition.N => Axis.Y,
        CardinalPosition.S => Axis.Y,
        CardinalPosition.O => Axis.X,
        CardinalPosition.E => Axis.X,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
    };

}
