using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Hero
{
    private const double PIXELS_PER_UNIT_LEAGUE = 480.0 / 525;
    private const int SCREEN_WIDTH = 2560;
    private const int SCREEN_HEIGHT = 1440;
    private const int center_x = (SCREEN_WIDTH / 2);
    private const int center_y = (SCREEN_HEIGHT / 2);
    private static Coordinate center = new Coordinate(center_x, center_y);

    private float attackrange;
    

    public Hero(float attackrange)
    {
        this.attackrange = attackrange;
    }
    public Hero()
    {
        this.attackrange = ActivePlayerData.ChampionStats.GetAttackRange();
    }

    public void refreshAttackRange()
    {
        this.attackrange = ActivePlayerData.ChampionStats.GetAttackRange();
    }
    public bool PointInRange(Coordinate x)
    {
        refreshAttackRange();
        double distance = center.CalculateDistance(x);
        if (distance < attackrange)
            return true;
        return false;
    }
}
