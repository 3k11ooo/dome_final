using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HttpTest : MonoBehaviour
{
    // 選択肢の回答数
    // public int sel_red = 0;
    // public int sel_blue = 0;
    // public int sel_green = 0;
    
    // quizの状況
    private Boolean quize_phase = false;

    // quizの状況を把握するJsonデータ
    [System.Serializable]
    public class quiz_data {
        public Boolean quiz;
    }
    // http getで取得したJsonをインスタンス化するためのクラス
    [System.Serializable]
    public class JsonClass {
        public int ans_red;
        public int ans_blue;
        public int ans_green;
        public Boolean quiz;
    }
    // インスタンス
    public JsonClass res_json;

    //endpoint
    private string url = "https://dome-project-server.onrender.com/api/test";

  // Start is called before the first frame update
  void Start()
    {

        // StartCoroutine(APIGet());
        // StartCoroutine(APIPost("start"));
        // StartCoroutine(APIGet());
        // StartCoroutine(APIPost("end"));
        // StartCoroutine(APIGet());
    }

    // Update is called once per frame
    void Update()
    {
        if(quize_phase == true){
            StartCoroutine(APIGet());
        }
    }

  public IEnumerator APIGet()
    {
        // リクエストを作成
        UnityWebRequest request = UnityWebRequest.Get(url);
        // データをJSONで受け取りたいのでHeaderをセット
        request.SetRequestHeader("Content-Type", "application/json");
        // なにここ？リクエストを送信している？
        yield return request.SendWebRequest();

        // リターンデータの処理
        if (request.result != UnityWebRequest.Result.Success)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.Log(request.error);
        }
        else
        {
            // 文字列として格納
            string response = request.downloadHandler.text;

            // string to json
            res_json = JsonUtility.FromJson<JsonClass>(response);

            // ローカル変数へ格納
            // sel_red = res_json.ans_red;
            // sel_blue = res_json.ans_blue;
            // sel_green = res_json.ans_green;
        }
    }
    

    public IEnumerator APIPost(string quiz_start_or_end) {
        // postする情報
        // json型のオブジェクトを読み込む
        quiz_data data = new quiz_data();
        // クイズ開始時はtrue、クイズ終了時はfalse 場合分けする
        if(quiz_start_or_end == "start"){
            // Debug.Log("クイズ開始します！");
            data.quiz = true;
            quize_phase = true;
        }
        // 謎の文字列に変換
        string json = JsonUtility.ToJson(data);
        // stringをbyteに変換する
        byte[] postData = Encoding.UTF8.GetBytes( json );

        // リクエストを作成
        // postのインスタンスを作成
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        // byte型のデータを追加
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        // 何をやっているかわからない！！！
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        // データをJSONで受け取りたいのでHeaderをセット
        request.SetRequestHeader("Content-Type", "application/json");
        // リクエスト送信
        yield return request.SendWebRequest();

        // データ処理
        if (request.result != UnityWebRequest.Result.Success)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.Log(request.error);
        }
        else
        {
            // 文字列として格納
            string response = request.downloadHandler.text;

            Debug.Log("post res >> " + response);
            //JsonClass result_json = JsonUtility.FromJson<JsonClass>(result);
        }
    }


    public IEnumerator APIDelete() {
        // リクエストを作成
        UnityWebRequest request = UnityWebRequest.Delete(url);
        // なにここ？リクエストを送信している？
        yield return request.SendWebRequest();

        // リターンデータの処理
        if (request.result != UnityWebRequest.Result.Success)
        {
            // エラーが起きた場合はエラー内容を表示
            Debug.Log(request.error);
        }
        else
        {
            quize_phase = false;
            // ログに出力
            Debug.Log("クイズ終了です！");
        }
    }

}