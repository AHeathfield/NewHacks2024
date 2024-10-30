using UnityEngine;
/* Need this above all classes that inherit ScriptableObject
This basically just creates a Scriptable Object called "Scriptable Unit"
In project menu (in Unity) if you right-click -> create, you'll see Scriptable Unit as an option*/
[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Side Side;
    public BaseUnit UnitPrefab;
}

public enum Side 
{
    Black,
    White
}
