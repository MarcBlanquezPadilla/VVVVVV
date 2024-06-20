using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private TimeManager _time;
    [SerializeField] private DeathsController _deaths;
    [SerializeField] private KeyManager _key;
    [SerializeField] private CheckPointsManager _checkPoint;
    [SerializeField] private GameInfo _gameInfo;

    [Header("INFORMATION")]
    [SerializeField] private string CurrentGameName;
    [SerializeField] private bool NewGame;

    private void Awake()
    {
        CurrentGameName = _gameInfo.GetName();
        NewGame = _gameInfo.ReturnNewGame();
        if (NewGame == false)
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        if (NewGame)
        {
            DBManager.Instance.SaveData(CurrentGameName, _time.GetTime(), _deaths.GetDeaths(), _checkPoint.GetCheckPointNum(), _key.GetTakenKeysString());
        }
        else
        {
            DBManager.Instance.UpdateData(CurrentGameName, _time.GetTime(), _deaths.GetDeaths(), _checkPoint.GetCheckPointNum(), _key.GetTakenKeysString());
        }
    }

    public void LoadGame()
    {
        _time.SetTime(DBManager.Instance.GetIntByName("Time", CurrentGameName));
        _deaths.SetDeaths(DBManager.Instance.GetIntByName("Deaths", CurrentGameName));
        _checkPoint.SetActiveCheckPoint(DBManager.Instance.GetIntByName("CheckPoint", CurrentGameName));
        _key.SetTakenKeysByString(DBManager.Instance.GetStringByName("TakenKeys", CurrentGameName));
    }
        
}
