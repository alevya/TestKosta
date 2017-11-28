using System;
using System.ComponentModel;

namespace TestDbApp.EntityFrameworkBinding
{
    /// <summary>
    /// Предоставляет все EntitySets в EntityDataSource в виде списка объектов PropertyDescriptor.
    /// </summary>
    /// <remarks>
    /// Это необходимо для отображения доступных EntitySet в раскрывающемся списке, который
    ///  появляется при редактировании свойства DataMember сложного связанного элемента управления.
    /// </remarks>
    internal class EntitySetTypeDescriptor : ICustomTypeDescriptor
    {
        private readonly EntityDataSource _dataSource;
        private PropertyDescriptorCollection _pdc;

        internal EntitySetTypeDescriptor(EntityDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        internal void Reset()
        {
            _pdc = null;
        }
        
        #region ICustomTypeDescriptor Implements

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            if (_pdc != null) return _pdc;
            int count = _dataSource.EntitySets.Count;
            var properties = new PropertyDescriptor[count];
            for (int i = 0; i < count; i++)
            {
                properties[i] = new EntitySetPropertyDescriptor(_dataSource.EntitySets[i]);
            }
            _pdc = new PropertyDescriptorCollection(properties);
            return _pdc;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) { return this; }
        AttributeCollection ICustomTypeDescriptor.GetAttributes() { return new AttributeCollection(null); }
        string ICustomTypeDescriptor.GetClassName() { return null; }
        string ICustomTypeDescriptor.GetComponentName() { return null; }
        TypeConverter ICustomTypeDescriptor.GetConverter() { return null; }
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() { return null; }
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() { return null; }
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType) { return null; }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents() { return new EventDescriptorCollection(null); }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) { return new EventDescriptorCollection(null); }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() { return ((ICustomTypeDescriptor)this).GetProperties(null); }

        #endregion
    }

   
    internal class EntitySetPropertyDescriptor : PropertyDescriptor
    {
        private readonly EntitySet _view;

        internal EntitySetPropertyDescriptor(EntitySet view) : base(view.Name, null)
        {
            _view = view;
        }

        #region Overrides

        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override bool Equals(object other)
        {
            var propertyDescriptor = other as EntitySetPropertyDescriptor;
            if (propertyDescriptor == null) return false;
            var descriptor = propertyDescriptor;
            return descriptor._view == _view;
        }
        public override int GetHashCode()
        {
            return _view.GetHashCode();
        }
        public override object GetValue(object component)
        {
            return _view.List;
        }
        public override void ResetValue(object component) { }
        public override void SetValue(object component, object value) { }
        public override bool ShouldSerializeValue(object component) { return false; }
        public override Type ComponentType => typeof(EntitySet);
        public override bool IsReadOnly => false;
        public override Type PropertyType => typeof(IBindingList);

        #endregion
    }
}
