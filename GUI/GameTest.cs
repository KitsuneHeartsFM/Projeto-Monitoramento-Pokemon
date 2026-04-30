// Chamada da biblioteca Raylib
using Raylib_cs;

/// <summary>
/// A classe principal que dá acesso à GUI do programa
/// </summary>
public class GameTest
{
    /// <summary>
    /// Largura da janela
    /// </summary>
    private const int WIDTH = 1280;
    /// <summary>
    /// Altura da janela
    /// </summary>
    private const int HEIGHT = 720;
    /// <summary>
    /// Título da janela
    /// </summary>
    private const string TITLE = "Pokemon Monitoring Project";
    /// <summary>
    /// O FPS atual do programa
    /// </summary>
    private const int TARGET_FPS = 60;

    /// <summary>
    /// Método para rodar o projeto
    /// 
    /// Considerando outras classes, a complexidade pode chegar a até
    /// O(n²) ou mais se bobear
    /// </summary>
    public void Run()
    {
        Raylib.InitWindow(WIDTH, HEIGHT, TITLE);
        Raylib.SetTargetFPS(TARGET_FPS);

        ScreenManager screenManager = new();
        screenManager.PokemonManager.GeneratePokemon();
        screenManager.DefineScreen(new MainScreen(screenManager, WIDTH, HEIGHT));

        while (!Raylib.WindowShouldClose())
        {
            screenManager.Update();

            Raylib.BeginDrawing();
            screenManager.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}