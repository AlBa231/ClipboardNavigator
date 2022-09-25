using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipboardNavigator.Lib;
using Microsoft.Win32;
using Application = System.Windows.Forms.Application;

namespace ClipboardNavigator.LibWin
{
    internal class WindowsRegistrySetting : IRegistrySetting
    {
        private readonly string registryKeyPath;
        private readonly string keyName;

        public WindowsRegistrySetting(string registryKeyPath, string keyName)
        {
            this.registryKeyPath = registryKeyPath ?? throw new ArgumentNullException(nameof(registryKeyPath));
            this.keyName = keyName ?? throw new ArgumentNullException(nameof(keyName));
        }
        
        public string? RunPath
        {
            get => GetPath();
            set => SetPath(value);
        }

        private string? GetPath()
        {
            using var runKey = Registry.CurrentUser.OpenSubKey(registryKeyPath, false);
            return runKey?.GetValue(keyName) as string;
        }

        private void SetPath(string? value)
        {
            using var runKey = Registry.CurrentUser.OpenSubKey(registryKeyPath, true);
            if (value == null)
                runKey?.DeleteValue(keyName);
            else
                runKey?.SetValue(keyName, value);
        }
    }

    internal class WindowsRunRegistrySetting : WindowsRegistrySetting
    {
        private const string RegistryRunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        public WindowsRunRegistrySetting() : base(RegistryRunPath, Application.ProductName) { }
    }
}
