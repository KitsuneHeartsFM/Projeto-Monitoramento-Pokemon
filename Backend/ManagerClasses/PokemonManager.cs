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
        try
        {
            var p = Team.RemovePokemon(position);

            Pc.AddPokemon(p);
        }   
        catch (PokemonStorageException)
        {
        }
    }

    public void Withdraw(int position)
    {
        try
        {
            var p = Pc.RemovePokemon(position);

            if (!Team.AddPokemon(p))
                Pc.AddPokemonAtPosition(p, position);
        }
        catch (PokemonStorageException)
        {
        }
    }

    public void TimePassing()
    {
        var TeamList = Team.ListPokemon();
        var PcList = Pc.ListPokemon();

        for (int i = 0; i < Team.GetQuantity(); i++)
            TeamList[i].FriendshipUp();
        
        for (int i = 0; i < Pc.GetQuantity(); i++)
            PcList[i].FriendshipDown();
    }
}