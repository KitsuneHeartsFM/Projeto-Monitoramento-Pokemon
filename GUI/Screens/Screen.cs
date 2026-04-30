/// <summary>
/// A classe pai das telas a serem usadas
/// 
/// Todas elas terão o gerenciador de telas como parâmetro pois
/// dentro das telas podem haver operações de mudança de tela
/// </summary>
public abstract class Screen (ScreenManager screenManager, int screenWidth, int screenHeight)
{
    /// <summary>
    /// Inicialização do gerenciador de tela
    /// </summary>
    protected ScreenManager screenManager = screenManager;
    /// <summary>
    /// Instância da largura da janela
    /// </summary>
    protected int ScreenWidth = screenWidth;
    /// <summary>
    /// Instância da altura da janela
    /// </summary>
    protected int ScreenHeight = screenHeight;

    /// <summary>
    /// Método que registra os inputs do usuário
    /// </summary>
    public abstract void Update();
    /// <summary>
    /// Método que desenha coisa na tela
    /// </summary>
    public abstract void Draw();
}