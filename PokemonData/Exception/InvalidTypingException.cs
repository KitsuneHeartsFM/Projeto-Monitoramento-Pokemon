/// <summary>
/// Classe de exceção customizada para caso na hora que for inserida a
/// tipagem de um Pokemon não ocorrer de inserir tipagem inválida, ex.:
/// Tipo Primário Fogo e tipo Secundário Fogo
/// </summary>
public class InvalidTypingException : Exception
{
    /// <summary>
    /// Construtor da classe
    /// 
    /// Ele usa por tabela o construtor da classe
    /// pai Exception
    /// </summary>
    public InvalidTypingException() : base("An invalid pokemon typing data has been inserted!")
    {
    }
}