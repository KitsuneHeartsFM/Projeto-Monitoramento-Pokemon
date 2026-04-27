/// <summary>
/// Esta é uma classe com uma função similar a BaseStats, com a 
/// diferença de que no lugar de pontos base ela armazena a
/// tipagem do Pokemon
/// 
/// C# permite chamar o construtor na mesma linha que 
/// chama uma classe e, a depender do que insere nesse construtor especial,
/// isto já torna possível efetuar uma sobrecarga automática de construtor
/// 
/// Um adendo é que este construtor na linha da classe só é efetivo em classes
/// com funções similares a um POJO em Java, como esta classe aqui. Para classes
/// onde é necessário colocar coisas extras no construtor, é mais recomendado 
/// usar um construtor padrão mesmo
/// </summary>
/// <param name="primaryType"> O tipo principal do Pokemon </param>
/// <param name="secondaryType?"> O tipo secundário do Pokemon</param>
public class Typing (Types primaryType, Types? secondaryType = null)
{
    /// <summary>
    /// O tipo principal do Pokemon
    /// </summary>
    public Types PrimaryType {get => field; private set => field = primaryType;}
    /// <summary>
    /// O tipo secundário do Pokemon
    /// 
    /// Ele está descrito como "posssivelmente nulo" para no 
    /// caso de que um Pokemon com apenas um tipo seja criado
    /// 
    /// Além disso, ele também possui uma chamada ao método
    /// privado CheckTypeValidity para garantir que ambos
    /// os tipos são diferentes
    /// </summary>
    public Types? SecondaryType {get => field; private set
        {
            field = secondaryType;
            CheckTypeValidity();
        }
    }

    /// <summary>
    /// Uma sobrecarga no método ToSttring() derivado da classe Object
    /// </summary>
    /// <returns>
    /// Um de dois casos será impresso
    /// 
    /// 1. Apenas o tipo primário do Pokemon se for monotipo
    /// Ex.: Fogo
    /// 
    /// ou
    /// 
    /// 2. Ambos os tipos primário e secundário do Pokemon
    /// Ex.: Água/Terra
    /// 
    /// A impressão será definida pro um if ternário que verifica
    /// se o campo SecondaryType contém valor nulo. Se sim, o caso
    /// 1 será o impresso, caso o contrário o impresso será o caso 2
    /// 
    /// Ps.: Os tipos terão sua nomenclatura em inglês, ex.:
    /// Fogo, Água e Grama serão exibidos como Fire, Water e Grass respectivamente
    /// </returns>
    public override string ToString()
    {
        // O if ternário que decide qual será a impressão de ToString()
        return SecondaryType == null ? $"{PrimaryType}" : $"{PrimaryType}/{SecondaryType}" ;
    }

    /// <summary>
    /// Método privado que chama a exceção customizada InvalidTypingException
    /// </summary>
    /// <exception cref="InvalidTypingException">
    /// Se ambos PrimaryType e SecondaryType forem iguais, a exceção é disparada
    /// </exception>
    private void CheckTypeValidity()
    {
        // Em C#, se coisas como um if/else, um for,
        // um while entre outros dentro de um método
        // tiver apenas uma instrução única, é possível
        // escrever o bloco de instruções sem depender 
        // de "{}", se possível faz até na mesma linha.
        // Ex.:

        // if (PrimaryType == SecondaryType) throw new InvalidTypingException;

        // Não sei por que isso é possível, mas minha hipótese é que
        // nesses casos específicos de uma única instrução no if, apenas
        // o ";" é necessário, visto que ele automaticamente separa o if de
        // outros blocos de instrução. O problema começa quando é mais de uma
        // instrução, pois o ";" da primeira instrução pode interferir no 
        // reconhecimento das instruções seguintes do bloco de if
        if (PrimaryType == SecondaryType)
            throw new InvalidTypingException();
    }
}