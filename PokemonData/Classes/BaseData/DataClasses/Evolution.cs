/// <summary>
/// Esta classe tem uma função similar às classes BaseStats
/// e Typing, a diferença sendo que esta em especial armazena
/// dados envolvendo evoluções de Pokemons em geral
/// </summary>
public class Evolution (int? nextEvolutionLevel = null, PokemonSpecies? evolvesTo = null, int? lastEvolutionLevel = null, PokemonSpecies? evolvedFrom = null)
{
    /// <summary>
    /// Este campo armazena o nível onde este Pokemon pode evoluir
    /// 
    /// Ele pode ser nulo para o caso do Pokemon ser o último de sua
    /// linha evolutiva
    /// </summary>
    public int? NextEvolutionLevel {get; private set;} = nextEvolutionLevel;
    /// <summary>
    /// Este campo armazena qual Pokemon este se tornará ao evoluir
    /// 
    /// Ele pode ser nulo pelo mesmo motivo de NextEvolutionLevel
    /// </summary>
    public PokemonSpecies? EvolvesTo {get; private set;} = evolvesTo;
    /// <summary>
    /// Este campo armazena em qual nível o Pokemon pode ter evoluído
    /// 
    /// Ele pode nulo para o caso do Pokemon ser o primeiro de sua
    /// linha evolutiva
    /// </summary>
    public int? LastEvolutionLevel {get; private set;} = lastEvolutionLevel;
    /// <summary>
    /// Este campo armazena de qual Pokemon este evoluiu
    /// 
    /// Ele pode ser nulo pelo mesmo motivo de LastEvolutionLevel
    /// </summary>
    public PokemonSpecies? EvolvedFrom {get; private set;} = evolvedFrom;

    /// <summary>
    /// Uma sobrecarga do método ToString() para retornar os dados a cerca das
    /// evoluções do Pokemon
    /// 
    /// Complexidade O(1) por não ter loop de interação nem nada para aumentar
    /// o tempo de execução
    /// 
    /// Retorna coisa se estiver no meio da linha evolutiva (caso 1), se estiver
    /// no início da linha evolutiva (caso 2) ou se estiver no fim da linha evolutiva
    /// (caso 3)
    /// </summary>
    public override string ToString()
    {
        // A variável responsável por armazenar a impressão final
        string output;
        
        // Condicional para sair a impressão do caso 1
        if (NextEvolutionLevel != null && LastEvolutionLevel != null)
        {
            output = $"It evolved from {EvolvedFrom} at level {LastEvolutionLevel}\nand may evolve to {EvolvesTo}\nby the level {NextEvolutionLevel}.";
        }
        // Condicional para sair a impressão do caso 2
        else if (NextEvolutionLevel != null && LastEvolutionLevel == null)
        {
            output = $"It may evolve to {EvolvesTo} by the level {NextEvolutionLevel}.";
        }
        // Condicional para sair a impressão do caso 3
        else
        {
            output = $"It evolved from {EvolvedFrom} at level {LastEvolutionLevel}.";
        }

        // O retorno de ToString() com as modificações vindas na variável output
        return output;
    }
}