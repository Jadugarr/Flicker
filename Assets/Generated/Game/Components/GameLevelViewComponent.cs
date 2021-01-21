//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Level.LevelViewComponent levelView { get { return (SemoGames.Level.LevelViewComponent)GetComponent(GameComponentsLookup.LevelView); } }
    public bool hasLevelView { get { return HasComponent(GameComponentsLookup.LevelView); } }

    public void AddLevelView(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.LevelView;
        var component = (SemoGames.Level.LevelViewComponent)CreateComponent(index, typeof(SemoGames.Level.LevelViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLevelView(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.LevelView;
        var component = (SemoGames.Level.LevelViewComponent)CreateComponent(index, typeof(SemoGames.Level.LevelViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLevelView() {
        RemoveComponent(GameComponentsLookup.LevelView);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelView;

    public static Entitas.IMatcher<GameEntity> LevelView {
        get {
            if (_matcherLevelView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelView = matcher;
            }

            return _matcherLevelView;
        }
    }
}
