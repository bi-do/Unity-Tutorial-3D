using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorAction : MonoBehaviour
{
    PlayableDirector pb;

    public Camera target_cam;

    void Start()
    {
        this.pb = this.GetComponent<PlayableDirector>();
        this.pb.Play();    
    }

    void Update()
    {
        if (this.pb.time > this.pb.duration)
        {
            if (Camera.main == this.target_cam)
            {
                target_cam.GetComponent<CinemachineBrain>().enabled = false;
            }

            target_cam.gameObject.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }
}
