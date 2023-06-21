using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName ="ScriptableObjects/TankScriptableObjectsList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}
