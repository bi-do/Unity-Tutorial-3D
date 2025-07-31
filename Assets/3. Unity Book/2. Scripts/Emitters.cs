
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector pb;
    public SignalReceiver receiver;
    public SignalAsset signal;

    public void OnTimelineSetSpeed(float param_speed)
    {
        this.pb.playableGraph.GetRootPlayable(0).SetSpeed(param_speed);
    }

    public void SetSignalEvent()
    {
        UnityEvent event_container = new UnityEvent();

        event_container.AddListener(
            () => {
                Debug.Log("시네마신 속도 0.2초 설정");
                OnTimelineSetSpeed(0.2f);
            });

        receiver.AddReaction(signal, event_container);


    }
}
