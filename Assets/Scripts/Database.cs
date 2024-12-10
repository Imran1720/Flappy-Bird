using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Storage/Data")]
public class Database : ScriptableObject
{
    public int Score = 0, MaxScore = 0, ClickCounter = 0;
    public bool IsStarted = false, IsRestart = false;

    public Sprite Gold, Silver, bronze;


}
