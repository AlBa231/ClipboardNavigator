using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardNavigator.Lib;

public interface IRegistrySetting
{
    string? RunPath { get; set; }
}