using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataSaver : MonoBehaviour
{
    public static int weapon = 0;

    public static void HandleChange(int num)
    {
        weapon = num;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
