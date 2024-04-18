using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTRIBUTECONTROLLER
{

    private static bool IS_DRUNK = false;

    private static float MECHANICS = 10f;
    public static void SET_MECHANICS(float Value)
    {
        MECHANICS += Value;
    }

    public static float GET_MECHANICS(float Debuff = 0)
    {
        if(IS_DRUNK)
        {
            Debuff += 5f;
        }
        return MECHANICS - Debuff;
    }


    private static float RIZZ = 5f;
    public static void SET_RIZZ(float Value)
    {
        RIZZ += Value;
    }

    public static float GET_RIZZ(float Debuff = 0)
    {
        return RIZZ - Debuff;
    }
}
