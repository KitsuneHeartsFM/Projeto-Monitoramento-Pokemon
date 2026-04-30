/// <summary>
/// Classe própria de exceção que é disparada em métodos
/// envolvendo Pokemons no time ou no Pc
/// </summary>
public class PokemonStorageException : Exception
{
    public PokemonStorageException() : base("Invalid Pokemon management operation!")
    {
    }
}