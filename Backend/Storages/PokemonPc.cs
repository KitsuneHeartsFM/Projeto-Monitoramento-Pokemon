/// <summary>
/// Classe que implementa a interface IStorage
/// para fazer operações envolvendo armazenamento
/// de Pokemons no PC
/// </summary>
/// <param name="size"> O tamanho inicial do PC</param>
public class PokemonPc(int size = 4) : IStorage
{
    /// <summary>
    /// Array interno com os pokemons no PC
    /// 
    /// Inicialmente cabem 4 Pokemons, mas o tamanho inicial 
    /// pode ser definido no construtor da classe
    /// 
    /// Vale ressaltar que, com o método privado Resize(), este
    /// array se torna meio que um arrayList
    /// </summary>
    private Pokemon[] pc = new Pokemon[size];
    /// <summary>
    /// Quantidade de Pokemons no PC, inicialmente começando
    /// como 0 Pokemons
    /// </summary>
    private int quantity = 0;

    /// <summary>
    /// Implementação de AddPokemon de IStorage
    /// 
    /// Complexidade O(n+1) pois seu tempo de execução depende de quantos 
    /// Pokemons estão no PC, se não extrapola o limite do arrayList
    /// interno o tempo é o mesmo de O(1), caso contrário o tempo será 
    /// o de O(n) mesmo
    /// </summary>
    /// <param name="pokemon"> O pokemon a ser adicionado </param>
    /// <returns>
    /// Verdadeiro se o Pokemon foi adicionado, falso se deu errado
    /// </returns>
    public bool AddPokemon(Pokemon pokemon)
    {
        if (quantity >= pc.Length)
            Resize();
        
        pc[quantity] = pokemon;
        quantity++;

        return true;
    }

    /// <summary>
    /// Implementação de AddPokemonAtPosition de IStorage
    /// 
    /// Complexidade (m*n), pois o seu tempo de execução dependem
    /// de quantos Pokemons estão presentes no PC (definido por m)
    /// e em qual posição o usuário deseja adicionar o Pokemon 
    /// (definido por n)
    /// </summary>
    /// <param name="pokemon"> O Pokemon a ser adicionado </param>
    /// <param name="position"> A posição onde o Pokemon será adicionado </param>
    /// <returns>
    /// Verdadeiro se o Pokemon foi adicionado, falso se deu errado
    /// </returns>
    public bool AddPokemonAtPosition(Pokemon pokemon, int position)
    {
        if (position < 0 || position > quantity) 
            return false;
        
        if (quantity >= pc.Length)
            Resize();
        
        for (int i = quantity; i > position; i--)
            pc[i] = pc[i - 1];
        
        pc[position] = pokemon;
        quantity++;
        return true;
    }

    /// <summary>
    /// Implementação de GetPokemon de IStorage
    /// 
    /// Complexidade O(1) por operar utilizando apenas
    /// uma simples procura de índice
    /// </summary>
    /// <param name="position"> A posição onde o Pokemon se encontra </param>
    /// <returns> O objeto do Pokemon escolhido </returns>
    /// <exception cref="PokemonStorageException">
    /// Ela é disparada para caso tente escolher um Pokemon numa posição inválida
    /// </exception>
    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return pc[position];
    }

    /// <summary>
    /// Implementação de RemovePokemon de IStorage
    /// 
    /// Complexidade O(n) pois seu tempo de execução depende
    /// de quantos Pokemons estão no PC
    /// </summary>
    /// <param name="position"> A posição do Pokemon a ser removido</param>
    /// <returns> O objeto do Pokemon a ser removido </returns>
    /// <exception cref="PokemonStorageException">
    /// Ela é disparada para caso o usuário tente remover um Pokemon em um
    /// índice inválido
    /// </exception>
    public Pokemon RemovePokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();

        var removed = pc[position];

        for (int i = position; i < quantity - 1; i++)
            pc[i] = pc[i + 1];

        pc[quantity - 1] = null!;
        quantity--;

        return removed;
    }

    /// <summary>
    /// Implementação de ListPokemon de IStorage
    /// 
    /// Complexidade O(1) por ser apenas um get()
    /// </summary>
    /// <returns> O Array com os Pokemons no PC </returns>
    public Pokemon[] ListPokemon()
    {
        return pc;
    }

    /// <summary>
    /// Implementação de Move de IStorage
    /// 
    /// Complexidade O(1) por mexer apenas com
    /// procura de indices de array, fazendo o tempo
    /// de execução ser sempre constante
    /// </summary>
    /// <param name="pos1"> A posição inicial </param>
    /// <param name="pos2"> A posição final </param>
    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;
        
        var aux = pc[pos1];
        pc[pos1] = pc[pos2];
        pc[pos2] = aux;
    }

    /// <summary>
    /// Implementação de GetQuantity de IStorage
    /// 
    /// Complexidade O(1) por ser apenas um get()
    /// </summary>
    /// <returns> A quantidade de Pokemons no PC </returns>
    public int GetQuantity()
    {
        return quantity;
    }

    // Método privado

    /// <summary>
    /// Método de retorno vazio que transforma o
    /// array interno num arrayList pois permite
    /// crescimento de tamanho
    /// 
    /// Complexidade O(n) pois seu tempo de execução
    /// depende de quantos Pokemons estão no PC atualmente
    /// </summary>
    private void Resize()
    {
        int newSize = pc.Length * 2;
        var newPc = new Pokemon[newSize];

        for (int i = 0; i < quantity; i++)
            newPc[i] = pc[i];
        
        pc = newPc;
    }

    public bool UpdatePokemon(int position)
    {
        return false;
    }
}