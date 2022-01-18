using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public void SelectLevel(string levelNumber)
    {
        SceneManager.LoadScene("level" + levelNumber);
    }
}
