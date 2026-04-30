/// <summary>
/// Classe que implementa a interface IStorage
/// para fazer operações envolvendo armazenamento
/// de Pokemons no PC
/// </summary>
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
    /// Implementação de AddPokemon de IStorage para adicionar um Pokemon
    /// ao Pc
    /// 
    /// Complexidade O(n+1) pois seu tempo de execução depende de quantos 
    /// Pokemons estão no PC, se não extrapola o limite do arrayList
    /// interno o tempo é o mesmo de O(1), caso contrário o tempo será 
    /// o de O(n) mesmo
    /// </summary>
    public bool AddPokemon(Pokemon pokemon)
    {
        if (quantity >= pc.Length)
            Resize();
        
        pc[quantity] = pokemon;
        quantity++;

        return true;
    }

    /// <summary>
    /// Implementação de AddPokemonAtPosition de IStorage para adicionar um 
    /// Pokemon ao Pc numa posição específica
    /// 
    /// Complexidade (m*n), pois o seu tempo de execução dependem
    /// de quantos Pokemons estão presentes no PC (definido por m)
    /// e em qual posição o usuário deseja adicionar o Pokemon 
    /// (definido por n)
    /// </summary>
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
    /// Implementação de GetPokemon de IStorage para retornar
    /// o objeto do Pokemon escolhido
    /// 
    /// Complexidade O(1) por operar utilizando apenas
    /// uma simples procura de índice
    /// </summary>
    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return pc[position];
    }

    /// <summary>
    /// Implementação de RemovePokemon de IStorage para remover
    /// um Pokemon escolhido 
    /// 
    /// Complexidade O(n) pois seu tempo de execução depende
    /// de quantos Pokemons estão no PC
    /// </summary>
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
    /// Implementação de ListPokemon de IStorage para retornar
    /// o array interno da classe 
    /// 
    /// Complexidade O(1) por ser apenas um get()
    public Pokemon[] ListPokemon()
    {
        return pc;
    }

    /// <summary>
    /// Implementação de Move de IStorage para mover Pokemons
    /// de uma posição a para uma posição b
    /// 
    /// Complexidade O(1) por mexer apenas com
    /// procura de indices de array, fazendo o tempo
    /// de execução ser sempre constante
    /// </summary>
    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;
        
        var aux = pc[pos1];
        pc[pos1] = pc[pos2];
        pc[pos2] = aux;
    }

    /// <summary>
    /// Implementação de GetQuantity de IStorage para 
    /// retornar a quantidade de Pokemons no Pc
    /// 
    /// Complexidade O(1) por ser apenas um get()
    /// </summary>
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

    /// <summary>
    /// Implementação de UpdatePokemon de IStorage para atualizar
    /// os dados de um Pokemon
    /// 
    /// Complexidade O(1) pois aqui no Pc ela não faz nada, só tá aí
    /// por questão evolutiva igual é com o apêndice perto do intestíno
    /// </summary>
    public bool UpdatePokemon(int position)
    {
        return false;
    }
}