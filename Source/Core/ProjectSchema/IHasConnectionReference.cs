namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IHasConnectionReference
    {
        string ConnectionName { get; set; }
        Connection Connection { get; }
    }
}
