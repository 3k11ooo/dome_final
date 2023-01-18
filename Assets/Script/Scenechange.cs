using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    Image blackOut;
    float fadeSpeed = 0.001f;
    float red, green, blue, alpha;
    public bool Black;
    // Start is called before the first frame update
    void Start()
    {
        blackOut = this.gameObject.GetComponent<Image>();
        alpha = blackOut.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        fadein();
        fadeout();
    }

    /// <summary>
    /// フェードインしてシーンを変える
    /// </summary>
    /// <param name="SceneNum"></param>
    /// <returns></returns>
    public IEnumerator BlackOut(int SceneNum)
    {
        yield return new WaitForSeconds(3f);
        Black = true;
        StartCoroutine(Scene(SceneNum));
    }

    void fadein()
    {
        if (Black)
        {
            alpha += fadeSpeed;
            SetAlpha();
        }
    }

    void fadeout()
    {
        if (!Black && alpha >= 0)
        {
            alpha -= fadeSpeed;
            SetAlpha();
        }
    }



    public void SetAlpha()
    {
        blackOut.color = new Color(red, green, blue, alpha);
    }

    IEnumerator Scene(int SceneNum)
    {
        yield return new WaitForSeconds(5);
        Black = false;
        SceneManager.LoadScene(SceneNum);
    }
}
