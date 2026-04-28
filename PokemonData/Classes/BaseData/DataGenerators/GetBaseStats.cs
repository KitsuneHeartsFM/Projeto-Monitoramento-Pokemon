/// <summary>
/// Classe com métodos para coletar os 
/// pontos base das espécies Pokemon registradas
/// no Programa
/// </summary>
public class GetBaseStats : IGenerate<BaseStats>
{
    /// <summary>
    /// Método que retorna os pontos base da espécie
    /// Pokemon inserida
    /// 
    /// Complexidade O(1) pois faz apenas uma checagem
    /// antes de executar sua função primária
    /// </summary>
    /// <param name="species"> A espécie Pokemon registrada</param>
    /// <returns>
    /// Os pontos base da espécie Pokemon registrada
    /// 
    /// O programa utiliza de um switch case para fazer
    /// os retornos
    /// </returns>
    /// <exception cref="NonExistentPokemon">
    /// Esta é uma trava de segurança do método
    /// 
    /// Caso um valor inválido (Ex: Pokemon da Gen 4 sendo que o 
    /// programa se limita a apenas Pokemons da Gen 3), a exceção
    /// customizada NonExistentPokemon é disparada para fins de 
    /// evitar complicações futuras
    /// </exception>
    public BaseStats GetData(Pokemon species)
    {
        // Uma diretiva return misturada com switch case
        // Até onde estou ciente, só no C# isso é possível,
        // Possivelmente no Kotlin também, vist que muita
        // coisa que aparece em Kotlin veio antes em C#
        return species switch
        {
            // Retorno dos pontos base do Treecko
            Pokemon.Treecko => new BaseStats(40, 45, 35, 65, 55, 70),
            // Retorno dos pontos base do Grovyle
            Pokemon.Grovyle => new BaseStats(50, 65, 45, 85, 65, 95),
            // Retorno dos pontos base do Sceptile
            Pokemon.Sceptile => new BaseStats(70, 85, 65, 105, 85, 120),
            // Retorno dos pontos base do Torchic
            Pokemon.Torchic => new BaseStats(45, 60, 40, 70, 50, 45),
            // Retorno dos pontos base do Combusken
            Pokemon.Combusken => new BaseStats(60, 85, 60, 85, 60, 55),
            // Retorno dos pontos base do Blaziken
            Pokemon.Blaziken => new BaseStats(80, 120, 70, 110, 70, 80),
            // Retorno dos pontos base do Mudkip
            Pokemon.Mudkip  => new BaseStats(50, 70 , 50, 50, 50, 40),
            // Retorno dos pontos base do Marshtomp
            Pokemon.Marshtomp => new BaseStats(70, 85, 70, 60, 70, 50),
            // Retorno dos pontos base do Swampert
            Pokemon.Swampert => new BaseStats(100, 110, 90, 85, 90, 60),
            // Retorno dos pontos base do Poochyena
            Pokemon.Poochyena => new BaseStats(35, 55, 35, 30, 30, 35),
            // Retorno dos pontos base do Mightyena
            Pokemon.Mightyena => new BaseStats(70, 90, 70, 60, 60, 70),
            // Retorno dos pontos base do Zigzagoon
            Pokemon.Zigzagoon => new BaseStats(38, 30, 41, 30, 41, 60),
            // Retorno dos pontos base do Linoone
            Pokemon.Linoone => new BaseStats(78, 70, 61, 50, 61, 100),
            // Retorno dos pontos base do Taillow
            Pokemon.Taillow => new BaseStats(40, 55, 30, 30, 30, 85),
            // Retorno dos pontos base do Sweallow
            Pokemon.Sweallow => new BaseStats(60, 85, 60, 50, 50, 125),
            // Retorno dos pontos base da Ralts
            Pokemon.Ralts => new BaseStats(28, 25, 25, 45, 35, 40),
            // Retorno dos pontos base da Kirlia
            Pokemon.Kirlia => new BaseStats(38, 35, 35, 65, 55, 50),
            // Retorno dos pontos base da Gardevoir
            Pokemon.Gardevoir => new BaseStats(68, 65, 65, 125, 115, 80),
            // Retorno dos pontos base do Aron
            Pokemon.Aron => new BaseStats(50, 70, 100, 40, 40, 30),
            // Retorno dos pontos base do Lairon
            Pokemon.Lairon => new BaseStats(60, 90, 140, 50, 50, 40),
            // Retorno dos pontos base do Aggron
            Pokemon.Aggron => new BaseStats(70, 110, 180, 60, 60, 50),
            // Trava de segurança para caso um valor inválido seja inserido
            _ => throw new NonExistentPokemon()
        };
    }

    /// <summary>
    /// Uma variação do método anterior que retorna os
    /// pontos base do Pokemon já em forma de Array
    /// 
    /// No caso, ele chama o método GetData() e usa
    /// a propriedade ToArray() da classe BaseStats
    /// 
    /// Complexidade O(1) por não adicionar passos o suficiente
    /// para impactar negativamente o tempo de execução de forma
    /// significativa
    /// </summary>
    /// <param name="species">A espécie Pokemon registrada</param>
    /// <returns>
    /// Um Array de inteiros com os 6 itens da propriedade ToArray
    /// da classe BaseStats
    /// </returns>
    public int[] GetDataArray(Pokemon species)
    {
        // Acho que isso não precisa de explicação do que faz né?
        return GetData(species).ToArray();
    }
}