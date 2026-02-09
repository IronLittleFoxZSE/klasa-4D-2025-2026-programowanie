using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleApp.Data
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public sealed class AuditableAttribute : Attribute
    {
        public string Category { get; }
        public AuditableAttribute(string category) => Category = category;
    }
}
