//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class SaveDataMatcher {

    public static Entitas.IAllOfMatcher<SaveDataEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<SaveDataEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<SaveDataEntity> AllOf(params Entitas.IMatcher<SaveDataEntity>[] matchers) {
          return Entitas.Matcher<SaveDataEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<SaveDataEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<SaveDataEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<SaveDataEntity> AnyOf(params Entitas.IMatcher<SaveDataEntity>[] matchers) {
          return Entitas.Matcher<SaveDataEntity>.AnyOf(matchers);
    }
}
