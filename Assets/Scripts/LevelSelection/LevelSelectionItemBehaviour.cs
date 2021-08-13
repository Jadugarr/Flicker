using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.GameTransition;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private TMP_Text _levelIndexText;

        private int _levelIndex;
        
        public int LevelIndex
        {
            get => _levelIndex;
            set
            {
                _levelIndex = value;
                _levelIndexText.text = _levelIndex.ToString();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity) entityLink.entity).isSelected = true;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity) entityLink.entity).isSelected = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.game.CreateEntity().AddLevelSelected(_levelIndex);
        }
    }
}