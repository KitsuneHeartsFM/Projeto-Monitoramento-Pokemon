/// <summary>
/// Classe irmã de GetBaseStats e GetTyping, desta vez
/// ela retorna dados envovlendo evoluções de Pokemon
/// </summary>
public class GetEvolution : IGenerate<Evolution>
{
    /// <summary>
    /// Método que retorna dados envolvendo as linhas evolutivas
    /// dos Pokemons inseridos
    /// </summary>
    public Evolution GetData(PokemonSpecies species)
    {
        return species switch
        {
            // Linha Evolutiva do Sceptile
            PokemonSpecies.Treecko => new Evolution(16, PokemonSpecies.Grovyle),
            PokemonSpecies.Grovyle => new Evolution(36, PokemonSpecies.Sceptile, 16, PokemonSpecies.Treecko),
            PokemonSpecies.Sceptile => new Evolution(null, null, 36, PokemonSpecies.Grovyle),
            // Linha Evolutiva do Blaziken
            PokemonSpecies.Torchic => new Evolution(16, PokemonSpecies.Combusken),
            PokemonSpecies.Combusken => new Evolution(36, PokemonSpecies.Blaziken, 16, PokemonSpecies.Torchic),
            PokemonSpecies.Blaziken  => new Evolution(null, null, 36, PokemonSpecies.Combusken),
            // Linha Evolutiva do Swampert
            PokemonSpecies.Mudkip => new Evolution(16, PokemonSpecies.Marshtomp),
            PokemonSpecies.Marshtomp => new Evolution(36, PokemonSpecies.Swampert, 16, PokemonSpecies.Mudkip),
            PokemonSpecies.Swampert => new Evolution(null, null, 36, PokemonSpecies.Marshtomp),
            // Linha Evolutiva do Mightyena
            PokemonSpecies.Poochyena => new Evolution(18, PokemonSpecies.Mightyena),
            PokemonSpecies.Mightyena => new Evolution(null, null, 18, PokemonSpecies.Poochyena),
            // Linha Evolutiva do Linoone
            PokemonSpecies.Zigzagoon => new Evolution(20, PokemonSpecies.Linoone),
            PokemonSpecies.Linoone => new Evolution(null, null, 20, PokemonSpecies.Zigzagoon),
            // Linha Evolutiva do Sweallow
            PokemonSpecies.Taillow => new Evolution(22, PokemonSpecies.Sweallow),
            PokemonSpecies.Sweallow => new Evolution(null, null, 22, PokemonSpecies.Taillow),
            // Linha Evolutiva da Gardevoir
            PokemonSpecies.Ralts => new Evolution(20, PokemonSpecies.Kirlia),
            PokemonSpecies.Kirlia => new Evolution(30, PokemonSpecies.Gardevoir, 20, PokemonSpecies.Ralts),
            PokemonSpecies.Gardevoir => new Evolution(null, null, 30, PokemonSpecies.Kirlia),
            // Linha Evolutiva do Aggron
            PokemonSpecies.Aron => new Evolution(32, PokemonSpecies.Lairon),
            PokemonSpecies.Lairon => new Evolution(42, PokemonSpecies.Aggron, 32, PokemonSpecies.Aron),
            PokemonSpecies.Aggron => new Evolution(null, null, 42, PokemonSpecies.Lairon),
            // Trava de segurança
            _ => throw new NonExistentPokemon()
        };
    }
}