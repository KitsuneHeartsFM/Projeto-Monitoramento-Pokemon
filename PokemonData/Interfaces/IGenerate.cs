/// <summary>
/// Interface para classes que retornam dados diferentes de Pokemons
/// ou até mesmo o Pokemon em si
/// </summary>
public interface IGenerate<T>
{
    /// <summary>
    /// Método da interface a ser implementado pelas classes
    /// da familia Get
    /// </summary>
    public T GetData(PokemonSpecies species);
}