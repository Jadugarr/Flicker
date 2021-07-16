using System;
using UnityEngine;

namespace SemoGames.Level
{
    public class WaveTileBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Material material = GetComponent<SpriteRenderer>().material;
            material.SetFloat("_Offset", transform.position.y);
        }
    }
}