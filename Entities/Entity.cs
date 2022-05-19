using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatWhite.Entities
{
    internal class Entity
    {
        public int Id { get; init; }
        private readonly IComponentMapperService _componentMapperService;

        public Entity(IComponentMapperService componentMapperService)
        {
            _componentMapperService = componentMapperService;
        }

        public void Attach<T>(T component)
            where T : class
        {
            _componentMapperService.GetMapper<T>().Add(Id, component);
        }

        public void Detach<T>()
            where T : class
        {
            _componentMapperService.GetMapper<T>().Delete(Id);
        }

        public void Has<T>()
            where T : class
        {
            _componentMapperService.GetMapper<T>().Has(Id);
        }
    }
}
