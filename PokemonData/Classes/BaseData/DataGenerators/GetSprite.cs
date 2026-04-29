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
    public Sprite GetData(PokemonSpecies species)
    {
        return species switch
        {
            // Sprite do Treecko
            PokemonSpecies.Treecko => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/1. Treecko.png"),
            // Sprite do Grovyle
            PokemonSpecies.Grovyle => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/2. Grovyle.png"),
            // Sprite do Sceptile
            PokemonSpecies.Sceptile => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/3. Sceptile.png"),
            // Sprite do Torchic
            PokemonSpecies.Torchic => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/4. Torchic.png"),
            // Sprite do Combusken
            PokemonSpecies.Combusken => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/5. Combusken.png"),
            // Sprite do Blaziken
            PokemonSpecies.Blaziken => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/6. Blaziken.png"),
            // Sprite do Mudkip
            PokemonSpecies.Mudkip => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/7. Mudkip.png"),
            // Sprite do Marshtomp
            PokemonSpecies.Marshtomp => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/8. Marshtomp.png"),
            // Sprite do Swampert
            PokemonSpecies.Swampert => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/9. Swampert.png"),
            // Sprite do Poochyena
            PokemonSpecies.Poochyena => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/10. Poochyena.png"),
            // Sprite do Mightyena
            PokemonSpecies.Mightyena => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/11. Mightyena.png"),
            // Sprite do Zigzagoon
            PokemonSpecies.Zigzagoon => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/12. Zigzagoon.png"),
            // Sprite do Linoone
            PokemonSpecies.Linoone => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/13. Linoone.png"),
            // Sprite do Taillow
            PokemonSpecies.Taillow => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/14. Taillow.png"),
            // Sprite do Sweallow
            PokemonSpecies.Sweallow => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/15. Sweallow.png"),
            // Sprite da Ralts
            PokemonSpecies.Ralts => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/16. Ralts.png"),
            // Sprite da Kirlia
            PokemonSpecies.Kirlia => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/17. Kirlia.png"),
            // Sprite da Gardevoir
            PokemonSpecies.Gardevoir => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/18. Gardevoir.png"),
            // Sprite do Aron
            PokemonSpecies.Aron => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/19. Aron.png"),
            // Sprite do Lairon
            PokemonSpecies.Lairon => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/20. Lairon.png"),
            // Sprite do Aggron
            PokemonSpecies.Aggron => new("/home/kitsune/Programação/Faculdade/Projeto-Monitoramento-Pokemon/Img/21. Aggron.png"),
            
            _ => throw new NonExistentPokemon()
        };
    }
}