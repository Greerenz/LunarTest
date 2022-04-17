using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int Level;
    private int EXP;
    private static int[] ExpGainPerLevel = new[] { 10 ,20 ,30 ,40 ,50 ,60 ,70 ,80 ,90 ,100 };

    public void Levelsystem()
    {
        Level = 0;
        EXP = 0;
    }

    public void ADDEXP(int EXPADD)
    {
        EXP += EXPADD;
        if(EXP >= GetEXPTONEXTLEVEL(Level))
        {
            EXP -= GetEXPTONEXTLEVEL(Level);
            Level++;
        }
    }


    public int GetEXPTONEXTLEVEL(int Lv)
    {
        if(Lv < ExpGainPerLevel.Length)
        {
            return ExpGainPerLevel[Level];
        }
        else
        {
            Debug.LogError("Level Missing: " + Level);
            return 100;
        }
    }


    public int GetLevel()
    {
        return Level;
    }



}
