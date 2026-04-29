using Raylib_cs;

public class GameTest
{
    private const int WIDTH = 1280;
    private const int HEIGHT = 720;
    private const string TITLE = "Pokemon Monitoring Project";
    private const int TARGET_FPS = 60;

    public void Run()
    {
        Raylib.InitWindow(WIDTH, HEIGHT, TITLE);
        Raylib.SetTargetFPS(TARGET_FPS);

        ScreenManager screenManager = new();
        screenManager.PokemonManager.GeneratePokemon();
        screenManager.DefineScreen(new TeamScreen(screenManager, WIDTH, HEIGHT));

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