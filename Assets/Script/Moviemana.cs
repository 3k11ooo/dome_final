using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Moviemana : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public VideoClip[] quizMovie = new VideoClip[3];
    [SerializeField] public VideoClip[] ansMovie = new VideoClip[3];
    [SerializeField] public Material[] quizImage = new Material[3];
    [SerializeField] GameObject ansobj;
    VideoPlayer videoPlayer;
    MeshRenderer ObjectSprite;
    void Start()
    {
        videoPlayer = this.gameObject.AddComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.VideoClip;
        ObjectSprite = this.gameObject.GetComponent<MeshRenderer>();
        videoPlayer.clip = ansMovie[1];
        videoPlayer.loopPointReached += LoopPointReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ����̍Đ�
    /// </summary>
    /// <param name="Video"></param>
    /// <param name="Num"></param>
    public void PlayMovei(VideoClip Video)
    {
        videoPlayer.Stop();
        videoPlayer.clip = Video;
        videoPlayer.Play();
    }

    /// <summary>
    /// �摜��ύX
    /// </summary>
    /// <param name="material"></param>
    public void ChangeSprite(Material material)
    {
        ObjectSprite.material = material; 
    }

    //����̍Đ��I��
    public void StopMovei()
    {
       videoPlayer.Stop();
    }

    /// <summary>
    /// VideoPlayer���Đ����I���������s�����
    /// </summary>
    /// <param name="vp"></param>
    public void LoopPointReached(VideoPlayer vp)
    {
        videoPlayer.Stop();
        //ObjectSprite.material = quizImage;
        ansobj.SetActive(true);
    }
}
