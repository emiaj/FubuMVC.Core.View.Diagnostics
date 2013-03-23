using System.Collections.Generic;

namespace FubuMVC.Core.View.Diagnostics
{
    public class ViewProblem
    {
        private readonly IList<string> _problems = new List<string>();
        private readonly IList<TemplateBindingItem> _items = new List<TemplateBindingItem>();

        public void AddWorkaround(string workaround)
        {
            _problems.Add(workaround);
        }

        public void AddItem(TemplateBindingItem item)
        {
            _items.Add(item);
        }

        public string Description { get; set; }

        public IEnumerable<string> Workarounds
        {
            get { return _problems; }
        }

        public IEnumerable<TemplateBindingItem> Items
        {
            get { return _items; }
        }
    }
}