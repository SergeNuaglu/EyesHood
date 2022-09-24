using UnityEngine;
using IJunior.TypedScenes;

public class GameLoader : MonoBehaviour
{
   public void EnterCave()
    {
        Cave.Load();
    }

    public void EnterDungeon()
    {
        Dungeon.Load();
    }
}
