using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentButtonBehaviour : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameInfo _gameInfo;
    
    private TextBehaviour _current;
    private Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _current = GameObject.Find("CurrentGameName").GetComponent<TextBehaviour>();
        var colors = GetComponent<Button>().colors;
        colors.normalColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<Button>().colors = colors;
    }

    public void SetGameName()
    {
        _gameInfo.ChangeSelected(_text.text);
        _current.ModifyTextString(_text.text);
    }
}
