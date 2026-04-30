// chamada da biblioteca Raylib
using Raylib_cs;

/// <summary>
/// A classe da tela com o time do usuário
/// </summary>
public class TeamScreen(ScreenManager screenManager, int screenWidth, int screenHeight) : Screen(screenManager, screenWidth, screenHeight)
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
    private int UpperLimit => screenManager.PokemonManager.Team.GetQuantity();
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
    private Pokemon[] Team => screenManager.PokemonManager.Team.ListPokemon();

    /// <summary>
    /// Método que está o tempo todo sendo atualizado para registrar as ações 
    /// do usuário
    /// </summary>
    public override void Update()
    {
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

        Actions();

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
        ShowTeam();
        DrawPokeSprite();
        ShowOptions();

        Raylib.DrawText($"Backscape - Exit", x, y + 465, 40, Color.Red);
    }

    /// <summary>
    /// Método para escrever texto com a lista de Pokemons registrados
    /// </summary>
    private void ShowTeam()
    {
        int x = ScreenWidth / 32;
        int y = ScreenHeight/ 15;
        

        for (int i = 0; i < UpperLimit; i++)
        {
            Raylib.DrawText($"{i+1}. {Team[i].Species}", x, y + (i * 100), 64, Color.Black);
        }
    }

    /// <summary>
    /// Método para desenhar o bichinho colorido que mostra qual Pokemon
    /// foi selecionado
    /// </summary>
    private void GetSelection()
    {
        int x = 0;
        int y = (int)(ScreenHeight * 0.05);
        Raylib.DrawRectangle(x, y + (Math.Abs(selected) * 100), 480, 86, Color.Green);
    }

    /// <summary>
    /// Método para desenhar a imagem do Pokemon selecionado
    /// </summary>
    private void DrawPokeSprite()
    {
        int spriteX = (int)(ScreenWidth * 0.4);
        int spriteY = (int)(ScreenHeight * 0.1);

        Raylib.DrawTexture(Team[selected].Sprite.GetSprite(), spriteX, spriteY, Color.White);
    }

    /// <summary>
    /// Método para desenhar as operações que se podem fazer utilizando
    /// os números de 1 a 5
    /// </summary>
    private void ShowOptions()
    {
        int x = (int)(ScreenWidth * 0.4);
        int y = (int)(ScreenHeight * 0.5);

        Raylib.DrawText("1 - Reorder by Level", x, y, 50, Color.Green);
        Raylib.DrawText("2 - Level Up Selected", x, y + 65, 50, Color.Green);
        Raylib.DrawText("3 - Evolve Selected", x, y + 130, 50, Color.Green);
        Raylib.DrawText("4 - Deposit at PC", x, y + 195, 50, Color.Green);
        Raylib.DrawText("5 - Minmax Team", x, y + 260, 50, Color.Green);
    }

    /// <summary>
    /// Método para registrar a entrada dos números de 1 a 5 e fazer
    /// o que está descrito no menu
    /// 
    /// Por causa dessa ultima operação, a complexidade dessa classe pode
    /// ir lá pra O(n²) ou O(n³)
    /// </summary>
    private void Actions()
    {
        int x = (int)(ScreenWidth * 0.4);
        int y = (int)(ScreenHeight * 0.5);
        var manager = screenManager.PokemonManager;

        // Ordena o time apertando 1
        if (Raylib.IsKeyPressed(KeyboardKey.One))
        {
            process.OrderAll(manager.Team);
        }
        // Aumenta o nível do Pokemon escolhido apertando 2
        if (Raylib.IsKeyPressed(KeyboardKey.Two))
        {
            Team[selected].LevelUp();
        }
        // Evolui o Pokemon escolhido apertando 3 
        if (Raylib.IsKeyPressed(KeyboardKey.Three))
        {
            manager.Team.UpdatePokemon(selected);
        }
        // Manda o Pokemon pro PC apertando 4
        if (Raylib.IsKeyPressed(KeyboardKey.Four))
        {
            // Checagem para ver se tem mais de 1 Pokemon no time
            // Se tiver só 1 a operação falha
            if (manager.Team.GetQuantity() > 1)
            {
                // Evolução do Pokemon escolhido
                manager.Deposit(selected);
                if (selected >= UpperLimit && selected > lowerLimit)
                {
                    selected--;
                }
            }
        }
        // Faz Minmaxxing no time apertando 5
        if (Raylib.IsKeyDown(KeyboardKey.Five))
        {
            for (int i = 0; i < UpperLimit; i++)
                process.MinMax(manager.Team, i);
        }
    }
}