using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> selectCharacters;
    public bool startGame = false, gameOverControl = false;
    public GameObject player;
    [SerializeField] GameObject failedPanel, startPanel, finishPanel, mainCamera;
    CameraControl cameraControlScript;
    PaintingWall paintWallScript;

    void Awake()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter");
        selectCharacters[index].SetActive(true);
        player = Instantiate(selectCharacters[index], new Vector3(0, 0, -0.25f), Quaternion.identity);
    }
    void Start()
    {
        paintWallScript = GetComponent<PaintingWall>();
        cameraControlScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse0))
        {
            startGame = true;
            startPanel.SetActive(false);
        }
    }

    public void GoToPaintWall()
    {
        gameOverControl = true;
        cameraControlScript.enabled = false; // so that the image does not shift when the camera approaches the wall.
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(-2, 0, 0));
        paintWallScript.enabled = true;
    }

    public void OpenFinishPanel()
    {
        finishPanel.SetActive(true);
    }

    public void GoToLevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOver()
    {
        gameOverControl = true;
        failedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(string levelIndex)
    {
        Time.timeScale = 1;
        failedPanel.SetActive(false);
        SceneManager.LoadScene("level" + levelIndex);
    }

}
