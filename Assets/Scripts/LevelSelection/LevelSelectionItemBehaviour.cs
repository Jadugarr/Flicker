using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.GameTransition;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private static readonly int IsOutlineActive = Shader.PropertyToID("_IsOutlineActive");

        public int LevelIndex;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _spriteRenderer.material.SetInt(IsOutlineActive, 1);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _spriteRenderer.material.SetInt(IsOutlineActive, 0);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToTeardownTransition,
                    TransitionComponent = new ControllerToTeardownTransitionComponent
                        {Value = GameControllerType.LevelSelection}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToRemove,
                    TransitionComponent = new SceneToRemoveComponent
                        {Value = GameConfigurations.GameSceneConfiguration.LevelSelectionSceneName}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToAdd,
                    TransitionComponent = new SceneToAddComponent
                        {Value = GameConfigurations.GameSceneConfiguration.GameSceneName,}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.LevelIndexToLoadTransition,
                    TransitionComponent = new LevelIndexToLoadTransitionComponent {Value = LevelIndex}
                }
            );
        }
    }
}