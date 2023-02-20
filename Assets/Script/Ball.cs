using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 消えるまでの時間
    [SerializeField]
    private float life_time = 2.0f;

    // 時間
    float time;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>life_time){
            // 時間になったら消える
            Destroy(gameObject);
        }
    }
}
