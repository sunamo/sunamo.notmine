using System;
using System.Diagnostics;
using System.IO;
using PathEditor.Models;
using SunamoExceptions;

namespace PathEditor.ModelViews
{
    public class PathPartViewModel : BaseViewModel
    {
        static Type type = typeof(PathPartViewModel);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _pathPart;

        [DebuggerStepThrough]
        public PathPartViewModel(string pathPart)
        {
            if (pathPart == null) ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"pathPart");
            _pathPart = pathPart;
        }

        public string Path
        {
            [DebuggerStepThrough]
            get { return _pathPart; }
            [DebuggerStepThrough]
            set
            {
                if (_pathPart != value)
                {
                    _pathPart = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Exists");
                }
            }
        }

        public bool Exists
        {
            [DebuggerStepThrough]
            get { return Path.ExpandedDirectoryExists(); }
        }

        [DebuggerStepThrough]
        public override string ToString()
        {
            return _pathPart;
        }
    }
}