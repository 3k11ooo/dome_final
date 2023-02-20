using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManageScript : MonoBehaviour
{
    // 発射する球の数を参照する
    public HttpTest answer;

    public Shooter shooter;

    // 回答時間
    [SerializeField]
    private float life_time = 60;
    private float time;
    // 最大値の色
    private string max_name;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;


        // 本番
        StartCoroutine(answer.APIPost("start"));

        //test
        // answer.res_json.quiz = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > life_time && answer.res_json.quiz == false){
            bool result = CulResut();
            if(Input.GetKeyDown(KeyCode.Space) && result == true){
                // test
                Debug.Log("correct scene");

                // 本番
                // CorrectAnswer();
            }
            else if(Input.GetKeyDown(KeyCode.Space) && result == false){
                // test
                Debug.Log("incorrect scene");

                // 本番
                // IncorrectAnswer();
            }
        }

        else if (time > life_time && answer.res_json.quiz == true){
            // test
            // answer.res_json.quiz = false;
            // 本番
            StartCoroutine(answer.APIDelete());
        }


        /// ここはテスト 本番は消す
        // else if (answer.res_json.quiz == true){
        //     int n = Random.Range(0, 10);
        //     switch(n){
        //         case 1:
        //             answer.res_json.ans_green++;
        //             break;
        //         case 2:
        //             answer.res_json.ans_red++;
        //             break;
        //         case 3:
        //             answer.res_json.ans_blue++;
        //             break;
        //         default:
        //             break;
        //     }
        // }

        ///
    }

    bool CulResut() {
        bool res_result = false;
        List<int> intArray = new List<int>(){shooter.b_red.answer, shooter.b_blue.answer, shooter.b_green.answer};
        int max = intArray.Max();
        for(int i=0; i<intArray.Count; i++){
            if(max == shooter.resultArray[i].answer){
                max_name = shooter.resultArray[i].name;
            }
        }
        if(max_name == "Blue"){
            res_result = true;
        }
        return res_result;
    }

    private void CorrectAnswer(){
        SceneManager.LoadSceneAsync("KMP_Final_Scene");
    }

    private void IncorrectAnswer(){
        SceneManager.LoadSceneAsync("KMP_Incorrect");
    }
}
