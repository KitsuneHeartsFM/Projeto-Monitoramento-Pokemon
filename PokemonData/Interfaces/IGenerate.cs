/// <summary>
/// Interface para classes que retornam dados diferentes de Pokemons
/// ou até mesmo o Pokemon em si
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenerate<T>
{
    /// <summary>
    /// Método da interface a ser implementado pelas classes
    /// da familia Get
    /// </summary>
    /// <param name="species"> A espécie Pokemon a ser inserida </param>
    /// <returns> Um objeto que sobreescreve o generic T </returns>
    public T GetData(PokemonSpecies species);
}