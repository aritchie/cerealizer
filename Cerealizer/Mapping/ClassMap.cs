using System;


namespace Cerealizer.Mapping
{
    public class ClassMap<T>
    {
        public Type ClassType => typeof(T);


        public PropertyMap AddProperty<TProperty>(Func<T, TProperty> propertyInfo)
        {
            return null;
        }
    }
}
