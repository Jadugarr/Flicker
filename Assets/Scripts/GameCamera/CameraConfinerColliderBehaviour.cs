using UnityEngine;

namespace GameCamera
{
    public class CameraConfinerColliderBehaviour : MonoBehaviour
    {
        [SerializeField] private Collider2D cameraConfinerCollider;
        
        private void Start()
        {
            Contexts.sharedInstance.game.ReplaceCameraConfinerCollider(cameraConfinerCollider);
        }
    }
}