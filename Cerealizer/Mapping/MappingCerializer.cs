using System;


namespace Cerealizer.Mapping
{
    public class MappingCerializer : ICerealizer
    {
        readonly ICerealizer mapper;


        public MappingCerializer(CerealMapper mapper)
        {
            this.mapper = mapper;
        }


        public virtual byte[] Serialize(object obj)
        {
            throw new NotImplementedException();
        }


        public virtual T Deserialize<T>(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
