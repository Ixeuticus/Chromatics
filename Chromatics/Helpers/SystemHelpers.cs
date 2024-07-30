﻿using Chromatics.Enums;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromatics.Helpers
{
    public class SystemHelpers
    {
        public static bool IsDarkModeEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 10) // Windows 10 and above
            {
                try
                {
                    // Registry path for the system's theme preference
                    const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
                    const string valueName = "AppsUseLightTheme";

                    using (var key = Registry.CurrentUser.OpenSubKey(keyPath))
                    {
                        if (key != null)
                        {
                            object registryValueObject = key.GetValue(valueName);
                            if (registryValueObject != null)
                            {
                                int registryValue = (int)registryValueObject;
                                return registryValue == 0; // 0 indicates dark mode, 1 indicates light mode
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if necessary
                    Debug.WriteLine($"Failed to read dark mode setting: {ex.Message}");
                }
            }

            // Default to light mode for unsupported versions or if reading the setting failed
            return false;
        }
    }

    public static class DarkModeManager
    {
        // Delegate for the dark mode changed event
        public delegate void DarkModeChangedEventHandler(bool isDarkMode);
        // Event triggered when dark mode is toggled
        public static event DarkModeChangedEventHandler DarkModeChanged;

        // Dictionary to store original colors of controls
        private static Dictionary<Control, (Color BackColor, Color ForeColor)> originalColors
            = new Dictionary<Control, (Color BackColor, Color ForeColor)>();

        public static void ToggleDarkMode(Form form, bool enableDarkMode)
        {
            if (enableDarkMode)
            {
                StoreOriginalColors(form);
                ApplyTheme(form, true);
            }
            else
            {
                RestoreOriginalColors(form);
            }

            form.Invalidate(true);
            form.Refresh();

            // Raise the DarkModeChanged event
            DarkModeChanged?.Invoke(enableDarkMode);
        }

        private static void StoreOriginalColors(Control control)
        {
            if (!originalColors.ContainsKey(control))
            {
                originalColors[control] = (control.BackColor, control.ForeColor);
            }

            foreach (Control childControl in control.Controls)
            {
                if (!(childControl is MetroTile))
                {
                    StoreOriginalColors(childControl);
                }
            }
        }

        private static void RestoreOriginalColors(Control control)
        {
            if (originalColors.ContainsKey(control))
            {
                var colors = originalColors[control];
                control.BackColor = colors.BackColor;
                control.ForeColor = colors.ForeColor;
                control.Invalidate();
            }

            foreach (Control childControl in control.Controls)
            {
                if (!(childControl is MetroTile))
                {
                    RestoreOriginalColors(childControl);
                }
            }
        }

        private static void ApplyTheme(Control control, bool isDarkMode)
        {
            if (control is MetroTile) return;

            if (isDarkMode)
            {
                control.BackColor = Color.FromArgb(45, 45, 48);
                if (!(control is RichTextBox))
                {
                    control.ForeColor = Color.White;
                }
                control.Invalidate();
            }

            foreach (Control childControl in control.Controls)
            {
                if (!(childControl is MetroTile))
                {
                    ApplyTheme(childControl, isDarkMode);
                }
            }

            // Special handling for DataGridView and RichTextBox omitted for brevity...
        }
    }
}
