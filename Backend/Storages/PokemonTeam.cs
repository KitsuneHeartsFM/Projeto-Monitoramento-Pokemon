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
    /// Implementação de GetPokemon de IStorage que retorna
    /// o Pokmeon escolhido
    /// 
    /// Complexidade O(1) pois é uma procura de índice de array
    /// de tempo constante
    /// </summary>
    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return team[position];
    }

    /// <summary>
    /// Implementação de RemovePokemon de IStorage que retorna o
    /// Pokemon removido
    /// 
    /// Sua complexidade é O(n) pois depende de quantos Pokemons
    /// tem no time e da posição onde deseja remover um Pokemon
    /// </summary>
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
    /// Implementação de ListPokemon de IStorage para retornar o 
    /// array interno de PokemonTeam
    /// 
    /// Complexidade O(1) pois faz apenas uma operação de get()
    /// </summary>
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
    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;

        var aux = team[pos1];
        team[pos1] = team[pos2];
        team[pos2] = aux;
    }

    /// <summary>
    /// Implementação de GetQuantity de IStorage para retornar 
    /// quantos Pokemons estão no time
    /// 
    /// Complexidade O(1) pois é apenas um método get()
    /// </summary>
    public int GetQuantity()
    {
        return quantity;
    }

    /// <summary>
    /// Implementação de UpdatePokemon IStorage
    /// 
    /// Primeiro checa se a posição inserida é válida, depois pega
    /// os dados do Pokemon inserido, se ele evolui para algum Pokemon
    /// e se ele tem nível para poder evoluir
    /// 
    /// depois um novo objeto do tipo Pokemon com todas as características
    /// do Pokemon previamente escolhido menos sua espécie é criado e o substitui
    /// no índice escolhido do array
    /// 
    /// Complexidade O(1) pois mesmo com esse tanto de passo o método ainda possui
    /// tempo de execução constante
    /// </summary>
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

    /// <summary>
    /// Método privado que cria objeto do tipo Pokemon
    /// </summary>
    private Pokemon CreatePokemon(int id, int level, int friendship, PokemonSpecies species)
    {
        return new(id, level, friendship, species);
    }
}