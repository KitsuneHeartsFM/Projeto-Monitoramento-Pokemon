public abstract class Screen (ScreenManager screenManager, int screenWidth, int screenHeight)
{
    protected ScreenManager screenManager = screenManager;
    protected int ScreenWidth = screenWidth;
    protected int ScreenHeight = screenHeight;

    public abstract void Update();
    public abstract void Draw();
}