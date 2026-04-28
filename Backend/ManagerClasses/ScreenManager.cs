public class ScreenManager
{
    private Screen? currentScreen;
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