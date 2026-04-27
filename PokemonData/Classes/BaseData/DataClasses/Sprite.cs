using Raylib_cs;
using static Raylib_cs.Raylib;

/// <summary>
/// Esta classe tem como função armazenar dados do sprite
/// do Pokemon, para futuramente ser utilizado na parte
/// gráfica do programa
/// </summary>
/// <param name="spriteLocation"> O caminho para o sprite</param>
public class Sprite(string? spriteLocation = null)
{
    /// <summary>
    /// Campo com getter e setter do sprite do Pokemon feito
    /// com a criação de uma string com a localização relativa
    /// do sprite do Pokemon
    /// </summary>
    public string? SpriteLocation { get => field; private set => field = spriteLocation; }
    
    /// <summary>
    /// Metodo que retorna o Sprite do Pokemon
    /// 
    /// Não consigo dizer os passos exatos que LoadTexture faz, mas arrisco dizer
    /// que chamar ele aqui continua fazendo o método ter complexidade O(1), talvez 
    /// O(log n) se forçar a barra
    /// </summary>
    /// <returns>
    /// Um objeto do tipo Texture2D que carrega a textura do Pokemon
    /// a partir do método LoadTexture que, por sua vez, recebe 
    /// SpriteLocation como parâmetro
    /// </returns>
    public Texture2D GetSprite()
    {
        return LoadTexture(SpriteLocation);
    }
}