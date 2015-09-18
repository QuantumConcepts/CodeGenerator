using System;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    public class ReferenceResolver<ReferenceType>
        where ReferenceType : IProjectSchemaElement {
        public Func<ReferenceType> Resolver { get; set; }

        public ReferenceResolver() {
        }

        public ReferenceResolver(Func<ReferenceType> resolver) {
            this.Resolver = resolver;
        }

        public ReferenceType Resolve() {
            return this.Resolver();
        }
    }
}