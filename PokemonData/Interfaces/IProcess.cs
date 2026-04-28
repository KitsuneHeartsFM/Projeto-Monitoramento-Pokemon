public interface IProcess
{
    // d.1  Impressão de todos os objetos armazenados
    void ShowAllPokemon(IStorage storage);
    // d.2  Impressão de leituras específicas
    void ShowPokemonInfo(IStorage storage, int position);
    // d.3  Ordenação dos objetos
    void OrderAll(IStorage storage);
    // d.4  Função única do programa de Complexidade O(n²) ou mais
    void Evolve(IStorage storage, int position);
}