// chamada da biblioteca Raylib
using Raylib_cs;

/// <summary>
/// A classe com a lista de todos os Pokemons registrados, meio que como se fosse 
/// a Pokedex do programa
/// </summary>
public class ListScreen(ScreenManager screenManager, int screenWidth, int screenHeight) : Screen(screenManager, screenWidth, screenHeight)
{
    /// <summary>
    /// Constante de controle para delimitar as operações na tela
    /// </summary>
    private const int UPPER_LIMIT = 9;
    /// <summary>
    /// Constante de controle para delimitar as operações na tela
    /// </summary>
    private const int LOWER_LIMIT = 0;
    /// <summary>
    /// Inicialização da classe Process
    /// </summary>
    private Process process = new();
    /// <summary>
    /// Variável de controle das operações na tela
    /// </summary>
    private int selected = 0;

    /// <summary>
    /// Método que registra os inputs do usuário
    /// </summary>
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

        if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
        {
            screenManager.DefineScreen(new MainScreen(screenManager, screenWidth, screenHeight));
        }
    }

    /// <summary>
    /// Método que desenha coisa na tela
    /// </summary>
    public override void Draw()
    {
        Raylib.ClearBackground(Color.White);

        GetSelection();
        GetPokeRegistry();
        DrawPokeInfo();
    }

    /// <summary>
    /// Método que mostra todos os Pokemons registrados
    /// 
    /// Complexidade O(m*n) por seu tempo de execução 
    /// depender de quantos Pokemons estão no time (m)
    /// e quantos estão no Pc(n)
    /// </summary>
    private void GetPokeRegistry()
    {
        Raylib.DrawText("All registered Pokemon", ScreenWidth / 24, ScreenHeight / 40, 100, Color.Black);

        int x = (int)(ScreenWidth * 0.03);
        int y = (int)(ScreenHeight * 0.25);
        var output1 = process.ShowAllPokemon(screenManager.PokemonManager.Team);
        var output2 = process.ShowAllPokemon(screenManager.PokemonManager.Pc);
        
        for (int i = 0; i < output1.Length; i++)
        {
            Raylib.DrawText($"{output1[i]}", x, y + (i * 45), 40, Color.Black);
        }
        for (int i = 0; i < output2.Length; i++)
        {
            Raylib.DrawText($"{output2[i]}", x, y + (i+6) * 45, 40, Color.Black);
        }

        Raylib.DrawText($"Backscape - Exit", x, y + 465, 40, Color.Red);
    }

    /// <summary>
    /// Método que desenha o bichinho de seleção de Pokemon
    /// </summary>
    private void GetSelection()
    {
        int x = 0;
        int y = (int)(ScreenHeight * 0.247);
        Raylib.DrawRectangle(x, y + (selected * 45), 320, 48, Color.Red);
    }

    /// <summary>
    /// Método que desenha não apenas a imagem do Pokemon escolhido
    /// como também o textinho com suas informações pessoais
    /// </summary>
    private void DrawPokeInfo()
    {
        int x1 = (int)(ScreenWidth*0.25);
        int y1 = (int)(ScreenHeight*0.25);
        int x2 = (int)(ScreenWidth*0.455);
        int y2 = (int)(ScreenHeight*0.24);

        var output1 = screenManager.PokemonManager.Team;
        var output2 = screenManager.PokemonManager.Pc;
        
        if (selected <= 5)
        {
            var aux = output1.GetPokemon(selected).Sprite.GetSprite();
            var text = process.ShowPokemonInfo(output1, selected);

            Raylib.DrawTexture(aux, x1, y1, Color.White);
            Raylib.DrawText(text, x2, y2, 30, Color.Black);
        }
        if (selected > 5)
        {
            int select = selected-6;

            var aux = output2.GetPokemon(select).Sprite.GetSprite();
            var text = process.ShowPokemonInfo(output2, select);
            
            Raylib.DrawTexture(aux, x1, y1, Color.White);
            Raylib.DrawText(text, x2, y2, 30, Color.Black);
        }
    }
}