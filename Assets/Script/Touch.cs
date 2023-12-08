using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Touch : MonoBehaviour
{

    public static bool collisionTime = true;

    public RenderTexture renderTexture;

    Texture2D tex;

    public static Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TouchEnd();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collisionTime == true)
        {
            TouchEnd();
        }
    }

    void RenderTextureImg()
    {

        // RenderTextureに描画されたカメラの画像を
        // テクスチャとして取得
        var oriRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        tex = new Texture2D(renderTexture.width, renderTexture.height);
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        _sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);

        // 後処理
        RenderTexture.active = oriRenderTexture;
    }

    void TouchEnd()
    {
        RenderTextureImg();
        SceneManager.LoadScene("GameOverScene");
    }

}
