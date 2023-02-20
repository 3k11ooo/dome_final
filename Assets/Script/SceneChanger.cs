using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    //それぞれのバーのオブジェクトを取る
    [SerializeField]
    private GameObject RedBar;
    [SerializeField]
    private GameObject GreenBar;
    [SerializeField]
    private GameObject BlueBar;

    private void CorrectAnswer()
    {
        SceneManager.LoadSceneAsync("KMP_Final_Scene");
    }

    private void IncorrectAnswer()
    {
        SceneManager.LoadSceneAsync("KMP_Incorrect");
    }

    // Update is called once per frame
    void Update()
    {
        Transform RTransform = RedBar.transform;
        Transform GTransform = GreenBar.transform;
        Transform BTransform = BlueBar.transform;
        Vector3 RPos = RTransform.position;
        Vector3 GPos = GTransform.position;
        Vector3 BPos = BTransform.position;

        //正解した場合の処理
        if(BPos.y >= 8.0f)
        {
            CorrectAnswer();
        }

        //間違えた場合の処理
        if(RPos.y >= 8.0f)
        {
            IncorrectAnswer();
        }

        if(GPos.y >= 8.0f)
        {
            IncorrectAnswer();
        }

    }
}
