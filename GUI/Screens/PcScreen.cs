// chamada da biblioteca Raylib
using Raylib_cs;

public class PcScreen(ScreenManager screenManager, int screenWidth, int screenHeight) : Screen(screenManager, screenWidth, screenHeight)
{   
    /// <summary>
    /// Variável de controle para operações na tela
    /// </summary>
    private int selected = 0;
    /// <summary>
    /// Variável de controle que delimita selected
    /// 
    /// Ela está em arrow function para quando a quantidade de Pokemon no time mudar
    /// 
    /// começou com letra maiúscula por frescura gramática do C#
    /// </summary>
    private int UpperLimit => screenManager.PokemonManager.Pc.GetQuantity();
    /// <summary>
    /// Variável de controle que delimita selected
    /// </summary>
    private readonly int lowerLimit = 0;
    /// <summary>
    /// Inicialização da classe Process com as operações d.1, d.2, d.3 e d.4
    /// </summary>
    private readonly Process process = new();
    /// <summary>
    /// Inicialização do array com os Pokemons no time
    /// 
    /// Ele está como arrow function pois igual UpperLimit os Pokemons no time podem mudar
    /// </summary>
    private Pokemon[] Pc => screenManager.PokemonManager.Pc.ListPokemon();

    /// <summary>
    /// Método que está o tempo todo sendo atualizado para registrar as ações 
    /// do usuário
    /// </summary>
    public override void Update()
    {
        var manager = screenManager.PokemonManager;

        if (Raylib.IsKeyPressed(KeyboardKey.Up) || Raylib.IsKeyPressed(KeyboardKey.W))
        {
            selected--;
            selected = selected >= lowerLimit ? selected : selected = UpperLimit - 1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Down) || Raylib.IsKeyPressed(KeyboardKey.S))
        {
            selected++;
            selected = selected <= UpperLimit - 1 ? selected : lowerLimit;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.One))
        {
            process.OrderAll(screenManager.PokemonManager.Pc);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Two))
        {
            manager.Withdraw(selected);
            if (selected >= UpperLimit && selected > lowerLimit)
            {
                selected--;
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
        {
            screenManager.DefineScreen(new MainScreen(screenManager, screenWidth, screenHeight));
        }
    
    }


    /// <summary>
    /// Método que está o tempo todo sendo atualizado para desenhar coisa
    /// na tela
    /// </summary>
    public override void Draw()
    {
        int x = (int)(ScreenWidth * 0.03);
        int y = (int)(ScreenHeight * 0.25);

        Raylib.ClearBackground(Color.White);

        GetSelection();
        ShowPc();
        DrawPokeSprite();
        ShowOption();
    }

    /// <summary>
    /// Método para listar todos os Pokemons no PC
    /// </summary>
    private void ShowPc()
    {
        int x = ScreenWidth / 32;
        int y = ScreenHeight/ 15;

        for (int i = 0; i < UpperLimit; i++)
        {
            Raylib.DrawText($"{i+1}. {Pc[i].Species}", x, y + (i * 100), 64, Color.Black);
        }

        Raylib.DrawText($"Backscape - Exit", x, y + 465, 40, Color.Red);
    }

    /// <summary>
    /// Método pra desenhar o bichinho colorido de seleção
    /// </summary>
    private void GetSelection()
    {
        int x = 0;
        int y = (int)(ScreenHeight * 0.05);
        Raylib.DrawRectangle(x, y + (Math.Abs(selected) * 100), 480, 86, Color.Blue);
    }

    /// <summary>
    /// Método para desenhar a imagem do Pokemon escolhido
    /// </summary>
    private void DrawPokeSprite()
    {
        int spriteX = (int)(ScreenWidth * 0.4);
        int spriteY = (int)(ScreenHeight * 0.1);

        Raylib.DrawTexture(Pc[selected].Sprite.GetSprite(), spriteX, spriteY, Color.White);
    }

    /// <summary>
    /// Método para mostrar todas as operações disponíveis
    /// </summary>
    private void ShowOption()
    {
        int x = (int)(ScreenWidth * 0.4);
        int y = (int)(ScreenHeight * 0.5);

        Raylib.DrawText("1 - Reorder by Level", x, y, 50, Color.Blue);
        Raylib.DrawText("2 - Withdraw toTeam", x, y + 65, 50, Color.Blue);
    }
}