public interface IProcess
{
    // d.1  Impressão de todos os objetos armazenados
    string[] ShowAllPokemon(IStorage storage);
    // d.2  Impressão de leituras específicas
    string ShowPokemonInfo(IStorage storage, int position);
    // d.3  Ordenação dos objetos
    void OrderAll(IStorage storage);
    // d.4  Função única do programa de Complexidade O(n²) ou mais
    void MinMax(IStorage storage, int position);
}