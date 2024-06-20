using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private GameObject buttonPrefab;

    private void Awake()
    {
        CreateButtons();
    }

    public void AddGame(string gameName)
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.GetComponentInChildren<Text>().text = gameName;
        button.transform.SetParent(this.gameObject.transform);
        button.transform.localScale = Vector2.one;
    }

    public void RestartContent()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        CreateButtons();
    }

    public void CreateButtons()
    {
        int counter = 0;
        int i = 0;

        while (counter < DBManager.Instance.CountData())
        {
            string name = null;
            name = DBManager.Instance.GetStringByName("GameName", i);
            
            if (name.Length >= 1 && name != null)
            {
                counter++;
                AddGame(name);
            }
            i++;
        }
    }
}
