using Raylib_cs;

public class TeamScreen(ScreenManager screenManager, int screenWidth, int screenHeight) : Screen(screenManager, screenWidth, screenHeight)
{
    private int selected = 0;
    private int UpperLimit => screenManager.PokemonManager.Team.GetQuantity();
    private readonly int lowerLimit = 0;
    private readonly Process process = new();
    private Pokemon[] Team => screenManager.PokemonManager.Team.ListPokemon();

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

    private void ShowTeam()
    {
        int x = ScreenWidth / 32;
        int y = ScreenHeight/ 15;
        

        for (int i = 0; i < UpperLimit; i++)
        {
            Raylib.DrawText($"{i+1}. {Team[i].Species}", x, y + (i * 100), 64, Color.Black);
        }
    }

    private void GetSelection()
    {
        int x = 0;
        int y = (int)(ScreenHeight * 0.05);
        Raylib.DrawRectangle(x, y + (Math.Abs(selected) * 100), 480, 86, Color.Green);
    }

    private void DrawPokeSprite()
    {
        int spriteX = (int)(ScreenWidth * 0.4);
        int spriteY = (int)(ScreenHeight * 0.1);

        Raylib.DrawTexture(Team[selected].Sprite.GetSprite(), spriteX, spriteY, Color.White);
    }

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

    private void Actions()
    {
        int x = (int)(ScreenWidth * 0.4);
        int y = (int)(ScreenHeight * 0.5);
        var manager = screenManager.PokemonManager;

        if (Raylib.IsKeyPressed(KeyboardKey.One))
        {
            process.OrderAll(manager.Team);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Two))
        {
            Team[selected].LevelUp();
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Three))
        {
            // process.Evolve(manager.Team, selected);
            manager.Team.UpdatePokemon(selected);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.Four))
        {
            if (manager.Team.GetQuantity() > 1)
            {
                manager.Deposit(selected);
                if (selected >= UpperLimit && selected > lowerLimit)
                {
                    selected--;
                }
            }
        }
        if (Raylib.IsKeyDown(KeyboardKey.Five))
        {
            for (int i = 0; i < UpperLimit; i++)
                process.MinMax(manager.Team, i);
        }
    }
}