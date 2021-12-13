using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private bool restart = false;
    public GameObject gameOver;
    public GameObject waveText;
    private PlayerHealthBar playerHealthBar;
    private PlantHealthBar plantHealthBar;
    
    
    void Start()
    {
        waveText.SetActive(true);
        gameOver.SetActive(false);
       
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            waveText.SetActive(false);
        }
        //if (playerHealthBar.playerDeath || plantHealthBar.plantDestroyed)
        //{

        //}

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
