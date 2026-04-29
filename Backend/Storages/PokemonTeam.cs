/// <summary>
/// Classe que implementa a interface IStorage
/// para fazer operações envolvendo armazenamento
/// de Pokemon no time
/// </summary>
public class PokemonTeam : IStorage
{
    /// <summary>
    /// Array interno de tamanho 6 que guarda os Pokemons
    /// no time
    /// </summary>
    private Pokemon[] team;
    /// <summary>
    /// Int que guarda a quantidade de Pokemons no time
    /// </summary>
    private int quantity;

    /// <summary>
    /// Construtor da Classe
    /// </summary>
    public PokemonTeam()
    {
        // Instancia de team[], que sempre terá até 6 Pokemons
        team = new Pokemon[6];
        // instancia de quantity, que sempre começa tendo 0 Pokemons
        quantity = 0;
    }

    /// <summary>
    /// Implementação de AddPokemon de IStorage
    /// 
    /// Antes de adicionar um Pokemon, primeiro verifica se 
    /// o time já não tem 6 Pokemons nele, isto é, se o time
    /// já não está cheio
    /// 
    /// Complexidade O(1) pois não importa o Pokemon adicionado,
    /// o tempo de execução sempre será o mesmo
    /// </summary>
    /// <param name="pokemon"> O pokemon a ser inserido </param>
    /// <returns> Verdadeiro se adicionar o Pokemon, falso se der errado</returns>
    public bool AddPokemon(Pokemon pokemon)
    {
        if (quantity >= 6)
            return false;
        
        team[quantity] = pokemon;
        quantity++;
        return true;
    }

    /// <summary>
    /// Implementação de AddPokemonAtPosition de IStorage
    /// 
    /// Primeiro ele faz checagem de se há posição válida para 
    /// inserir um Pokemon no time
    /// 
    /// Sua complexidade é O(n) pois seu tempo de execução depende
    /// de quantos Pokemons estão no time e em qual posição se deseja
    /// colocar o Pokemon
    /// </summary>
    /// <param name="pokemon"> O Pokemon a ser adicionado </param>
    /// <param name="position"> A posição onde ele será adicionado </param>
    /// <returns> Verdadeiro se adicionou o Pokemon, falso se deu errado</returns>
    public bool AddPokemonAtPosition(Pokemon pokemon, int position)
    {
        if (quantity >= 6 || position < 0 || position > quantity)
            return false;
        
        for (int i = quantity; i > position; i--)
            team[i] = team[i-1];
        
        team[position] = pokemon;
        quantity++;

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    /// <exception cref="PokemonStorageException"></exception>
    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return team[position];
    }

    /// <summary>
    /// Implementação de RemovePokemon de IStorage
    /// 
    /// Sua complexidade é O(n) pois depende de quantos Pokemons
    /// tem no time e da posição onde deseja remover um Pokemon
    /// </summary>
    /// <param name="position"> A posição do Pokemon que deseja remover </param>
    /// <returns> Um objeto do Pokemon removido </returns>
    /// <exception cref="PokemonStorageException"> 
    /// Ela é disparada se o usuário tentar remover um Pokemon em um
    /// índice inválido
    /// </exception>
    public Pokemon RemovePokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        var removed = team[position];

        for (int i = position; i < quantity - 1; i++)
            team[i] = team[i + 1];

        team[quantity - 1] = null!;
        quantity--;

        return removed;
    }

    /// <summary>
    /// Implementação de ListPokemon de IStorage
    /// 
    /// Complexidade O(1) pois faz apenas uma operação de get()
    /// </summary>
    /// <returns> O array com os Pokemons no time </returns>
    public Pokemon[] ListPokemon()
    {
        return team;
    }

    /// <summary>
    /// Implementação de Move de IStorage
    /// 
    /// Complexidade O(1) pois são instruções simples que ocorrem
    /// sempre em um mesmo tempo constante, não é coisa tipo O(n*log n)
    /// pois não move o array interno, apenas sobreescreve itens em índices
    /// pré-definidos, e procura de índice costuma ser O(1)
    /// </summary>
    /// <param name="pos1"> Posição inicial </param>
    /// <param name="pos2"> Posição final </param>
    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;

        var aux = team[pos1];
        team[pos1] = team[pos2];
        team[pos2] = aux;
    }

    /// <summary>
    /// Implementação de GetQuantity de IStorage
    /// 
    /// Complexidade O(1) pois é apenas um método get()
    /// </summary>
    /// <returns> Um int com a quantidade de Pokemons no time </returns>
    public int GetQuantity()
    {
        return quantity;
    }

    public bool UpdatePokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();

        var currentPoke = team[position];
        var evolution = team[position].Evolution?.EvolvesTo;

        bool canEvolve = currentPoke.Evolution != null 
        && currentPoke.Evolution.NextEvolutionLevel != null
        && currentPoke.Level >= currentPoke.Evolution.NextEvolutionLevel;

        if (evolution != null && canEvolve)
        {
            team[position] = CreatePokemon(currentPoke.Id, currentPoke.Level, currentPoke.Friendship, (PokemonSpecies)evolution);
        }

        return true;
    }

    private Pokemon CreatePokemon(int id, int level, int friendship, PokemonSpecies species)
    {
        return new(id, level, friendship, species);
    }
}