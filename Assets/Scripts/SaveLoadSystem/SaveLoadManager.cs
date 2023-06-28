using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private GameData gameData;

    private JsonDataHandler jsonDataHandler;

    public static SaveLoadManager instance { get; private set; }

    public List<ISaveable> saveables;

    [SerializeField] private string fileName = "gamedata.json";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    public void Start()
    {
        jsonDataHandler = new JsonDataHandler(Application.persistentDataPath, fileName);
        saveables = GetSaveables();

        LoadGame();

    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach(ISaveable saveable in saveables)
        {
            saveable.SaveData(ref gameData);
        }

        jsonDataHandler.SaveData(gameData);

        Debug.Log("save game");
    }

    public void LoadGame()
    {
        
        gameData=jsonDataHandler.LoadData();

        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        foreach (ISaveable saveable in saveables)
        {
            saveable.LoadData(gameData);
        }

        Debug.Log("load game");
        Debug.Log(gameData.playerHealth);

    }

    public List<ISaveable> GetSaveables()
    {
        IEnumerable<ISaveable> saveables = FindObjectsOfType<MonoBehaviour>()
            .OfType<ISaveable>();

        return new List<ISaveable>(saveables);
    }
}
