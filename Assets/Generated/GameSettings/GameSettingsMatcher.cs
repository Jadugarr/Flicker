//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameSettingsMatcher {

    public static Entitas.IAllOfMatcher<GameSettingsEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<GameSettingsEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<GameSettingsEntity> AllOf(params Entitas.IMatcher<GameSettingsEntity>[] matchers) {
          return Entitas.Matcher<GameSettingsEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<GameSettingsEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<GameSettingsEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<GameSettingsEntity> AnyOf(params Entitas.IMatcher<GameSettingsEntity>[] matchers) {
          return Entitas.Matcher<GameSettingsEntity>.AnyOf(matchers);
    }
}
