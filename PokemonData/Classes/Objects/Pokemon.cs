/// <summary>
/// A classe do objeto do Pokemon propriamente dito
/// </summary>
public class Pokemon(int id, int level, int friendship, PokemonSpecies species)
{
    // Campos que recebem diretamante dados do construtor
    
    /// <summary>
    /// "CPF" do Pokemon inicializado como um int
    /// </summary>
    public int Id {get; private set;} = id;
    /// <summary>
    /// Nível do Pokemon, ele só pode ser inicializado
    /// como um int entre 1 e 100
    /// </summary>
    public int Level {get; private set;} = level;
    /// <summary>
    /// Amizade do Pokemon com o treinador, ela só pode
    /// ser inicializada como um int entre 0 e 255
    /// </summary>
    public int Friendship {get; private set;} = friendship;
    /// <summary>
    /// Espécie do Pokemon inicializada como objeto da 
    /// classe PokemonSpecies
    /// </summary>
    public PokemonSpecies Species {get; private set;} = species;

    /// <summary>
    /// Instanciação do objeto do tipo GetTyping
    /// </summary>
    private static GetTyping getTyping = new();
    /// <summary>
    /// Instanciação do objeto do tipo GetBaseStats
    /// </summary>
    private static GetBaseStats getBaseStats = new();
    /// <summary>
    /// Instanciação do objeto do tipo GetEvolution
    /// </summary>
    private static GetEvolution getEvolution = new();
    /// <summary>
    /// Instanciação do objeto do tipo GetSprite
    /// </summary>
    private static GetSprite getSprite = new();

    // variáveis estáticas precisam ser criadas antes de 
    // serem implementadas

    // Campos derivados de Species

    /// <summary>
    /// Inicialização do campo com a tipagem do Pokemon
    /// 
    /// Um objeto do tipo GetTyping é utilizado para que o método
    /// GetData() seja usado recebendo Species como parãmetro
    /// </summary>
    public  Typing Typing {get; private set;} = getTyping.GetData(species);
    /// <summary>
    /// Inicialização do campo com os pontos base do Pokemon
    /// 
    /// Um objeto dom tipo GetBaseStats é utilizado para que o
    /// método GetData() seja usado recebendo Species como parâmetro 
    /// </summary>
    public BaseStats BaseStats {get; private set;} = getBaseStats.GetData(species);
    /// <summary>
    /// Inicialização do campo com a linha evolutiva do Pokemon
    /// 
    /// Um objeto do tipo GetEvolution é utilizado para que o
    /// método GetData() seja usaado recebendo Species como parâmetro 
    /// </summary>
    public Evolution Evolution {get; private set;} = getEvolution.GetData(species);
    /// <summary>
    /// Inicialização do campo com o sprite do Pokemon
    /// 
    /// Um objeto do tipo GetSprite é utilizado para que o método
    /// GetData() seja usado recebendo Species como parâmetro
    /// </summary>
    public Sprite Sprite {get; private set;} = getSprite.GetData(species);

    
    

    // Métodos Públicos
    
    /// <summary>
    /// Método público que incrementa em +1 o nível
    /// atual do Pokemon respeitando o limite entre 
    /// 1 a até 100
    /// 
    /// Complexidade O(1) por ser basicamente um
    /// Level++ gourmet
    /// </summary>
    public void LevelUp()
    {
        Level = Clamp(Level + 1, 1, 100);
    }

    /// <summary>
    /// Método público que incrementa em +1 os 
    /// pontos de amizade atuais do Pokemon
    /// respeitando o limite entre 0 e 255
    /// 
    /// Complexidade O(1) por ser basicamente um
    /// Friendship++ gourmet
    /// </summary>
    public void FriendshipUp()
    {
        Friendship = Clamp(Friendship + 1, 0, 255);
    }

    /// <summary>
    /// Método público que decrementa em -1 os
    /// pontos de amizade atuais do Pokemon
    /// respeitando o limite entre 0 e 255
    /// 
    /// Complexidade O(1) por ser basicamente um
    /// Friendship-- gourmet
    /// </summary>
    public void FriendshipDown()
    {
        Friendship = Clamp(Friendship - 1, 0, 255);
    }

    // Método Privado

    /// <summary>
    /// Método privado feito para retornar um valor entre um
    /// determinado intervalo
    /// 
    /// Complexidade O(1) por terem poucos passos necessários para sua
    /// execução
    /// </summary>
    private static int Clamp (int value, int min, int max)
    {
        // Condicional que muda o valor de value caso seja menor
        // que min
        if (value < min)
            value = min;
        
        // Condicional que muda o valor de value caso seja maior
        // que max
        if (value > max)
            value = max;
        
        // A instrução de retorno do método
        return value;
    }
}