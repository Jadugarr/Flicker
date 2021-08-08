//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class SaveDataEntity {

    public SemoGames.Collectables.CollectableIdComponent collectableId { get { return (SemoGames.Collectables.CollectableIdComponent)GetComponent(SaveDataComponentsLookup.CollectableId); } }
    public bool hasCollectableId { get { return HasComponent(SaveDataComponentsLookup.CollectableId); } }

    public void AddCollectableId(int newValue) {
        var index = SaveDataComponentsLookup.CollectableId;
        var component = (SemoGames.Collectables.CollectableIdComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectableIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCollectableId(int newValue) {
        var index = SaveDataComponentsLookup.CollectableId;
        var component = (SemoGames.Collectables.CollectableIdComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectableIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCollectableId() {
        RemoveComponent(SaveDataComponentsLookup.CollectableId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class SaveDataEntity : ICollectableIdEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class SaveDataMatcher {

    static Entitas.IMatcher<SaveDataEntity> _matcherCollectableId;

    public static Entitas.IMatcher<SaveDataEntity> CollectableId {
        get {
            if (_matcherCollectableId == null) {
                var matcher = (Entitas.Matcher<SaveDataEntity>)Entitas.Matcher<SaveDataEntity>.AllOf(SaveDataComponentsLookup.CollectableId);
                matcher.componentNames = SaveDataComponentsLookup.componentNames;
                _matcherCollectableId = matcher;
            }

            return _matcherCollectableId;
        }
    }
}
