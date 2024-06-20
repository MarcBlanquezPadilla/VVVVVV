using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    public void ModifyTextNum(int num)
    {
        GetComponent<Text>().text = "" + num;
    }

    public void ModifyTextString(string word)
    {
        GetComponent<Text>().text = "" + word;
    }

    public void SetEmptyString()
    {
        GetComponent<Text>().text = "";
    }
}
