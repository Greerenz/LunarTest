using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject BagMenu;
    public GameObject ItemMenu;
    public Button BagButton;
    public Button ItemButton;
  /*  private void OnEnable()
    {
        
        if (BagButton != null)
        {
            BagButton.Select();
      
        }
        if (ItemButton != null)
        {
            ItemButton.Select();
        }
    }
  */
  private void ForceSelectGameOBJ(GameObject gameobject)
    {
        if(EventSystem.current.currentSelectedGameObject == gameobject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(gameobject);
        }
    }

    bool runOnce;
    bool runOnce_I;
    void OnEnable()
    {
        runOnce = false;
        runOnce_I = false;
    }



    // Update is called once per frame
    void Update()
    {

        if (runOnce == false)
        {
            BagButton.Select();
            runOnce = true;
        }
        if(ItemMenu.activeSelf == true)
        {
            if (runOnce_I == false)
            {
                ItemButton.Select();
                runOnce_I = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
   
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if(BagMenu.activeSelf == false)
        {
            BagMenu.SetActive(true);
            ItemMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        OnEnable();
    }
    void Pause()

    {
        pauseMenuUI.SetActive(true);
        if (BagMenu.activeSelf == false)
        {
            BagMenu.SetActive(true);
            ItemMenu.SetActive(false);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Game...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }

   
}
