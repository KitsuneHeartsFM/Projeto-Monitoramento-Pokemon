public class Process : IProcess
{

    // d.1
    public string[] ShowAllPokemon(IStorage storage)
    {
        var aux = storage.ListPokemon();
        string[] output = new string[storage.GetQuantity()];

        for (int i = 0; i < output.Length; i++)
            output[i] = $"{aux[i].Id}. {aux[i].Species}";
        
        return output;
    }

    // d.2
    public string ShowPokemonInfo(IStorage storage, int position)
    {
        var p = storage.GetPokemon(position);
        var baseStats = p.BaseStats?.ToArray();

        string output = $"{p.Species}, it has the {p.Typing} typing.\n"
        + $"{p.Evolution}\n\n"
        + $"It has as base stats:\n"
        + $"HP: {baseStats?[0]}\n"
        + $"ATK: {baseStats?[1]}\n"
        + $"DEF: {baseStats?[2]}\n"
        + $"SPA: {baseStats?[3]}\n"
        + $"SPD: {baseStats?[4]}\n"
        + $"SPE: {baseStats?[5]}\n\n"
        + $"Your {p.Species} has the Id nº {p.Id},\nis at Level {p.Level} and has\n{p.Friendship} friendship points.";

        return output;
    }

    // d.3
    public void OrderAll(IStorage storage)
    {
        var pkmn = storage.ListPokemon();
        int n = storage.GetQuantity();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0;j < n - i - 1; j++)
            {
                if (pkmn[j].Level > pkmn[j + 1].Level)
                {
                    var aux = pkmn[j];
                    pkmn[j] = pkmn[j+1];
                    pkmn[j+1] = aux;
                }
            }
        }

        OverwriteStorage(storage, pkmn, n);
    }
    
    // d.4
    public bool Evolve(IStorage storage, int position)
    {
        if (position < 0 || position >= storage.GetQuantity())
            return false;

        return storage.UpdatePokemon(position);
    }

    private void OverwriteStorage(IStorage storage, Pokemon[] newList, int size)
    {
        Pokemon[] copy = new Pokemon[size];
        Array.Copy(newList, copy, size);

        for (int i = 0; i < size; i++)
            storage.RemovePokemon(0);
        
        for (int i = 0; i < size; i++)
            storage.AddPokemon(copy[i]); 
    }
}