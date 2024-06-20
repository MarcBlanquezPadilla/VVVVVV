using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameScreen : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameInfo _gameInfo;
    [SerializeField] private ContentManager _content;
    [SerializeField] private TextBehaviour Error;

    public void LoadGameButton()
    {
        if (_gameInfo.GetName() == null)
        {
            Error.ModifyTextString("Select some game!!!");
        }
        else
        {
            SceneManagement.PlayGame();
        }
    }

    public void DeleteGameButton()
    {
        if (_gameInfo.GetName() == null)
        {
            Error.ModifyTextString("Select some game!!!");
        }
        else
        {
            DBManager.Instance.DeleteData(_gameInfo.GetName());
            _gameInfo.SetCurrentGameNull();
            _content.RestartContent();
            Error.SetEmptyString();
        }
    }
}
