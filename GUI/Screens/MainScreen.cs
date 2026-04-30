// chamada da biblioteca Raylib
using Raylib_cs;

/// <summary>
/// A classe da tela principal do programa
/// </summary>
public class MainScreen(ScreenManager screenManager, int screenWidth, int screenHeight) : Screen(screenManager, screenWidth, screenHeight)
{
    /// <summary>
    /// variável de controle das operações da tela
    /// </summary>
    private int selected = 0;
    /// <summary>
    /// constante de controle que delimita as operações da tela
    /// </summary>
    private const int UPPER_LIMIT = 4;
    /// <summary>
    /// constante de controle que delimita as operações da tela
    /// </summary>
    private const int LOWER_LIMIT = 0;
    /// <summary>
    /// Inicialização da classe Process
    /// </summary>
    private Process process = new();

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Up) || Raylib.IsKeyPressed(KeyboardKey.W))
        {
            selected--;
            selected = selected >= LOWER_LIMIT ? selected : selected = UPPER_LIMIT;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Down) || Raylib.IsKeyPressed(KeyboardKey.S))
        {
            selected++;
            selected = selected <= UPPER_LIMIT ? selected : LOWER_LIMIT;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            GetAction(selected);
        }
    }

    public override void Draw()
    {
        int x = ScreenWidth / 32;
        int y = ScreenHeight / 2;

        // Fundo branco
        Raylib.ClearBackground(Color.White);

        GetSelection(x, y + (selected * 64));
        GetText(x, y);
    }

    private void GetText(int x, int y)
    {
        x -= 25;

         // Título
        Raylib.DrawText("Pokemon Project", ScreenWidth / 6, ScreenHeight / 40, 100, Color.Black);

        // Menu opções 
        Raylib.DrawText("Show Pokemon", x, y, 50, Color.Black);
        Raylib.DrawText("Your Team", x, y + 64, 50, Color.Black);
        Raylib.DrawText("Your PC", x, y + 64 * 2, 50, Color.Black);
        Raylib.DrawText("Pass Time", x, y + 64 * 3, 50, Color.Black);
        Raylib.DrawText("Exit", x, y + 64 * 4, 50, Color.Black);
    }

    private void GetSelection(int x, int y)
    {
        Raylib.DrawRectangle(x - 64, y, 420, 48, Color.Gray);
    }

    private void GetAction(int selection)
    {
        switch (selection)
        {
            case 0:
                screenManager.DefineScreen(new ListScreen(screenManager, screenWidth, screenHeight));
                break;
            case 1:
                screenManager.DefineScreen(new TeamScreen(screenManager, screenWidth, screenHeight));
                break;
            case 2: 
                screenManager.DefineScreen(new PcScreen(screenManager, screenWidth, screenHeight));
                break;
            case 3:
                screenManager.PokemonManager.TimePassing();
                break;
            default:
                Raylib.CloseWindow();
                break;
        }
    }
}