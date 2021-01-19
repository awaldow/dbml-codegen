using System;

namespace dbmlcodegen.parser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbmlFieldNameAttribute : Attribute
    {
        private string _fieldName { get; set; }
        public string FieldName { get { return _fieldName; } }
        public DbmlFieldNameAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }
    }
}