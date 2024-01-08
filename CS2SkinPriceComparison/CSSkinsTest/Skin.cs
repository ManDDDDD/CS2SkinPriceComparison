using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2SkinPriceComparison;

public class Skin
{
    public string Name { get; set; }
    public WeaponCategory WeaponCategory { get; set; }
    public object SpecificWeapon { get; set; }

}

public enum WeaponCategory
{
    Knife = 1,
    Gloves = 2,
    Pistol = 3,
    Rifle = 4,
    SMG = 5,
    Heavy = 6,
}
public enum RifleType
{
    AK47,
    M4A4,
    M4A1S,
    AUG,
    SG553,
    FAMAS,
    GALIL,
    SSG08,
    AWP,
    G3SG1,
    SCAR20,
}

public enum PistolType
{
    GLOCK,
    USP,
    P2000,
    P250,
    FIVESEVEN,
    TEC9,
    CZ75,
    DESERT_EAGLE,
    REVOLVER,
}

