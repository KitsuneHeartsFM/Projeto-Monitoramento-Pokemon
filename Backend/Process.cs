public class Process : IProcess
{

    // d.1
    public void ShowAllPokemon(IStorage storage)
    {
        var aux = storage.ListPokemon();
        int index = 1;

        for (int i = 0; i < storage.GetQuantity(); i++)
            Console.WriteLine($"{index++}. {aux[i].Species}");
    }

    // d.2
    public void ShowPokemonInfo(IStorage storage, int position)
    {
        var p = storage.GetPokemon(position);
        var baseStats = p.BaseStats.ToArray();

        Console.WriteLine($"{p.Species}, it has the {p.Typing} typing.");
        Console.WriteLine($"{p.Evolution}");
        Console.WriteLine();
        Console.WriteLine($"It has as base stats: ");
        Console.WriteLine($"HP: {baseStats[0]}");
        Console.WriteLine($"ATK: {baseStats[1]}");
        Console.WriteLine($"DEF: {baseStats[2]}");
        Console.WriteLine($"SPA: {baseStats[3]}");
        Console.WriteLine($"SPD: {baseStats[4]}");
        Console.WriteLine($"SPE: {baseStats[5]}");
        Console.WriteLine();
        Console.WriteLine($"Your {p.Species} has the Id nº {p.Id},\nis at Level {p.Level} and has\n{p.Friendship} friendship points.");
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
    public void Evolve(IStorage storage, int position)
    {
        throw new NotImplementedException();
    }

    private void OverwriteStorage(IStorage storage, Pokemon[] newList, int size)
    {
        for (int i = 0; i < size; i++)
            storage.RemovePokemon(0);
        
        for (int i = 0; i < size; i++)
            storage.AddPokemon(newList[i]);
    }
}