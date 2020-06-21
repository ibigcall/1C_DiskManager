using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManagerWPF.Data
{
    public  class Node
    {
        public Node()
        {
            Children = new ObservableCollection<Node>();
        }

        public string Name { get; set; }

        public ObservableCollection<Node> Children { get; set; }

        
    }
}
