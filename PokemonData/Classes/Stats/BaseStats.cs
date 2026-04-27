public class BaseStats(int hp, int atk, int def, int spa, int spd, int spe)
{
    public int Hp{get => field; private set => field = hp;}
    public int Atk{get => field; private set => field = atk;}
    public int Def{get => field; private set => field = def;}
    public int Spa{get => field; private set => field = spa;}
    public int Spd{get => field; private set => field = spd;}
    public int Spe{get => field; private set => field = spe;}
}