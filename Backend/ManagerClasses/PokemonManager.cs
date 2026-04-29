using static GetPokemon;

public class PokemonManager
{
    public IStorage Team {get; private set;}
    public IStorage Pc {get; private set;}
    private bool created = false;

    public PokemonManager()
    {
        Team = new PokemonTeam();
        Pc = new PokemonPc();
    }

    public void GeneratePokemon()
    {
        if (created) return;

        var pkmn = GetPokemonGroup(10);

        foreach (var p in pkmn)
            if (!Team.AddPokemon(p))
                Pc.AddPokemon(p);
        
        created = true;
    }

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