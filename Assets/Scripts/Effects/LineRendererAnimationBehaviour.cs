using UnityEngine;

namespace SemoGames.Effects
{
    public class LineRendererAnimationBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objectsForLine;
        [SerializeField] private LineRenderer _lineRenderer;

        private void Update()
        {
            for (var i = 0; i < _objectsForLine.Length; i++)
            {
                GameObject o = _objectsForLine[i];
                _lineRenderer.SetPosition(i, o.transform.position);
            }
        }
    }
}