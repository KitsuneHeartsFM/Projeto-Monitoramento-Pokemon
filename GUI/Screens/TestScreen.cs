using Raylib_cs;

public class TestScreen(ScreenManager screenManager, int screenWidth = 1280, int screenHeight = 720) : Screen(screenManager, screenWidth, screenHeight)
{
    private static int selected = 0;
    private static bool createdPokemon = false;
    private const int UPPER_LIMIT = 4;
    private const int LOWER_LIMIT = 0;
    private readonly Process process = new();

    public override void Update()
    {
        if (!createdPokemon)
        {
            CreatePokemon();
        }

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
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            GetAction(selected);
        }
    }

    public override void Draw()
    {
        int x = ScreenWidth / 32;
        int y = ScreenHeight / 2;

        // Fundo branco
        Raylib.ClearBackground(Color.White);

        GetSelection(x, y + (selected * 64));
        GetText(x, y);
    }

    private void GetText(int x, int y)
    {
         // Título
        Raylib.DrawText("Pokemon Project", ScreenWidth / 6, ScreenHeight / 40, 100, Color.Black);

        // Menu opções 
        Raylib.DrawText("Show All Pokemon", x, y, 50, Color.Black);
        Raylib.DrawText("Your Team", x, y + 64, 50, Color.Black);
        Raylib.DrawText("Your PC", x, y + 64 * 2, 50, Color.Black);
        Raylib.DrawText("Pass Time", x, y + 64 * 3, 50, Color.Black);
        Raylib.DrawText("Exit", x, y + 64 * 4, 50, Color.Black);
    }

    private void GetSelection(int x, int y)
    {
        Raylib.DrawRectangle(x - 64, y, 360, 48, Color.Red);
    }

    private void GetAction(int selection)
    {
        switch (selection)
        {
            case 0:
                process.ShowAllPokemon(screenManager.PokemonManager.Team);
                process.ShowAllPokemon(screenManager.PokemonManager.Pc);
                break;
            case 1:
                screenManager.DefineScreen(new TestTeam(screenManager));
                break;
            case 2: 
                screenManager.DefineScreen(new TestPc(screenManager));
                break;
            case 3:
                screenManager.PokemonManager.TimePassing();
                break;
            default:
                Raylib.CloseWindow();
                break;
        }
    }

    private void CreatePokemon()
    {
        screenManager.PokemonManager.GeneratePokemon();
        createdPokemon = true;
    }
}