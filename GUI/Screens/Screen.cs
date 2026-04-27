public abstract class Screen (ScreenManager screenManager)
{
    protected ScreenManager screenManager = screenManager;

    public abstract void Update();
    public abstract void Draw();
}