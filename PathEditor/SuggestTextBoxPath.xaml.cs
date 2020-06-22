using PathEditor.Models;
using PathEditor.ModelViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PathEditor
{
    /// <summary>
    /// Interaction logic for SuggestTextBoxPath.xaml
    /// </summary>
    public partial class SuggestTextBoxPath : UserControl, IValidateControl
    {
        public static Type type = typeof(SuggestTextBoxPath);
        public PathEditorViewModel dataContext = null;

        static SuggestTextBoxPath()
        {
            TypesControlsSunamo.tPathEditor = type;
        }

        public SuggestTextBoxPath()
        {
            InitializeComponent();

            dataContext = new PathEditorViewModel(new PathRepository());
            DataContext = dataContext;
        }

        public static bool validated;

        public bool Validated { get => validated; set => validated = value; }

        public  bool Validate(object tb, object o, ValidateData d = null)
        {
            SuggestTextBoxPath control = (SuggestTextBoxPath)o;
            var path = control.dataContext.SelectedPathPart.Path;

            // Cant use FS because have to import PathEditor to both desktop and desktop.web  (common validation method)
            if (File.Exists(path ) || Directory.Exists(path))
            {
                validated = true;
            }

            validated = false;
            return validated;
        }

        public bool Validate(object tbFolder, ValidateData d = null)
        {
            return Validate(tbFolder, this, d);
        }

        /// <summary>
        /// ControlInitData is not present in PathEditor
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="fullPathFolder"></param>
        public static FrameworkElement Get(string tag, string fullPathFolder)
        {
            SuggestTextBoxPath txt = new SuggestTextBoxPath();

            // In this case SelectedPathPart is null so I have to create new
            txt.dataContext.SelectedPathPart = new PathPartViewModel( fullPathFolder);
            //txt.txt.Text = fullPathFolder;
            txt.Tag = tag;
            return txt;
        }

        public object GetContent()
        {
            return dataContext.SelectedPathPart.Path;
        }
    }
}