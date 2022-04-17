using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScene : MonoBehaviour
{
    private string Outside = "Outside";
    private string Ruin = "Ruin";
    private string DownSideRuin = "DownSideRuin";
    private Scene scene;

    bool On;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        On = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        On = false;
    }
    void Update()
    {
        if (On)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Scene();
            }
        }
    }

    void Scene()
    {
        if(scene.name == Outside)
        {
            SceneManager.LoadScene(Ruin);
            SpawnPoint.Warp = false;
        }
        if(scene.name == Ruin)
        {
            SceneManager.LoadScene(DownSideRuin);
            SpawnPoint.Warp = false;
        }
    }
}
