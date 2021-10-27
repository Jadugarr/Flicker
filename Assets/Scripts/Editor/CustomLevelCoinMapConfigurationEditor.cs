using SemoGames.Collectables;
using SemoGames.Configurations;
using UnityEditor;
using UnityEngine;

namespace SemoGames.GameEditor
{
    [CustomEditor(typeof(LevelCoinMapConfiguration))]
    public class CustomLevelCoinMapConfigurationEditor : Editor
    {
        private SerializedProperty _collectableIds;
        private SerializedProperty _assetReferenceConfig;

        private void OnEnable()
        {
            _collectableIds = serializedObject.FindProperty("_collectableIds");
            _assetReferenceConfig = serializedObject.FindProperty("_assetReferenceConfiguration");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate LevelCoinMap"))
            {
                _collectableIds.ClearArray();
                AssetReferenceConfiguration config = (AssetReferenceConfiguration)_assetReferenceConfig.objectReferenceValue;

                for (int i = 0; i < config.LevelAssetReferences.Length; i++)
                {
                    _collectableIds.InsertArrayElementAtIndex(i);
                    SerializedProperty element = _collectableIds.GetArrayElementAtIndex(i);
                    using (var editingScope = new PrefabUtility.EditPrefabContentsScope(AssetDatabase.GUIDToAssetPath(config.LevelAssetReferences[i].AssetGUID)))
                    {
                        element.FindPropertyRelative("LevelIndex").intValue = i;
                        CollectableSpawnBehaviour[] collectables =
                            editingScope.prefabContentsRoot.GetComponentsInChildren<CollectableSpawnBehaviour>();
                        SerializedProperty collectableIds = element.FindPropertyRelative("CollectableIds");
                        collectableIds.ClearArray();
                        for (var index = 0; index < collectables.Length; index++)
                        {
                            collectableIds.InsertArrayElementAtIndex(index);
                            SerializedProperty newArrayElement = collectableIds.GetArrayElementAtIndex(index);
                            newArrayElement.intValue = collectables[index].CollectableId;
                        }
                    }
                }
                
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}