/// <summary>
/// Interface para classes com operações de
/// armazenamento de Pokemons
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Função para adicionar Pokemon no armazenamento
    /// </summary>
    bool AddPokemon(Pokemon pokemon);
    /// <summary>
    /// Função para remover Pokemon no armazenamento
    /// </summary>
    Pokemon RemovePokemon(int position);
    /// <summary>
    /// Função para retornar um Pokemon
    /// </summary>
    Pokemon GetPokemon(int position);
    /// <summary>
    /// Função para adicionar um Pokemon numa posição específica
    /// </summary>
    bool AddPokemonAtPosition(Pokemon pokemon, int position);
    /// <summary>
    /// Função para mover Pokemon dentro de armazenamento
    /// </summary>
    void Move(int pos1, int pos2);
    /// <summary>
    /// Impressão dos Pokemons armazenados
    /// </summary>
    Pokemon[] ListPokemon();
    /// <summary>
    /// Funcão que retorna quantos Pokemons estão armazenados no local
    int GetQuantity();

    /// <summary>
    /// Método para atualizar dados de algum Pokemon
    /// </summary>
    bool UpdatePokemon(int position);
}