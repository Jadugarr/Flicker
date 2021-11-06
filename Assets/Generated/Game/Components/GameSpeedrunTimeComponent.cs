//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.GameTimer.SpeedrunTimeComponent speedrunTime { get { return (SemoGames.GameTimer.SpeedrunTimeComponent)GetComponent(GameComponentsLookup.SpeedrunTime); } }
    public bool hasSpeedrunTime { get { return HasComponent(GameComponentsLookup.SpeedrunTime); } }

    public void AddSpeedrunTime(float newValue) {
        var index = GameComponentsLookup.SpeedrunTime;
        var component = (SemoGames.GameTimer.SpeedrunTimeComponent)CreateComponent(index, typeof(SemoGames.GameTimer.SpeedrunTimeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSpeedrunTime(float newValue) {
        var index = GameComponentsLookup.SpeedrunTime;
        var component = (SemoGames.GameTimer.SpeedrunTimeComponent)CreateComponent(index, typeof(SemoGames.GameTimer.SpeedrunTimeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSpeedrunTime() {
        RemoveComponent(GameComponentsLookup.SpeedrunTime);
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

    static Entitas.IMatcher<GameEntity> _matcherSpeedrunTime;

    public static Entitas.IMatcher<GameEntity> SpeedrunTime {
        get {
            if (_matcherSpeedrunTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpeedrunTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeedrunTime = matcher;
            }

            return _matcherSpeedrunTime;
        }
    }
}
