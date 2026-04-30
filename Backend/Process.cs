/// <summary>
/// A classe com as operações d.1, d.2, d.3 e d.4
/// </summary>
public class Process : IProcess
{

    // d.1
    /// <summary>
    /// O método que lista todos os Pokemons armazenados
    /// 
    /// Complexidade O(n) pois seu tempo de execução depende de quantos 
    /// Pokemons estão sendo armazenados no momento
    /// </summary>
    public string[] ShowAllPokemon(IStorage storage)
    {
        var aux = storage.ListPokemon();
        string[] output = new string[storage.GetQuantity()];

        for (int i = 0; i < output.Length; i++)
            output[i] = $"{aux[i].Id}. {aux[i].Species}";
        
        return output;
    }

    // d.2
    /// <summary>
    /// Método que retorna informações individuais de um Pokemon escolhido
    /// 
    /// Complexidade O(1) por ser um método ToString() gourmetizado mas ainda
    /// com tempo constante de execução
    /// </summary>
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
    /// <summary>
    /// Método de ordenação dos Pokemons armazenados por nível
    /// e em ordem ascendente
    /// 
    /// Complexidade O(n²) pois utiliza um algorítmo de bubbleSort
    /// para fazer a ordenação
    /// </summary>
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
    /// <summary>
    /// Método para upar todos os Pokemons armazenados até o nível 100, 
    /// além de deixar eles com 255 de amizade e evoluir eles
    /// 
    /// Complexidade O(n²) pois pega todos os Pokemons armazenados, aumenta seus níveis 
    /// e analisa individualmente se eles podem evoluir, se sim eles evoluem dentro do loop
    /// 
    /// dentro desse loop inicial outro loop é criado para se certificar que todos os Pokemons
    /// tenham suas amizades aumentadas até o máximo
    /// </summary>
    public void MinMax(IStorage storage, int position)
    {
        var aux = storage.GetPokemon(position);

        for (int i = 0; i < storage.GetQuantity(); i++)
        {
            bool isEvolutionPossible = aux.Evolution.EvolvesTo != null && aux.Evolution.NextEvolutionLevel != null;
            aux.LevelUp();

            if (isEvolutionPossible)
                if (aux.Level >= aux.Evolution.NextEvolutionLevel)
                    storage.UpdatePokemon(i);
            
            for (int j = 0; j < storage.GetQuantity(); j++)
            {
                if (aux.Friendship < 255)
                {
                    int remainingFriendship = 256 - aux.Friendship;

                    for (int k = 0; k < remainingFriendship; k++)
                        aux.FriendshipUp();
                }
            }
        }
    }

    private static void OverwriteStorage(IStorage storage, Pokemon[] newList, int size)
    {
        Pokemon[] copy = new Pokemon[size];
        Array.Copy(newList, copy, size);

        for (int i = 0; i < size; i++)
            storage.RemovePokemon(0);
        
        for (int i = 0; i < size; i++)
            storage.AddPokemon(copy[i]); 
    }
}