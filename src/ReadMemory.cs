using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class ReadMemory
{
    int localPlayerOffset = 0x30F9BDC;
    int attackSpeedOffset = 0x1280;

    IntPtr mBase;
    VAMemory vam;
    public ReadMemory()
    {
        vam = new VAMemory("League of Legends");
        mBase = Process.GetProcessesByName("League Of Legends").FirstOrDefault().MainModule.BaseAddress;
    }
    public float getAttackSpeed()
    {
        IntPtr localPlayerData = IntPtr.Add(mBase, localPlayerOffset);
        int localPlayerDataDereferencd = vam.ReadInt32(localPlayerData);
        return vam.ReadFloat((IntPtr)(localPlayerDataDereferencd + attackSpeedOffset));
    }

}
