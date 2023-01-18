using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsMeter : MonoBehaviour
{
    Vector3 scale1;
    Vector3 ObjLong1;
    Vector3 scale2;
    Vector3 ObjLong2;
    public bool cantLong;
    public float timer = 5;
    Color ansColor = new Color(0.0f,174.0f,239.0f,1.0f);
    float ScaleY;
    float PositionY;
    [SerializeField] public GameObject ansObj1;
    [SerializeField] public GameObject ansObj2;
    [SerializeField] private GameObject worldObj;
    [SerializeField] private ParticleSystem effect;
    float worldAngle;
    // Start is called before the first frame update
    void Start()
    {
        worldAngle = worldObj.transform.rotation.x;
        scale1 = ansObj1.transform.localScale;
        ObjLong1 = ansObj1.transform.position;
        scale2 = ansObj2.transform.localScale;
        ObjLong2 = ansObj2.transform.position;
        ScaleY = scale1.y / 10;
        PositionY = ObjLong1.y / 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        ansPlus();
        maxlong();
        ansObj1.transform.localScale = scale1;
        ansObj1.transform.position = ObjLong1;
        ansObj2.transform.localScale = scale2;
        ansObj2.transform.position = ObjLong2;
    }

    /// <summary>
    /// 回答に応じて大きさを変える
    /// </summary>
    void ansPlus()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !cantLong)
        {
            longMeter1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !cantLong)
        {
            longMeter2();
        }
    }

    /// <summary>
    /// 回答１のサイズ変更
    /// </summary>
    void  longMeter1()
    {
        scale1.y +=ScaleY;
        ObjLong1.y += PositionY * worldAngle / 180;
    }

    /// <summary>
    /// 回答２のサイズ変更
    /// </summary>
    void longMeter2()
    {
        scale2.y += ScaleY;
        ObjLong2.y += PositionY * worldAngle / 180;
    }

    /// <summary>
    /// 回答数が最大になったときに色変えエフェクト出す
    /// </summary>
    void maxlong()
    { 
        if (scale1.y > ScaleY * 59)
        {
            scale1.y = ScaleY * 60;
            //ObjLong1.y = PositionY * 60 * 180 / 15;
            if (timer <= 0.0f)
            {
                Instantiate(effect, ansObj1.transform.position, Quaternion.Euler(-90, 0, 0));
                timer = 5.0f;
            }
            ansObj1.GetComponent<Renderer>().material.color = ansColor;
            cantLong = true;
        }
        else if (scale2.y > ScaleY * 59)
        {
            scale2.y = ScaleY * 60;
            //ObjLong2.y = PositionY * 60 * 180 / 15;
            ansObj2.GetComponent<Renderer>().material.color = ansColor;
            Instantiate(effect, ansObj2.transform.position, Quaternion.identity);
            cantLong = true;
        }
    }
}
