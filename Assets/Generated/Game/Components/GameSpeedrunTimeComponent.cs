//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.GameTimer.SpeedrunTimeComponent speedrunTimeComponent = new SemoGames.GameTimer.SpeedrunTimeComponent();

    public bool isSpeedrunTime {
        get { return HasComponent(GameComponentsLookup.SpeedrunTime); }
        set {
            if (value != isSpeedrunTime) {
                var index = GameComponentsLookup.SpeedrunTime;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : speedrunTimeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
