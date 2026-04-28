/// <summary>
/// Classe com métodos estáticos para retornar
/// a tipagem de um Pokemon inserido
/// </summary>
public class GetTyping : IGenerate<Typing>
{
    /// <summary>
    /// Método privado que retorna o tipo primário do Pokemon
    /// 
    /// Complexidade O(1) pois apenas uma checagem é feita de forma
    /// praticamente instantânea, a termos leigos, é como se o
    /// computador soubesse qual é o tipo primário só de bater 
    /// o olho, basicamente um tempo constante
    /// </summary>
    /// <param name="species"> A espécie a ser inserida </param>
    /// <returns> O tipo primário do Pokemon inserido </returns>
    /// <exception cref="NonExistentPokemon">
    /// Esta exceção customizada é disparada nos casos
    /// onde a espécie Pokemon inserida seja uma que ainda
    /// não foi registrada dentro do código do programa
    /// </exception>
    private Types GetPrimary(Pokemon species)
    {
        return species switch
        {
            // Retorno do tipo primário do Treecko
            Pokemon.Treecko => Types.Grass,
            // Retorno do tipo primário do Grovyle
            Pokemon.Grovyle => Types.Grass,
            // Retorno do tipo primário do Sceptile
            Pokemon.Sceptile => Types.Grass,
            // Retorno do tipo primário do Torchic
            Pokemon.Torchic => Types.Fire,
            // Retorno do tipo primário do Combusken
            Pokemon.Combusken => Types.Fire,
            // Retorno do tipo primário do Blaziken
            Pokemon.Blaziken => Types.Fire,
            // Retorno do tipo primário do Mudkip
            Pokemon.Mudkip => Types.Water,
            // Retorno do tipo primário do Marshtomp
            Pokemon.Marshtomp => Types.Water,
            // Retorno do tipo primário do Swampert
            Pokemon.Swampert => Types.Water,
            // Retorno do tipo primário do Poochyena
            Pokemon.Poochyena => Types.Dark,
            // Retorno do tipo primário do Mightyena
            Pokemon.Mightyena => Types.Dark,
            // Retorno do tipo primário do Zigzagoon
            Pokemon.Zigzagoon => Types.Normal,
            // Retorno do tipo primário do Linoone
            Pokemon.Linoone => Types.Normal,
            // Retorno do tipo primário do Taillow
            Pokemon.Taillow => Types.Normal,
            // Retorno do tipo primário do Sweallow
            Pokemon.Sweallow => Types.Normal,
            // Retorno do tipo primário da Ralts
            Pokemon.Ralts => Types.Psychic,
            // Retorno do tipo primário da Kirlia
            Pokemon.Kirlia => Types.Psychic,
            // Retorno do tipo primário da Gardevoir
            Pokemon.Gardevoir => Types.Psychic,
            // Retorno do tipo primário do Aron
            Pokemon.Aron => Types.Steel,
            // Retorno do tipo primário do Lairon
            Pokemon.Lairon => Types.Steel,
            // Retorno do tipo primário do Aggron
            Pokemon.Aggron => Types.Steel,
            // Travinha de segurança do método
            _ => throw new NonExistentPokemon()
        };
    }

    /// <summary>
    /// Método privado irmão de GetPrimary(), dessa vez
    /// retornando o tipo secundário
    /// 
    /// Complexidade O(1) pelo mesmo motivo que seu irmão é
    /// O(1)
    /// </summary>
    /// <param name="species"> A espécie Pokemon registada </param>
    /// <returns>
    /// Um switch case é usado para definir qual o retorno ideal,
    /// se um Pokemon com tipagem dupla foi inserido então a tipagem
    /// secundária será retornada, caso o contrário apenas retornará
    /// um valor nulo
    /// 
    /// Repare que, diferente de seu irmão, este método NÃO
    /// dispara exceção. Isto acontece pois há Pokemons que
    /// foram inseridos previamente no programa mas que são
    /// monotipos, isto é, que possuem apenas 1 único tipo vide
    /// Sceptile sendo grama puro ou Gardevoir sendo psiquico puro
    /// 
    /// Por questão de conveniência, o retorno padrão é sempre o nulo
    /// </returns>
    private Types? GetSecondary(Pokemon species)
    {
        return species switch
        {
            // Retorno do tipo secundário do Combusken (Fogo/Lutador)
            Pokemon.Combusken => Types.Fighting,
            // Retorno do tipo secundário do Blaziken (Fogo/Lutador)
            Pokemon.Blaziken => Types.Fighting,
            // Retorno do tipo secundário do Marshtomp (Água/Terra)
            Pokemon.Marshtomp => Types.Ground,
            // Retorno do tipo secundário do Swampert (Água/Terra)
            Pokemon.Swampert => Types.Ground,
            // Retorno do tipo secundário do Taillow (Normal/Voador)
            Pokemon.Taillow => Types.Flying,
            // Retorno do tipo secundário do Sweallow (Normal/Voador)
            Pokemon.Sweallow => Types.Flying,
            // Retorno do tipo secundário do Aron (Aço/Rocha) 
            Pokemon.Aron => Types.Rock,
            // Retorno do tipo secundário do Lairon (Aço/Rocha)
            Pokemon.Lairon => Types.Rock,
            // Retorno do tipo secundário do Aggron (Aço/Rocha)
            Pokemon.Aggron => Types.Rock,
            // Retorno nulo para o caso do Pokemon inserido 
            // ser monotipo
            _ => null
        };
    }

    /// <summary>
    /// Método público que retorna um objeto do tipo Typing
    /// 
    /// Sua complexidade é O(1) pois utiliza de 2 métodos O(1) 
    /// para sua execução, ou seja, em teoria seria um código
    /// de complexidade O(1+1) ou O(2), mas por convenção quando
    /// toda complexidade que não possui variável, vide O(n log n)
    /// ou O(2^n), é automaticamente classificada como O(1)
    /// </summary>
    /// <param name="species"> A espécie Pokemon a ser inserida </param>
    /// <returns>
    /// Há dois casos de retorno:
    /// 
    /// 1. retorno de um objeto do tipo Typing recebendo apenas o dado
    /// do tipo primário vindo de GetPrimary()
    /// 
    /// 2. retorno de um objeto do tipo Typing recebendo os dados 
    /// de ambos os tipos vindos de GetPrimary() e GetSecondary()
    /// 
    /// Assim como o método ToString() de typing, o retorno é
    /// decidido com um if ternário verificando se o dado vindo de
    /// GetSecondary() é nulo, com o primeiro retorno vindo caso seja
    /// verdade e o segundo vindo caso o contrário
    /// </returns>
    public Typing GetData(Pokemon species)
    {
        return GetSecondary(species) == null ? new(GetPrimary(species)) : new(GetPrimary(species), GetSecondary(species));
    }
}