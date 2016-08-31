using System;


namespace Cerealizer.Mapping
{
    public class CerealMapper
    {
        public CerealMapper AddClass<T>(Action<ClassMap<T>> classMapAction)
        {
            var classMap = new ClassMap<T>();
            classMapAction(classMap);
            return this;
        }
    }
}
