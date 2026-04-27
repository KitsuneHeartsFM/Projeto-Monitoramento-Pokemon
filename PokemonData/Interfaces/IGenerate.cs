/// <summary>
/// Interface para classes que retornam dados diferentes de Pokemons
/// ou até mesmo o Pokemon em si
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenerate<T>
{
    public T GetData(PokemonSpecies species);
}