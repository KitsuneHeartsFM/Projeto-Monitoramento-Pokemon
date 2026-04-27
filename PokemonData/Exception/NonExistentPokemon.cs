/// <summary>
/// Classe de exceção customizada para caso seja inserido
/// uma espécie Pokemon não definida no programa
/// </summary>
public class NonExistentPokemon : Exception
{
    /// <summary>
    /// Construtor da classe
    /// 
    /// Por tabela, ele usa o construtor da classe
    /// pai Exception
    /// </summary>
    public NonExistentPokemon() : base("An invalid Pokemon has been inserted!")
    {    
    }
}