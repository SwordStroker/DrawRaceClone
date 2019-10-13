using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject finishPanel;

    private void Start()
    {
        EventManager.Subscribe(Const.EVENT_ENDGAME, OpenFinishPanel);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenFinishPanel()
    {
        finishPanel.gameObject.SetActive(true);
    }
}
