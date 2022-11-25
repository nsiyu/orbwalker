using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class Orbwalker
{
    double baseattackspeed = 0.679;
    double attackspeed = 0.679;
    double champWindupPercent = 14.801;
    static int DELAY = 20;

    Mouse clicker;
    ReadMemory reader;
    double nextAATick;
    bool targetChampionsOnly = false;
    int slider = 80;



    public Orbwalker(ReadMemory reader, Mouse clicker)
    {
        this.reader = reader;
        this.clicker = clicker;
        this.nextAATick = Environment.TickCount;
    }

    public double GetAttackWindup()
    {
        return (1.0 / this.attackspeed * this.champWindupPercent);
    }

    public double GetCurrentAttackSpeed()
    {
        return this.reader.getAttackSpeed() * this.baseattackspeed;
    }

    public bool CanAttack()
    {
        return nextAATick < Environment.TickCount;
    }

    public bool CanAttackChampion()
    {
        return nextAATick - 50 < Environment.TickCount;
    }

    public bool holdingSpaceBar()
    {
        return Keyboard.IsKeyPressed(Keys.Space);
    }

    public bool holdingV()
    {
        return Keyboard.IsKeyPressed(Keys.V);
    }

    public List<Coordinate> GetChampionsOnScreen()
    {
        Render render = new Render();
        return render.PixelSearch();
    }

    public Coordinate FindClosestChampion()
    {
        List<Coordinate> champions = GetChampionsOnScreen();

        int currentX = Screen.PrimaryScreen.Bounds.Width / 2;
        int currentY = Screen.PrimaryScreen.Bounds.Height / 2;
        Coordinate currentLocation = new Coordinate(currentX, currentY);

        int nearestChampionIndex = -1;
        double nearestChampionDistance = double.PositiveInfinity;

        for (int i = 0; i < champions.Count; ++i)
        {
            double championDistance = currentLocation.CalculateDistance(champions[i]);
            if (championDistance < nearestChampionDistance)
            {
                nearestChampionIndex = i;
                nearestChampionDistance = championDistance;
            }
        }
        if (nearestChampionIndex == -1)
            return null;
        else
            return champions[nearestChampionIndex];
    }
    public void AttackNearestChampion()
    {
        Coordinate nearestChampion = this.FindClosestChampion();
        if (nearestChampion != null)
        {
            this.attackspeed = this.GetCurrentAttackSpeed();
            clicker.LeftClick((uint)nearestChampion.x + 80, (uint)nearestChampion.y + 135);
            double AttackWindup = GetAttackWindup();
            Thread.Sleep((int)(AttackWindup * 10) + slider - 10);
            this.attackspeed = this.GetCurrentAttackSpeed();
            clicker.RightClick();
            Thread.Sleep(100);
            this.attackspeed = this.GetCurrentAttackSpeed();
            nextAATick = Environment.TickCount + (int)(1000f / this.attackspeed) - ((AttackWindup * 10) + slider - 10);
        }
        else
        {
            clicker.RightClick();
        }
    }

    public void AttackNearestEntity()
    {
        if (this.CanAttack())
        {
            Keyboard.v_Click();
            this.attackspeed = this.GetCurrentAttackSpeed();
            nextAATick = Environment.TickCount + (int)(1000f / attackspeed);
            Thread.Sleep((int)(GetAttackWindup() * 10) + slider + 55);
        }
        else
        {
            clicker.RightClick();
            Thread.Sleep(DELAY);
        }
    }

    public void Orbwalk()
    {
        if (!targetChampionsOnly)
        {
            Keyboard.targetChampionsKeyDown();
            targetChampionsOnly = true;
        }

        if (this.CanAttackChampion())
        {
            this.AttackNearestChampion();
        }
        else
        {
            clicker.RightClick();
            Thread.Sleep(DELAY);
        }
    }

    public void run()
    {
        while (true)
        {
            if (this.holdingSpaceBar())
            {
                this.Orbwalk();
            }
            else if (this.holdingV())
            {
                this.AttackNearestEntity();
            }
            else
            {
                if (targetChampionsOnly && !this.holdingSpaceBar())
                {
                    Keyboard.targetChampionsKeyUp();
                    targetChampionsOnly = false;
                }
            }
        }
    }

    public void test()
    {
        clicker.HoverCenter();
    }
}
