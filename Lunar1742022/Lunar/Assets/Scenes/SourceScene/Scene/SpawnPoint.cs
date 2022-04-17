using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private static List<string> DownSideRuinSpawn = new List<string>() { "DownSideRuin_A", "DownSideRuin_B", "DownSideRuin_C", "DownSideRuin_D", "DownSideRuin_F", "DownSideRuin_G", "DownSideRuin_H" };
    private static List<string> RuinSpawn = new List<string>() { "Ruin_A" , "Ruin_B"};
    private static List<string> OutsideSpawn = new List<string>() {"Outside_A"};
    [Tooltip("0 = Outside_A" + "\n" + "1 = Ruin_A" + "\n" + "2 = Ruin_B" + "\n" + "3 = DownSideRuin_A" + "\n" + "4 = DownSideRuin_B" + "\n" + "5 = DownSideRuin_C" + "\n" + "6 = DownSideRuin_D" + "\n" + "7 = DownSideRuin_F" + "\n" + "8 = DownSideRuin_G" + "\n" + "9 = DownSideRuin_H")]
    public int SpawnSpotID;
    [HideInInspector]
    public static int SpawnSpotID_;
    [HideInInspector]
    public static string SpawnSpotName;
    public GameObject Spawnpoint;
    [HideInInspector]
    public static bool Warp;

    private void Awake()
    {
        Spawn();
        if (!Warp)
        {

            GameManager.Instance.playermovement.rb.transform.position = new Vector2(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y);
            Debug.Log("Chabg");
            Warp = true;
        }
    }
    private void Update()
    {
       
    }
    private void Spawn()
    {
        Debug.Log("Check");
        switch (SpawnSpotID)
        {
               ////////////////// Outside /////////////////
            case 0:
                SpawnSpotName = OutsideSpawn[0].ToString();
                SpawnSpotID_ = 0;
                break;
                ////////////////// Ruin /////////////////
            case 1:
                SpawnSpotName = RuinSpawn[0].ToString();
                SpawnSpotID_ = 1;
                break;
            case 2:
                SpawnSpotName = RuinSpawn[1].ToString();
                SpawnSpotID_ = 2;
                break;
                ////////////////// DownSideRuin ///////////
            case 3:
                SpawnSpotName = DownSideRuinSpawn[0].ToString();
                SpawnSpotID_ = 3;
                break;
            case 4:
                SpawnSpotName = DownSideRuinSpawn[1].ToString();
                SpawnSpotID_ = 4;
                break;
            case 5:
                SpawnSpotName = DownSideRuinSpawn[2].ToString();
                SpawnSpotID_ = 5;
                break;
            case 6:
                SpawnSpotName = DownSideRuinSpawn[3].ToString();
                SpawnSpotID_ = 6;
                break;
            case 7:
                SpawnSpotName = DownSideRuinSpawn[4].ToString();
                SpawnSpotID_ = 7;
                break;
            case 8:
                SpawnSpotName = DownSideRuinSpawn[5].ToString();
                SpawnSpotID_ = 8;
                break;
            case 9:
                SpawnSpotName = DownSideRuinSpawn[6].ToString();
                SpawnSpotID_ = 9;
                break;
        }

        switch (SpawnSpotName)
        {
            ////////////////// Outside /////////////////
            case "Outside_A":
                Debug.Log("SpawnID: "+ SpawnSpotID + " Down has been setup");
                break;
            ////////////////// Ruin /////////////////
            case "Ruin_A":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "Ruin_B":
                Debug.Log("SpawnID: " + SpawnSpotID + " Down has been setup");
                break;
                ////////////////// DownSideRuin ///////////
            case "DownSideRuin_A":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_B":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_C":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_D":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_F":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_G":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            case "DownSideRuin_H":
                Debug.Log("SpawnID: " + SpawnSpotID + " UP has been setup");
                break;
            default:
                Debug.Log("XXX SpawnID: " + SpawnSpotID + " Not Found NAME: " + SpawnSpotName);
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spawn();
        }
    }
}
