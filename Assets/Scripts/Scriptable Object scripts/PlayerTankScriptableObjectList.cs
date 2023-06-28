using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObjectList", menuName ="ScriptableObjects/PlayerTankScriptableObjectsList")]
public class PlayerTankScriptableObjectList : ScriptableObject
{
    public PlayerTankScriptableObject[] PlayerTanks;
}
