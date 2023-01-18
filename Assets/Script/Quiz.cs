using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    // Start is called before the first frame update
    public int ans1;
    public int ans2;
    public int anser;
    [SerializeField] Moviemana movie;
    [SerializeField] Scenechange scenechange;
    [SerializeField] AnsMeter ansMeter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quiz();
        goScene();
    }

    /// <summary>
    /// ‰ñ“š‚ªŒˆ‚Ü‚Á‚½‚çƒV[ƒ“‚ğ•Ï‚¦‚é
    /// </summary>
    void goScene()
    {
        if (QuizAns() == 1)
        {
            anser = 0;
            StartCoroutine(scenechange.BlackOut(1));

        }
        else if (QuizAns() == 2)
        {
            anser = 0;
            StartCoroutine(scenechange.BlackOut(2));
        }
    }
    /// <summary>
    /// ‰ñ“š”‚ğ‰ÁZ
    /// </summary>
    void quiz()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !ansMeter.cantLong)
        {
            ans1++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !ansMeter.cantLong)
        {
            ans2++;
        }
    }

    /// <summary>
    /// “š‚¦‚ÌŒˆ’è
    /// </summary>
    /// <returns></returns>
    int QuizAns()
    {
            if (ans1 >= 50)
            {
                anser = 1;
                ans1 = 0;
                ans2 = 0;
            }
            else if (ans2 >= 50)
            {
                anser = 2;
                ans1 = 0;
                ans2 = 0;
            }
        return anser;
    }
}
