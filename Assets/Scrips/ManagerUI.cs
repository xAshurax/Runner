using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public static ManagerUI instance;

    // Start is called before the first frame update
    void Start()
    {
       if(instance == null)
        {
            instance = this;
        }  else
        {
            Destroy(gameObject);
        }
    }

    private void ShowDefeat()
    {
        panel.SetActive(true);
    }

    public void Defeat()
    {
        Time.timeScale = 0f;
        ShowDefeat();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }



    

    
}
