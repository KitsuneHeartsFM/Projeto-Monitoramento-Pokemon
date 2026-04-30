/// <summary>
/// Classe estática para a parte randômica do projeto
/// </summary>
public static class Randomizer
{
    /// <summary>
    /// Método estático que retorna um Pokemon aleatório
    /// entre os registrados no projeto
    /// </summary>
    public static PokemonSpecies Randomize()
    {
        Random random = new();

        // Um objeto do tipo Array é criado recebendo todos os valores dentro
        // do arquivo Enum PokemonSpecies
        Array pokemonGroup = Enum.GetValues<PokemonSpecies>();
        // Um objeto com o valor de PokemonSpecies obtido através do objeto
        // pokemonGroup e um randomizador com o tamanho de PokemonSpecies
        PokemonSpecies pokemon = (PokemonSpecies) pokemonGroup.GetValue(random.Next(pokemonGroup.Length))!;

        return pokemon;
    }
}