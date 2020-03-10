﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PathEditor.Views.Support.Validation;
using SunamoExceptions;

namespace PathEditor.Views.Support
{
    public static class ButtonHelper
    {
        public static bool? GetDialogResult(DependencyObject obj)
        { return (bool?)obj.GetValue(DialogResultProperty); }

        public static void SetDialogResult(DependencyObject obj, bool? value)
        { obj.SetValue(DialogResultProperty, value); }

        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult",
            typeof(bool?),
            typeof(ButtonHelper),
            new UIPropertyMetadata(OnDialogResultChanged));

        static Type type = typeof(ButtonHelper);

        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Implementation of DialogResult functionality
            Button button = d as Button;
            if (button == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Can only use ButtonHelper.DialogResult on a Button control");
            button.Click += (sender, e2) =>
            {
                var window = Window.GetWindow(button);

                var validateBeforeClose = ValidationHelper.GetValidateBeforeClose(window);
                if (validateBeforeClose)
                {
                    if (window.GetValidationErrors().Any())
                    { return; }
                }

                Window.GetWindow(button).DialogResult = GetDialogResult(button);
            };
        }
    }
}