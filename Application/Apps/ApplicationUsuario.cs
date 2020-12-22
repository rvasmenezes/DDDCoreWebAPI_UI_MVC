using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Apps
{
    public class ApplicationUsuario : IAppUsuario
    {
        IUsuario _iUsuario;

        public ApplicationUsuario(IUsuario iUsuario)
        {
            _iUsuario = iUsuario;
        }

        public void Add(Usuario Entity)
        {
            _iUsuario.Add(Entity);
        }

        public void Delete(Usuario Entity)
        {
            _iUsuario.Delete(Entity);
        }

        public Usuario GetEntity(int Id)
        {
            return _iUsuario.GetEntity(Id);
        }

        public List<Usuario> List()
        {
            return _iUsuario.List();
        }

        public void Update(Usuario Entity)
        {
            _iUsuario.Update(Entity);
        }
    }
}
