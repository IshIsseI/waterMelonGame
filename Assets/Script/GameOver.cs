using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject Score_obj;
    public GameObject Image_obj;
    public Sprite sprite;
    Text ScoreText;
    Image image;

    public static bool onload = false;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText = Score_obj.GetComponent<Text>();
        ScoreText.text = MainScript.Score.ToString();
        image = Image_obj.GetComponent<Image>();
        image.sprite = Touch._sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(onload == false)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                RetryButton();
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                EndButton();
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                SendScore();
            }
        }
        
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void EndButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }

    public void SendScore()
    {
        onload = true;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(MainScript.Score);
    }
}
