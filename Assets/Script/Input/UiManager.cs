using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject _optionPanel;

    public string _sceneName;

    // Use this for initialization
    void Start()
    {
        _optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OnOffOption()
    {
        if (_optionPanel.active == true)
        {
            _optionPanel.SetActive(false);
        }
        else
        {
            _optionPanel.SetActive(true);
        }
    }

}
