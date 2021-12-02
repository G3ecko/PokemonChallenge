using ChallengePokemon;
using Shouldly;
using System;
using Xunit;

namespace Challange.Tests
{
    public class PokemonMapEngineTests
    {
        [Theory]
        [InlineData("K")]
        [InlineData("WWWWK")]
        [InlineData("PPPPPP")]
        public void DoMovement_When_InValidInput_Throws_InvalidOperationException(string userInput)
        {
            PokemonMapEngine pokemonMapEngine = new PokemonMapEngine();

            Should.Throw<IndexOutOfRangeException>(() => pokemonMapEngine.DoMovement(userInput));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("        ")]
        public void DoMovement_When_InValidInput_Throws_ArgumentNullException(string userInput)
        {
            PokemonMapEngine pokemonMapEngine = new PokemonMapEngine();

            Should.Throw<ArgumentNullException>(() => pokemonMapEngine.DoMovement(userInput));
        }

        [Theory]
        [InlineData(2, "E")]
        [InlineData(2, "O")]
        [InlineData(2, "N")]
        [InlineData(2, "S")]
        [InlineData(3, "EE")]
        [InlineData(3, "OO")]
        [InlineData(3, "NN")]
        [InlineData(3, "SS")]
        [InlineData(4, "SSS")]
        [InlineData(4, "OOO")]
        [InlineData(4, "NNN")]
        [InlineData(4, "EEE")]
        [InlineData(5, "NNNN")]
        [InlineData(5, "OOOO")]
        [InlineData(5, "EEEE")]
        [InlineData(5, "SSSS")]
        [InlineData(4, "NESO")]
        [InlineData(2, "NSNSNSNSNS")]
        [InlineData(3, "NEOE")]
        [InlineData(3, "SNEO")]
        [InlineData(4, "NNNSSS")]
        [InlineData(4, "EEEOOO")]
        [InlineData(3, "SE")]
        [InlineData(11, "NNNNNNNNNNS")]
        [InlineData(11, "NNNNNOOOOOEEEEESSSSS")]
        public void DoMovement_When_ValidInput_Returns_CapturedPokemon(int capturesNumber,string userInput)
        {
            PokemonMapEngine pokemonMapEngine = new PokemonMapEngine();

            pokemonMapEngine.DoMovement(userInput);

            pokemonMapEngine.GetCapturedPokemons().ShouldBe(capturesNumber);
        }

        [Fact]
        public void ResetPositions_When_Reset_Returns_CapturedPokemon()
        {
            PokemonMapEngine pokemonMapEngine = new PokemonMapEngine();

            pokemonMapEngine.DoMovement("NSOE");

            pokemonMapEngine.ResetPositions();

            pokemonMapEngine.GetCapturedPokemons().ShouldBe(0);
        }
    }
}