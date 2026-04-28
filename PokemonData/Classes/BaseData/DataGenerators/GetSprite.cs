/// <summary>
/// Classe irmã de Get BaseStats que implementa a interface
/// IGenerate para gerar os dados dos sprites de Pokemons
/// de forma individual
/// </summary>
public class GetSprite : IGenerate<Sprite>
{
    /// <summary>
    /// Método que retorna os sprites dos pokemons
    /// 
    /// Complexidade O(1) por ser apenas uma checagem,
    /// fazendo assim o tempo de execução ser sempre
    /// constante
    /// </summary>
    /// <param name="species"> A espécie do Pokemon a ser inserida </param>
    /// <returns>
    /// Se tudo ocorrer bem, o método irá retornar um objeto
    /// do tipo Sprite que recebe como parâmetro a localização
    /// relativa do sprite do Pokemon
    /// </returns>
    /// <exception cref="NonExistentPokemon">
    /// Caso ocorra de inserir um Pokemon indisponível,
    /// esta exceção será disparada
    /// </exception>
    public Sprite GetData(Pokemon species)
    {
        return species switch
        {
            // Sprite do Treecko
            Pokemon.Treecko => new("Img/1. Treecko.png"),
            // Sprite do Grovyle
            Pokemon.Grovyle => new("Img/2. Grovyle.png"),
            // Sprite do Sceptile
            Pokemon.Sceptile => new("Img/3. Sceptile.png"),
            // Sprite do Torchic
            Pokemon.Torchic => new("Img/4. Torchic.png"),
            // Sprite do Combusken
            Pokemon.Combusken => new("Img/5. Combusken.png"),
            // Sprite do Blaziken
            Pokemon.Blaziken => new("Img/6. Blaziken.png"),
            // Sprite do Mudkip
            Pokemon.Mudkip => new("Img/7. Mudkip.png"),
            // Sprite do Marshtomp
            Pokemon.Marshtomp => new("Img/8. Marshtomp.png"),
            // Sprite do Swampert
            Pokemon.Swampert => new("Img/9. Swampert.png"),
            // Sprite do Poochyena
            Pokemon.Poochyena => new("Img/10. Poochyena.png"),
            // Sprite do Mightyena
            Pokemon.Mightyena => new("Img/11. Mightyena.png"),
            // Sprite do Zigzagoon
            Pokemon.Zigzagoon => new("Img/12. Zigzagoon.png"),
            // Sprite do Linoone
            Pokemon.Linoone => new("Img/13. Linoone.png"),
            // Sprite do Taillow
            Pokemon.Taillow => new("Img/14. Taillow.png"),
            // Sprite do Sweallow
            Pokemon.Sweallow => new("Img/15. Sweallow.png"),
            // Sprite da Ralts
            Pokemon.Ralts => new("Img/16. Ralts.png"),
            // Sprite da Kirlia
            Pokemon.Kirlia => new("Img/17. Kirlia.png"),
            // Sprite da Gardevoir
            Pokemon.Gardevoir => new("Img/18. Gardevoir.png"),
            // Sprite do Aron
            Pokemon.Aron => new("Img/19. Aron.png"),
            // Sprite do Lairon
            Pokemon.Lairon => new("Img/20. Lairon.png"),
            // Sprite do Aggron
            Pokemon.Aggron => new("Img/21. Aggron.png"),
            
            _ => throw new NonExistentPokemon()
        };
    }
}