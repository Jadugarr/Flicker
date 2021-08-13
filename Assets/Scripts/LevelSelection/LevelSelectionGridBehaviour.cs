using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionGridBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;

        [SerializeField] private int _spacing;

        private int _maxPerRow = 3;
        private IGroup<GameEntity> _levelSelectionGroup;

        private void Start()
        {
            GameEntity gridEntity = Contexts.sharedInstance.game.CreateEntity();
            gridEntity.AddLevelSelectionGridBehaviour(this);
            gridEntity.AddView(gameObject);
            gameObject.Link(gridEntity);
        }

        public void ArrangeItemsOnGrid(List<Transform> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var currentItem = items[i];

                var startPosition = _startPoint.position;
                Vector2 newPosition = new Vector2(
                    (i / _maxPerRow) % 2 == 0
                        ? startPosition.x + _spacing * (i % _maxPerRow)
                        : startPosition.x + _spacing * ((_maxPerRow - 1) - i % _maxPerRow),
                    startPosition.y - _spacing * (i / _maxPerRow));
                currentItem.position = newPosition;

                if (i > 0)
                {
                    DrawNewLine(items[i-1].position, newPosition);
                }
            }
        }

        private async void DrawNewLine(Vector3 point1, Vector3 point2)
        {
            GameEntity itemConnector = Contexts.sharedInstance.game.CreateEntity();
            itemConnector.isLevelSelectionItemConnector = true;
            await AssetLoaderUtils.InstantiateAssetAsyncTask(
                GameConfigurations.AssetReferenceConfiguration.LevelSelectionConnectorReference, itemConnector,
                Vector3.zero, Quaternion.identity);
            var lineRenderer = itemConnector.view.Value.GetComponent<LineRenderer>();
            lineRenderer.SetPositions(new []{point1, point2});
        }
    }
}