namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    public interface IAttribute : IRenameable {
        string Key { get; set; }
        string Value { get; set; }
    }
}
