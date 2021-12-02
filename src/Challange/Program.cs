using ChallengePokemon;

PokemonMapEngine mapEngine = new PokemonMapEngine();

while (true)
{
    try
    {
        Console.WriteLine("Enter pokmen map directions");
        var userDirectionsInput = Console.ReadLine();

        mapEngine.DoMovement(userDirectionsInput);
        var capturesNumber = mapEngine.GetCapturedPokemons();

        Console.WriteLine($"Number of catched pokemons is {capturesNumber}");
       
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

