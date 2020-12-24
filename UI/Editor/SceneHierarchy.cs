using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriWotW.UI.Editor {
    public class SceneObject {
        public string Name { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string ClassName { get; set; } = "";
        public List<string> SceneComponents { get; set; } = new List<string>();
    };
    public class SceneHierarchy {
        public SceneObject Object { get; set; } = new SceneObject();
        public List<SceneHierarchy> SceneChildren { get; set; } = new List<SceneHierarchy>();
    }
}
