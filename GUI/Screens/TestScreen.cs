using Raylib_cs;

public class TestScreen(ScreenManager screenManager, int screenWidth = 1280, int screenHeight = 720) : Screen(screenManager, screenWidth, screenHeight)
{
    public override void Update()
    {
        
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("Projeto Pokemon", ScreenWidth / 6, ScreenHeight / 40, 100, Color.Black);
    }
}