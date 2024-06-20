using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    [Header("REFERENCED")]
    [SerializeField] private KeyBehaviour[] Keys;

    [Header("INFORMATION")]
    [SerializeField] private int totalKeys;
    [SerializeField] private int numtakenkeys;
    [SerializeField] private float progress;


    [Header("EVENTS")]
    public UnityEvent<float> NewKey;
    public UnityEvent HaveAllKeys;

    private string takenKeys;

    private void Awake()
    {
        totalKeys = Keys.Length;
        takenKeys = null;
    }

    public void SumKey(KeyBehaviour key)
    {
        numtakenkeys += 1;
        for (int i = 0; i < Keys.Length; i++)
        {
            if (Keys[i] == key)
            {
                ModifyTakenKeysString(i);
            }
        }
        UpdateProgress();
    }

    public void UpdateProgress()
    {
        progress = (float)numtakenkeys / totalKeys;
        NewKey.Invoke(progress);

        if (numtakenkeys == totalKeys)
        {
            HaveAllKeys.Invoke();
            SoundManager.Instance.PlayAudio("AllKeys");
        }
    }

    public void ModifyTakenKeysString(int keyId)
    {
        takenKeys += keyId + "-";
    }

    public string GetTakenKeysString()
    {
        return takenKeys;
    }

    public void SetTakenKeysByString(string s)
    {
        takenKeys = s;
        DisableTakenKeysByString();
    }

    public void DisableTakenKeysByString()
    {
        string key = null;
        if (!string.IsNullOrEmpty(takenKeys))
        {
            for (int i = 0; i < takenKeys.Length; i++)
            {
                if (takenKeys[i] != '-')
                {
                    key += takenKeys[i];
                }
                else
                {
                    if (key != null)
                    {
                        numtakenkeys++;
                    }
                    DisableKey(Int32.Parse(key));
                    key = null;
                }
            }
            UpdateProgress();
        }
    }

    public void DisableKey(int numKey)
    {
        Keys[numKey].Disable();
    }
}
