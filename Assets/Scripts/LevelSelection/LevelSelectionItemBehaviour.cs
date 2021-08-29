using Entitas;
using Entitas.Unity;
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

        [SerializeField] private Color _beatenLevelColor;

        [SerializeField] private Color _notBeatenLevelColor;

        private int _levelIndex;

        public int LevelIndex
        {
            get => _levelIndex;
            set
            {
                _levelIndex = value;
                _levelIndexText.text = _levelIndex.ToString();

                IGroup<SaveDataEntity> savedLevelEntities =
                    Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.Level, SaveDataMatcher.LevelIndex));

                foreach (SaveDataEntity saveDataEntity in savedLevelEntities.GetEntities())
                {
                    if (saveDataEntity.levelIndex.Value == _levelIndex)
                    {
                        _spriteRenderer.color = _beatenLevelColor;
                        return;
                    }
                }
                
                _spriteRenderer.color = _notBeatenLevelColor;
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