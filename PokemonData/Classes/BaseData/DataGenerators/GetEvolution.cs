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
    /// <param name="species"> A espécie Pokemon a ser inserida </param>
    /// <returns>
    /// Se tudo ocorrer dentro dos conformes, retornará um objeto
    /// do tipo Evolution com os dados envolvendo as evoluções do
    /// Pokemon inserido
    /// </returns>
    /// <exception cref="NonExistentPokemon">
    /// Esta exceção será disparada para o caso onde
    /// o Pokemon inserido não seja um válido para o
    /// método
    /// </exception>
    public Evolution GetData(Pokemon species)
    {
        return species switch
        {
            // Linha Evolutiva do Sceptile
            Pokemon.Treecko => new Evolution(16, Pokemon.Grovyle),
            Pokemon.Grovyle => new Evolution(36, Pokemon.Sceptile, 16, Pokemon.Treecko),
            Pokemon.Sceptile => new Evolution(null, null, 36, Pokemon.Grovyle),
            // Linha Evolutiva do Blaziken
            Pokemon.Torchic => new Evolution(16, Pokemon.Combusken),
            Pokemon.Combusken => new Evolution(36, Pokemon.Blaziken, 16, Pokemon.Torchic),
            Pokemon.Blaziken  => new Evolution(null, null, 36, Pokemon.Combusken),
            // Linha Evolutiva do Swampert
            Pokemon.Mudkip => new Evolution(16, Pokemon.Marshtomp),
            Pokemon.Marshtomp => new Evolution(36, Pokemon.Swampert, 16, Pokemon.Mudkip),
            Pokemon.Swampert => new Evolution(null, null, 36, Pokemon.Marshtomp),
            // Linha Evolutiva do Mightyena
            Pokemon.Poochyena => new Evolution(18, Pokemon.Mightyena),
            Pokemon.Mightyena => new Evolution(null, null, 18, Pokemon.Poochyena),
            // Linha Evolutiva do Linoone
            Pokemon.Zigzagoon => new Evolution(20, Pokemon.Linoone),
            Pokemon.Linoone => new Evolution(null, null, 20, Pokemon.Zigzagoon),
            // Linha Evolutiva do Sweallow
            Pokemon.Taillow => new Evolution(22, Pokemon.Sweallow),
            Pokemon.Sweallow => new Evolution(null, null, 22, Pokemon.Taillow),
            // Linha Evolutiva da Gardevoir
            Pokemon.Ralts => new Evolution(20, Pokemon.Kirlia),
            Pokemon.Kirlia => new Evolution(30, Pokemon.Gardevoir, 20, Pokemon.Ralts),
            Pokemon.Gardevoir => new Evolution(null, null, 30, Pokemon.Kirlia),
            // Linha Evolutiva do Aggron
            Pokemon.Aron => new Evolution(32, Pokemon.Lairon),
            Pokemon.Lairon => new Evolution(42, Pokemon.Aggron, 32, Pokemon.Aron),
            Pokemon.Aggron => new Evolution(null, null, 42, Pokemon.Lairon),
            // Trava de segurança
            _ => throw new NonExistentPokemon()
        };
    }
}