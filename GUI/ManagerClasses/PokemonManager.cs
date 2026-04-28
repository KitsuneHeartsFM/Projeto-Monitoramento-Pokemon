public class PokemonManager
{
    public IStorage Team {get; private set;}
    public IStorage Pc {get; private set;}
    private GetPokemon getPokemon;

    public PokemonManager()
    {
        Team = new PokemonTeam();
        Pc = new PokemonPc();
        getPokemon = new();
    }

    public void GeneratePokemon()
    {
        var pkmn = getPokemon.GetPokemonGroup(10);

        foreach (var p in pkmn)
            if (!Team.AddPokemon(p))
                Pc.AddPokemon(p);
    }

    public void Deposit(int position)
    {
        var p = Team.RemovePokemon(position);

        Pc.AddPokemon(p);
    }

    public void Withdraw(int position)
    {
        var p = Pc.RemovePokemon(position);

        Team.AddPokemon(p);
    }

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