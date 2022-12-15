using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Coordinate
{
    public int x;
    public int y;
    public int z;
    public Coordinate()
    {
        x = 0;
        y = 0;
        z = 0;
    }
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.z = 0;
    }
    public Coordinate(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double CalculateDistance(Coordinate coord)
    {
        return Math.Sqrt((this.x - coord.x) * (this.x - coord.x)  + (this.y - coord.y) * (this.y - coord.y) + (this.z - coord.z) * (this.z - coord.z));
    }
}
