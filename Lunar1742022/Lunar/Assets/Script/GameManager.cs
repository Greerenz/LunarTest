using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public TestSpawn spawner;
    public Enemy enemy;
    public LevelSystem levelsystem;
    public Inventory inventory;
    public DialogueThing dialogue;
    public PlayerMovement playermovement;
    
    private void Start()
    {
       
        Cursor.visible = false;
    }
}
