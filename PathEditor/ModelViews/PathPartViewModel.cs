﻿using System;
using System.Diagnostics;
using System.IO;
using PathEditor.Models;

namespace PathEditor.ModelViews
{
    public class PathPartViewModel : BaseViewModel
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _pathPart;

        [DebuggerStepThrough]
        public PathPartViewModel(string pathPart)
        {
            if (pathPart == null) ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("pathPart");
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