using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Weapons Index", order = 51)]

public class WeaponsIndex : ScriptableObject
{
    private int _unarmIndex = 0;
    private int _swordIndex = 1;
    private int _spearIndex = 2;
    private int _bowIndex = 3;

    public int SwordIndex => _swordIndex;
    public int SpearIndex => _spearIndex;
    public int BowIndex => _bowIndex;

    public int GetIndex(Weapon weapon)
    {
        if (weapon.TryGetComponent<Sword>(out Sword sword))
            return _swordIndex;
        else if (weapon.TryGetComponent<Spear>(out Spear spear))
            return _spearIndex;
        else if (weapon.TryGetComponent<Bow>(out Bow bow))
            return _bowIndex;

        return _unarmIndex;
    }

}