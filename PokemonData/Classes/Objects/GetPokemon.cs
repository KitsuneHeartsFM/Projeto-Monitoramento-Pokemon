/// <summary>
/// Classe Get feita especificamente para objetos 
/// do tipo Pokemon
/// </summary>
public class GetPokemon : IGenerate<Pokemon>
{
    /// <summary>
    /// Inicialização do objeto do tipo Random 
    /// utilizado nos métodos da classe
    /// </summary>
    private Random random = new();
    /// <summary>
    /// Inicialização de um contador especial
    /// para o id dos pokemons
    /// 
    /// ele está definido como estático pois
    /// assim seu valor consegue ser armazenado e 
    /// atualizado dentro da classe mesmo
    /// </summary>
    private static int idCount = 1;
    
    /// <summary>
    /// Método que retorna uma instância de um objeto do
    /// tipo Pokemon
    /// 
    /// Complexidade O(1) pois as únicas operações que ocorrem
    /// são duas inicializações e um retorno de um Pokemon
    /// </summary>
    /// <param name="species"> A espécie do Pokemon a ser inserida </param>
    /// <returns> Uma instância de um objeto do tipo Pokemon </returns>
    public Pokemon GetData(PokemonSpecies species)
    {
        // instancia randomizada do nível do Pokemon entre 1 e 100
        int level = random.Next(1, 101);
        // instancia randomizada da amizade do Pokemon entre 0 e 255
        int friendship = random.Next(0, 256);

        // retorno da instância do objeto Pokemon
        return new(idCount++, level, friendship, species);
    }

    /// <summary>
    /// Um método que retorna um array de objetos do tipo Pokemon
    /// 
    /// Ele também utiliza de randomizador para a espécie Pokemon
    /// 
    /// Complexidade O(n) pois seu tempo de execução depende de quantos
    /// Pokemons o usuário deseja criar
    /// </summary>
    /// <param name="amount"> Quantos Pokemons o usuário deseja gerar </param>
    /// <returns>
    /// Um array de objetos do tipo Pokemon cujo tamanho é igual ao valor
    /// definido no parâmetro amount
    /// </returns>
    public Pokemon[] GetPokemonGroup(int amount)
    {
        // Variável com os dados de retorno do método
        var aux = new Pokemon[amount];

        // Um objeto do tipo Array é criado recebendo todos os valores dentro
        // do arquivo Enum PokemonSpecies
        Array pokemonGroup = Enum.GetValues(typeof(Pokemon));
        // Um objeto com o valor de PokemonSpecies obtido através do objeto
        // pokemonGroup e um randomizador com o tamanho de PokemonSpecies
        PokemonSpecies pokemon = (PokemonSpecies) pokemonGroup.GetValue(random.Next(pokemonGroup.Length))!;

        // For loop onde são gerados os Pokemons de acordo
        // a quantidade desejada pelo usuário
        for (int i = 0; i < amount; i++)
            aux[i] = GetData(pokemon);
        
        // Retorno do array com os Pokemons gerados
        return aux;
    }
}