using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable 
{
    public void SaveData(ref GameData gameData);

    public GameData LoadData(GameData gameData);
    
}
