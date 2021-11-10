using UnityEngine;

namespace SemoGames.Collectables
{
    public class UICollectableBehaviour : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.up, 360 * Time.deltaTime);
        }
    }
}