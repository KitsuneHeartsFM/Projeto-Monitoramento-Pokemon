public class PokemonPc(int size = 4) : IStorage
{
    private Pokemon pc = new Pokemon[size];
    private int quantity = 0;

    public bool AddPokemon(Pokemon pokemon)
    {
        if (quantity >= pc.Length)
            Resize();
        
        pc[quantity] = pokemon;
        quantity++;

        return true;
    }

    public bool AddPokemonAtPosition(Pokemon pokemon, int position)
    {
        if (position < 0 || position > quantity) 
            return false;
        
        if (quantity >= pc.Length)
            Resize();
        
        for (int i = quantity; i > position; i--)
            pc[i] = pc[i - 1];
        
        pc[position] = pokemon;
        quantity++;
        return true;
    }

    public Pokemon GetPokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();
        
        return pc[position];
    }

    public Pokemon RemovePokemon(int position)
    {
        if (position < 0 || position >= quantity)
            throw new PokemonStorageException();

        var removed = pc[position];

        for (int i = position; i < quantity - 1; i++)
            pc[i] = pc[i + 1];

        pc[quantity - 1] = null;
        quantity--;

        return removed;
    }

    public Pokemon[] ListPokemon()
    {
        return pc;
    }

    public void Move(int pos1, int pos2)
    {
        if (pos1 < 0 || pos2 < 0||pos1 >= quantity || pos2 >= quantity)
            return;
        
        var aux = pc[pos1];
        pc[pos1] = pc[pos2];
        pc[pos2] = pc[pos1];
    }

    public int GetQuantity()
    {
        return quantity;
    }

    // Método privado

    /// <summary>
    /// Método de retorno vazio que transforma o
    /// array interno num arrayList pois permite
    /// crescimento de tamanho
    /// </summary>
    private void Resize()
    {
        int newSize = pc.Length * 2;
        var newPc = new Pokemon[newSize];

        for (int i = 0; i < quantity; i++)
            newPc[i] = pc[i];
        
        pc = newPc;
    }

}