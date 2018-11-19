using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static{

    public static int count = 0;

    #region PlayerPrefs
    public static void SaveCount()
    {
        PlayerPrefs.SetInt("count", count);
    }

    public static void LoadCount()
    {
        count = PlayerPrefs.GetInt("count", count);
    }
    #endregion

}
