public interface IProcess
{
    // d.1  Impressão de todos os objetos armazenados
    /// <summary>
    /// Método para mostrar todos os Pokemons registrados
    /// </summary>
    string[] ShowAllPokemon(IStorage storage);
    // d.2  Impressão de leituras específicas
    /// <summary>
    /// Método para mostrar informações de um Pokemon em específico
    /// </summary>
    string ShowPokemonInfo(IStorage storage, int position);
    // d.3  Ordenação dos objetos
    /// <summary>
    /// Método de ordenação do projeto
    /// </summary>
    void OrderAll(IStorage storage);
    // d.4  Função única do programa de Complexidade O(n²) ou mais
    /// <summary>
    /// Método para aumentar o nível e a amizade do Pokemon até o máximo,
    /// além de evoluir o Pokemon se possível
    /// </summary>
    void MinMax(IStorage storage, int position);
}