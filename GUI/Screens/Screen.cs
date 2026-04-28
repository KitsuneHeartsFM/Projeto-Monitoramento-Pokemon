public abstract class Screen (ScreenManager screenManager, int screenWidth = 1280, int screenHeight = 720)
{
    protected ScreenManager screenManager = screenManager;
    protected int ScreenWidth = screenWidth;
    protected int ScreenHeight = screenHeight;

    public abstract void Update();
    public abstract void Draw();
}