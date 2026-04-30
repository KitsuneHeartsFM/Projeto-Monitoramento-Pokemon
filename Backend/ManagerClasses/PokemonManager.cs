// chamada da classe estática GetPokemon
using static GetPokemon;

/// <summary>
/// A classe que gerencia os Pokemons tanto no time quanto no PC
/// </summary>
public class PokemonManager
{
    /// <summary>
    /// Registro de Pokemons no time
    /// </summary>
    public IStorage Team {get; private set;}
    /// <summary>
    /// Registro de Pokemons no PC
    /// </summary>
    public IStorage Pc {get; private set;}
    /// <summary>
    /// Variável de controle que garante que todos os Pokemons sejam criados
    /// apenas uma vez, quando o projeto é inicializado
    /// </summary>
    private bool created = false;

    /// <summary>
    /// Construtor de PokemonManager
    /// </summary>
    public PokemonManager()
    {
        Team = new PokemonTeam();
        Pc = new PokemonPc();
    }

    /// <summary>
    /// Método que gera os Pokemons e os coloca no time e no PC
    /// 
    /// Complexidade O(n) pois seu tempo de execução depende de
    /// quantos Pokemons são gerados
    /// </summary>
    public void GeneratePokemon()
    {
        if (created) return;

        var pkmn = GetPokemonGroup(10);

        foreach (var p in pkmn)
            if (!Team.AddPokemon(p))
                Pc.AddPokemon(p);
        
        created = true;
    }

    /// <summary>
    /// Método que tira o Pokemon do time e o coloca no PC
    /// 
    /// Complexidade O(n) pois como ambas classes derivadas
    /// de IStorage usam array para guardar os Pokemons, a
    /// depender da posição do Pokemon demora mais para reordenar
    /// o array
    /// </summary>
    public bool Deposit(int position)
    {
        try
        {
            var p = Team.RemovePokemon(position);

            Pc.AddPokemon(p);

            return true;
        }   
        catch (PokemonStorageException)
        {
            return false;
        }
    }

    /// <summary>
    /// Método que tira o Pokemon do PC e o coloca no Time
    /// 
    /// Complexidade O(n) pois como ambas classes derivadas
    /// de IStorage usam array para guardar os Pokemons, a
    /// depender da posição do Pokemon demora mais para reordenar
    /// o array
    /// </summary>
    public bool Withdraw(int position)
    {
        try
        {
            var p = Pc.RemovePokemon(position);
            bool output = true;

            if (!Team.AddPokemon(p))
            {
                Pc.AddPokemonAtPosition(p, position);
                output = false;
            }
                

            return output;
        }
        catch (PokemonStorageException)
        {
            return false;
        }
    }

    /// <summary>
    /// Método para simular a passagem de tempo
    /// 
    /// Complexidade O(m*n) pois seu tempo de execução
    /// depende de quantos Pokemons tem no time (representado
    /// por m) e quantos tem no Pc (representado por n)
    /// </summary>
    public void TimePassing()
    {
        var TeamList = Team.ListPokemon();
        var PcList = Pc.ListPokemon();

        foreach (var p in TeamList)
            p.FriendshipUp();
        
        foreach (var p in PcList)
            p.FriendshipDown();
    }
}