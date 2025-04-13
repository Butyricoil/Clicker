using UnityEngine;
using Zenject;

//Сохраняет/загружает данные, работает через IInitializable

public class SaveController : IInitializable, ITickable
{
    private GameData _gameData;
    private const string SaveKey = "GameData";

    [Inject]
    public void Construct(GameData gameData)
    {
        _gameData = gameData;
    }

    public void Initialize()
    {
        Load();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Save();
        }
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            JsonUtility.FromJsonOverwrite(json, _gameData);
        }
    }

    public void ResetProgress()
    {
        _gameData.TotalClicks = 0;
        _gameData.AutoClickLevel = 0;
        PlayerPrefs.DeleteKey(SaveKey);
    }
}