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

        public Entity Attach<T>(T component)
            where T : class
        {
            _componentMapperService.GetMapper<T>().Add(Id, component);

            return this;
        }

        public Entity Detach<T>()
            where T : class
        {
            _componentMapperService.GetMapper<T>().Delete(Id);

            return this;
        }

        public void Has<T>()
            where T : class
        {
            _componentMapperService.GetMapper<T>().Has(Id);
        }
    }
}
