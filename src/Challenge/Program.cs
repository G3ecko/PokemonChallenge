using ChallengePokemon;

PokemonMapEngine mapEngine = new PokemonMapEngine();

while (true)
{
    try
    {
      
        var userDirectionsInput = Console.ReadLine();

        if (userDirectionsInput != null)
        {
            mapEngine.DoMovement(userDirectionsInput);
            var capturesNumber = mapEngine.GetCapturedPokemons();
            Console.WriteLine($"{capturesNumber}");
        }
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }
    finally
    {
        mapEngine.ResetPositions();
    }

    Console.WriteLine(Environment.NewLine);
}

