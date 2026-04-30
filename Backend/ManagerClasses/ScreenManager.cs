/// <summary>
/// Classe responsável por gerenciar a troca de telas do projeto
/// </summary>
public class ScreenManager
{
    /// <summary>
    /// A primeira tela a ser criada, geralmente é a
    /// tela de início
    /// </summary>
    private Screen? currentScreen;
    /// <summary>
    /// Inicialização da classe PokemonManager
    /// </summary>
    public PokemonManager PokemonManager {get; private set;} 

    public ScreenManager()
    {
        PokemonManager = new();
    }

    public void DefineScreen(Screen newScreen)
    {
        currentScreen = newScreen;
    }

    public void Update()
    {
        currentScreen?.Update();
    }

    public void Draw()
    {
        currentScreen?.Draw();
    }
}