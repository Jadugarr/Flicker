//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Flick.FlickLineComponent flickLine { get { return (SemoGames.Flick.FlickLineComponent)GetComponent(GameComponentsLookup.FlickLine); } }
    public bool hasFlickLine { get { return HasComponent(GameComponentsLookup.FlickLine); } }

    public void AddFlickLine(UnityEngine.LineRenderer newValue) {
        var index = GameComponentsLookup.FlickLine;
        var component = (SemoGames.Flick.FlickLineComponent)CreateComponent(index, typeof(SemoGames.Flick.FlickLineComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFlickLine(UnityEngine.LineRenderer newValue) {
        var index = GameComponentsLookup.FlickLine;
        var component = (SemoGames.Flick.FlickLineComponent)CreateComponent(index, typeof(SemoGames.Flick.FlickLineComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFlickLine() {
        RemoveComponent(GameComponentsLookup.FlickLine);
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

    static Entitas.IMatcher<GameEntity> _matcherFlickLine;

    public static Entitas.IMatcher<GameEntity> FlickLine {
        get {
            if (_matcherFlickLine == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FlickLine);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFlickLine = matcher;
            }

            return _matcherFlickLine;
        }
    }
}