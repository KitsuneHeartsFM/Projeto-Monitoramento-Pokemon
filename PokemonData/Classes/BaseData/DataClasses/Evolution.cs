/// <summary>
/// Esta classe tem uma função similar às classes BaseStats
/// e Typing, a diferença sendo que esta em especial armazena
/// dados envolvendo evoluções de Pokemons em geral
/// </summary>
/// <param name="nextEvolutionLevel?"> Em que nível o Pokemon pode evoluir </param>
/// <param name="evolvesTo?"> Para qual Pokemon pode evoluir </param>
/// <param name="lastEvolutionLevel?"> Em que nível ele pode ter evoluido </param>
/// <param name="evolvedFrom?"> De qual Pokemon ele evoluiu </param>
public class Evolution (int? nextEvolutionLevel = null, Pokemon? evolvesTo = null, int? lastEvolutionLevel = null, Pokemon? evolvedFrom = null)
{
    /// <summary>
    /// Este campo armazena o nível onde este Pokemon pode evoluir
    /// 
    /// Ele pode ser nulo para o caso do Pokemon ser o último de sua
    /// linha evolutiva
    /// </summary>
    public int? NextEvolutionLevel {get => field; private set => field = nextEvolutionLevel;}
    /// <summary>
    /// Este campo armazena qual Pokemon este se tornará ao evoluir
    /// 
    /// Ele pode ser nulo pelo mesmo motivo de NextEvolutionLevel
    /// </summary>
    public Pokemon? EvolvesTo {get => field; private set => field = evolvesTo;}
    /// <summary>
    /// Este campo armazena em qual nível o Pokemon pode ter evoluído
    /// 
    /// Ele pode nulo para o caso do Pokemon ser o primeiro de sua
    /// linha evolutiva
    /// </summary>
    public int? LastEvolutionLevel {get => field; private set => field = lastEvolutionLevel;}
    /// <summary>
    /// Este campo armazena de qual Pokemon este evoluiu
    /// 
    /// Ele pode ser nulo pelo mesmo motivo de LastEvolutionLevel
    /// </summary>
    public Pokemon? EvolvedFrom {get => field; private set => field = evolvedFrom;}

    /// <summary>
    /// Uma sobrecarga do método ToString() para retornar os dados a cerca das
    /// evoluções do Pokemon
    /// </summary>
    /// <returns>
    /// A depender se os campos NextEvolutionLevel e/ou LastEvolutionLevel 
    /// (NEL e LEL respectivamente para simplificar a explicação) são nulos
    /// ou não. Sendo eles:
    /// 
    /// 1. Se nem NEL nem LEL são nulos: retorna uma string dizendo que o 
    /// Pokemon evolui de Pokemon A no nível X e que pode evoluir para o 
    /// Pokemon B pelo nível Y
    /// 
    /// Este é o retorno para Pokemons do meio da linha evolutiva tipo 
    /// Grovyle, Combusken e Marshtomp
    /// 
    /// 2. Se apenas LEL é nulo: retorna que o Pokemon pode evoluir para
    /// Pokemon A pelo nível X
    /// 
    /// Este é o retorno para Pokemons do início da linha evolutiva tipo
    /// Treecko, Torchich e Mudkip
    /// 
    /// 3. Se apenas NEL é nulo: retorna que o Pokemon evoluiu de Pokemon A
    /// no nível X
    /// 
    /// Este é o retorno para Pokemóns do fim da linha evolutiva tipo 
    /// Sceptile, Blaziken e Swampert
    /// </returns>
    public override string ToString()
    {
        // A variável responsável por armazenar a impressão final
        string output;
        
        // Condicional para sair a impressão do caso 1
        if (NextEvolutionLevel != null && LastEvolutionLevel != null)
        {
            output = $"It evolved from {EvolvedFrom} at level {LastEvolutionLevel} and may evolve to {EvolvesTo} by the level {NextEvolutionLevel}!";
        }
        // Condicional para sair a impressão do caso 2
        else if (NextEvolutionLevel != null && LastEvolutionLevel == null)
        {
            output = $"It may evolve to {EvolvesTo} by the level {NextEvolutionLevel}!";
        }
        // Condicional para sair a impressão do caso 3
        else
        {
            output = $"It evolved from {EvolvedFrom} at level {LastEvolutionLevel}!";
        }

        // O retorno de ToString() com as modificações vindas na variável output
        return output;
    }
}