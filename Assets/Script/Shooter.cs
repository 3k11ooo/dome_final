using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject r_Ball;
    public GameObject b_Ball;
    public GameObject g_Ball;

    // ボールを撃つ的の位置座標
    public GameObject target;
    private Vector3 target_pos;
    private Vector3 pos;

    // ballのスピード
    private float speed = 50;


    // 発射する球の数を参照する
    public HttpTest answer;

    // class
    private class ballAndnum{
        public GameObject obj;
        public int answer;
    }

    // 結果用のクラス
    public class answerData{
        public string name;
        public int answer;
    }

    // インスタンス
    ballAndnum red = new ballAndnum();
    ballAndnum blue = new ballAndnum();
    ballAndnum green = new ballAndnum();

    public answerData b_red = new answerData();
    public answerData b_blue = new answerData();
    public answerData b_green = new answerData();

    // インスタンス 配列
    public List<answerData> resultArray = new List<answerData>();

    // Start is called before the first frame update
    void Start()
    {
        red.obj = r_Ball;
        blue.obj = b_Ball;
        green.obj = g_Ball;
        BeforeAnswer();
        resultInstanse();
        target_pos = target.transform.position;
        target_pos.z = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(answer.res_json.quiz == true){
            // 増えたボールを算出
            List<ballAndnum>shootArray = CulAnswer();
            // ターゲットの座標をランダムにずらす
            RandPos();
            for(int i=0; i<shootArray.Count; i++){
                CreateBall(shootArray[i].obj, shootArray[i].answer);
            }
            BeforeAnswer();
        }
    }
    void RandPos(){
        float randX = Random.Range(-1.0f, 1.0f);
        float randY = Random.Range(-1.0f, 0.4f);
        pos = target_pos;
        pos.x += randX;
        pos.y += randY;
    }

    void CreateBall(GameObject ball, int num){
        // ゲームオブジェクトを生成します。
        for(int i=0; i<num; i++){
            GameObject obj = Instantiate(ball, transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = obj.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(pos * speed);
        }
    }

    // 次回用に現在の投票数を格納
    void BeforeAnswer() {
        b_red.answer = answer.res_json.ans_red;
        b_blue.answer = answer.res_json.ans_blue;
        b_green.answer = answer.res_json.ans_green;
    }

    List<ballAndnum> CulAnswer() {
        List<ballAndnum> ansArray = new List<ballAndnum>();
        red.answer = answer.res_json.ans_red - b_red.answer;
        ansArray.Add(red);
        blue.answer = answer.res_json.ans_blue - b_blue.answer;
        ansArray.Add(blue);
        green.answer = answer.res_json.ans_green - b_green.answer;
        ansArray.Add(green);
        return ansArray;
    }

    void resultInstanse() {
        b_red.name = "Red";
        b_blue.name = "Blue";
        b_green.name = "Green";
        answerData[] tempData = new answerData[] {b_red, b_blue, b_green};
        resultArray.AddRange(tempData);
    }
}
