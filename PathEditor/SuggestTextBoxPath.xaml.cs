﻿using PathEditor.Models;
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
    public partial class SuggestTextBoxPath : UserControl
    {
        public static Type type = typeof(SuggestTextBoxPath);
        public PathEditorViewModel dataContext = null;

        public SuggestTextBoxPath()
        {
            InitializeComponent();

            dataContext = new PathEditorViewModel(new PathRepository());
            DataContext = dataContext;
        }

        public static bool validated;

        public static void Validate(object tb, SuggestTextBoxPath control, ValidateData d = null)
        {
            var path = control.dataContext.SelectedPathPart.Path;
            // Cant use FS because have to import PathEditor to both desktop and desktop.web  (common validation method)
            if (File.Exists(path ) || Directory.Exists(path))
            {
                validated = true;
                return;
            }
            validated = false;
            return;
        }

        public void Validate(object tbFolder, ValidateData d = null)
        {
            Validate(tbFolder, this, d);
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
    }
}