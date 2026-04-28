/// <summary>
/// Interface para classes com operações de
/// armazenamento de Pokemons
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Função para adicionar Pokemon no armazenamento
    /// </summary>
    /// <param name="pokemon"> O Pokemon a ser inserido</param>
    /// <returns> Verdadeiro se bem sucedido, falso se falhar</returns>
    bool AddPokemon(Pokemon pokemon);
    /// <summary>
    /// Função para remover Pokemon no armazenamento
    /// </summary>
    /// <param name="position"> A posição onde o Pokemon se encontra</param>
    /// <returns> O Pokemon removido </returns>
    Pokemon RemovePokemon(int position);
    /// <summary>
    /// Função para retornar um Pokemon
    /// </summary>
    /// <param name="position"> A posição do Pokemon escolhido </param>
    /// <returns> O objeto Pokemon escolhido </returns>
    Pokemon GetPokemon(int position);
    /// <summary>
    /// Função para adicionar um Pokemon numa posição específica
    /// </summary>
    /// <param name="pokemon"> O Pokemon a ser inserido </param>
    /// <param name="position"> A posição escolhida </param>
    /// <returns> Verdadeiro se tudo ocorrer bem, falso se der errado</returns>
    bool AddPokemonAtPosition(Pokemon pokemon, int position);
    /// <summary>
    /// Função para mover Pokemon dentro de armazenamento
    /// </summary>
    /// <param name="pos1"> Posição inicial </param>
    /// <param name="pos2"> Posição final </param>
    void Move(int pos1, int pos2);
    /// <summary>
    /// Impressão dos Pokemons armazenados
    /// </summary>
    /// <returns> Array de objetos do tipo Pokemon </returns>
    Pokemon[] ListPokemon();
    /// <summary>
    /// Funcão que retorna quantos Pokemons estão armazenados no local
    /// </summary>
    int GetQuantity();
}