using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameScreen : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameInfo _gameInfo;
    [SerializeField] private TextBehaviour Error;

    public void NewGameButton()
    {
        if (_gameInfo.GetName() == null)
        {
            Error.ModifyTextString("Cannot create a no name game!!");
        }
        else if (_gameInfo.GetName().Length == 0)
        {
            Error.ModifyTextString("Cannot create a no name game!!");
        }
        else if (DBManager.Instance.FindExistingData(_gameInfo.GetName(),"GameName"))
        {
            Error.ModifyTextString("This game already exist!!");
        }
        else
        {
            SceneManagement.PlayGame();
        }
    }
}
