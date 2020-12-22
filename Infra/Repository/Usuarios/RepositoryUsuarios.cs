using Domain.Entities;
using Domain.Interfaces.Usuarios;
using Infra.Repository.Generics;

namespace Infra.Repository.Usuarios
{
    public class RepositoryUsuarios : RepositoryGeneric<Usuario>, IUsuario
    {
    }
}
