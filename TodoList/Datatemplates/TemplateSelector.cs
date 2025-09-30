using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Datatemplates
{
    public class TemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new TaskDataTemplate();
        }
    }
}
