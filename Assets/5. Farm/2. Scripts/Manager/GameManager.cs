using Unity.Cinemachine;
using UnityEngine;
public enum CamState { Outside, Field, House, Animal }
namespace Farm
{

    public class GameManager : Singleton<GameManager>
    {

        public CamState cam_state = CamState.Outside;

        [SerializeField] private CinemachineClearShot clear_shot;

        public void SetCamState(CamState param_state)
        {
            if (this.cam_state != param_state)
            {
                this.cam_state = param_state;

                foreach (CinemachineVirtualCameraBase element in clear_shot.ChildCameras)
                {
                    element.Priority = 0;
                }

                clear_shot.ChildCameras[(int)cam_state].Priority = 10;
            }
        }
    }
}
