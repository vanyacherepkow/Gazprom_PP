using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Gazprom_Inform
{
    class User_Settings
    {
        public void Select_Color_set_dark()
        {
            RegistryKey Gazprom_Option = Registry.CurrentConfig;
            RegistryKey Gazprom = Gazprom_Option.CreateSubKey("Gazprom");
            Gazprom.SetValue("BackColor", "ControlDarkDark");
            Gazprom.SetValue("ForeColor", "Control");
            Program.BackColor = Gazprom.GetValue("BackColor").ToString();
            Program.ForeColor = Gazprom.GetValue("ForeColor").ToString();
            Gazprom.Close();
        }
        public void Select_Color_get()
        {
            RegistryKey color = Registry.CurrentConfig;
            RegistryKey back = color.CreateSubKey("Gazprom");
            Program.BackColor = back.GetValue("BackColor").ToString();
            Program.ForeColor = back.GetValue("ForeColor").ToString();
            back.Close();
        }
        public void Select_Color_set_light()
        {
            RegistryKey Gazprom_Option = Registry.CurrentConfig;
            RegistryKey Gazprom = Gazprom_Option.CreateSubKey("Gazprom");
            Gazprom.SetValue("BackColor", "Control");
            Gazprom.SetValue("ForeColor", "ControlText");
            Program.BackColor = Gazprom.GetValue("BackColor").ToString();
            Program.ForeColor = Gazprom.GetValue("ForeColor").ToString();
            Gazprom.Close();
        }
    }
}
