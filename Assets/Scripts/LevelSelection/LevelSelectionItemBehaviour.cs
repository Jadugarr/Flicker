using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private static readonly int IsOutlineActive = Shader.PropertyToID("_IsOutlineActive");

        public int LevelIndex;

        private void OnMouseEnter()
        {
            Debug.Log("Hi");
            //_spriteRenderer.material.SetInt(IsOutlineActive, 1);
        }

        private void OnMouseExit()
        {
            Debug.Log("Bye");
            //_spriteRenderer.material.SetInt(IsOutlineActive, 0);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Hi");
            _spriteRenderer.material.SetInt(IsOutlineActive, 1);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Bye");
            _spriteRenderer.material.SetInt(IsOutlineActive, 0);
        }
    }
}