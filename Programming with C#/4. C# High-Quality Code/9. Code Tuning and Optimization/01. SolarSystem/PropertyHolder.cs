using System.Windows;

namespace Surfaces
{
    public class PropertyHolder<PropertyType, HoldingType> where HoldingType:DependencyObject
    {
        DependencyProperty _property;

        public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            _property = 
                DependencyProperty.Register(
                    name, 
                    typeof(PropertyType), 
                    typeof(HoldingType), 
                    new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property
        {
            get { return _property; }
        }

        public PropertyType Get(HoldingType obj)
        {
            return (PropertyType)obj.GetValue(_property);
        }

        public void Set(HoldingType obj, PropertyType value)
        {
            obj.SetValue(_property, value);
        }
    }
}
