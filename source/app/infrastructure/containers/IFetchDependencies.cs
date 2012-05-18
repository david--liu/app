using System;

namespace app.infrastructure.containers
{
    public interface IFetchDependencies
    {
        Collaborator an<Collaborator>();
        object an(Type dependency_type);
    }
}