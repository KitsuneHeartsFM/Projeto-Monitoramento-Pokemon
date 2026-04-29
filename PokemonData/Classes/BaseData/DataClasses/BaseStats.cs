/// <summary>
/// Esta classe serve uma função similar aos POJO's do Java,
/// Isto é, uma classe apenas para guardar informações
/// 
/// Em C# há uma propriedade chamada "campos", que explicando
/// de forma simplificada, é como se o programador criasse
/// um get() set() junto da declaração da variável, sem precisar
/// daquele mar de gets e sets de programas feitos em Java
/// 
/// Neste caso, ela armazena os pontos Base de um Pokemon
/// </summary>
/// <param name="hp">Vida</param>
/// <param name="atk">Ataque</param>
/// <param name="def">Defesa</param>
/// <param name="spa">Ataque Especial</param>
/// <param name="spd">Defesa Especial</param>
/// <param name="spe">Velocidade</param>
public class BaseStats(int hp, int atk, int def, int spa, int spd, int spe)
{
    /// <summary>
    /// Health Points - Os pontos de vida do Pokemon
    /// </summary>
    public int Hp{get; private set;} = hp;
    /// <summary>
    /// Attack - O quão forte são os ataques físicos do Pokemon
    /// </summary>
    public int Atk{get; private set;} = atk;
    /// <summary>
    /// Defense - O quão resistente a ataques físicos é o Pokemon
    /// </summary>
    public int Def{get; private set;} = def;
    /// <summary>
    /// Special Attack - O quão forte são os ataques especiais do Pokemon
    /// </summary>
    public int Spa{get; private set;} = spa;
    /// <summary>
    /// Special Defense - O quão resistente a ataques especiais é o Pokemon
    /// </summary>
    public int Spd{get; private set;} = spd;
    /// <summary>
    /// Speed - O quão rápido é o Pokemon
    /// </summary>
    public int Spe{get; private set;} = spe;

    /// <summary>
    /// Método que retorna as informações da classe em forma de Array
    /// 
    /// Complexidade O(1) pois apenas retorna os dados inseridos no
    /// objeto BaseStats
    /// </summary>
    /// <returns>
    /// Array de inteiros de tamanho 6 com os status base do Pokemon
    /// </returns>
    public int[] ToArray()
    {
        // Uma feature curiosa da linguagem C#.
        // não sei dizer se isto é possível em
        // outras linguagens mas isto, além de
        // outras features, mostram que C#
        // meio que realmente é Java com passos
        // extras (Java++)
        return [Hp, Atk, Def, Spa, Spd, Spe];
    }
}