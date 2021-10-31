//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameSettingsContext {

    public GameSettingsEntity speedrunEntity { get { return GetGroup(GameSettingsMatcher.Speedrun).GetSingleEntity(); } }

    public bool isSpeedrun {
        get { return speedrunEntity != null; }
        set {
            var entity = speedrunEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isSpeedrun = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameSettingsEntity {

    static readonly SemoGames.Speedrun.SpeedrunComponent speedrunComponent = new SemoGames.Speedrun.SpeedrunComponent();

    public bool isSpeedrun {
        get { return HasComponent(GameSettingsComponentsLookup.Speedrun); }
        set {
            if (value != isSpeedrun) {
                var index = GameSettingsComponentsLookup.Speedrun;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : speedrunComponent;

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
public sealed partial class GameSettingsMatcher {

    static Entitas.IMatcher<GameSettingsEntity> _matcherSpeedrun;

    public static Entitas.IMatcher<GameSettingsEntity> Speedrun {
        get {
            if (_matcherSpeedrun == null) {
                var matcher = (Entitas.Matcher<GameSettingsEntity>)Entitas.Matcher<GameSettingsEntity>.AllOf(GameSettingsComponentsLookup.Speedrun);
                matcher.componentNames = GameSettingsComponentsLookup.componentNames;
                _matcherSpeedrun = matcher;
            }

            return _matcherSpeedrun;
        }
    }
}