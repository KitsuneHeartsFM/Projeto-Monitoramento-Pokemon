/// <summary>
/// Classe que implementa a interface IStorage
/// para fazer operações envolvendo armazenamento
/// de Pokemon no time
/// </summary>
public class PokemonTeam : IStorage
{
    private Pokemon[] team;
    private int quantity;

    public PokemonTeam()
    {
        team = new Pokemon[6];
        quantity = 0;
    }

    public bool AddPokemon(Pokemon pokemon)
    {
        if (quantity >= 6)
            return false;
        
        team[quantity] = pokemon;
        quantity++;
        return true;
    }

    public bool AddPokemonAtPosition(Pokemon pokemon, int position)
    {
        if (quantity >= 6 || position < 0 || position >= quantity)
            return false;
        
        for (int i = quantity; i > position; i--)
            team[i] = team[i-1];
        
        team[position] = pokemon;
        quantity++;

        return true;
    }

    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return team[position];
    }

    public Pokemon RemovePokemon(int position)
    {
        if (position < 0 || position >= quantity || quantity <= 1)
            throw new PokemonStorageException();
        
        var removed = team[position];

        for (int i = position; i < quantity - 1; i++)
            team[i] = team[i + 1];

        team[quantity - 1] = null;
        quantity--;

        return removed;
    }

    public Pokemon[] ListPokemon()
    {
        return team;
    }

    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;

        var aux = team[pos1];
        team[pos1] = team[pos2];
        team[pos2] = aux;
    }

    public int GetQuantity()
    {
        return quantity;
    }

}