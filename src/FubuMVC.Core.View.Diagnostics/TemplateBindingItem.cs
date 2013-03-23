using System;

namespace FubuMVC.Core.View.Diagnostics
{
    public class TemplateBindingItem
    {
        public string DeclaredViewModel { get; set; }
        public Type ViewModelType { get; set; }
        public string ViewPath { get; set; }
        public string FilePath { get; set; }
        public string Origin { get; set; }
    }
}