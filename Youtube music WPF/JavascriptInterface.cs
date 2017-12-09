using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_music_WPF
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavascriptInterface
    {
        MainWindow mainwindow;
        public JavascriptInterface(MainWindow w)
        {
            this.mainwindow = w;
        }

        public void SetAudioLoop(bool value)
        {
            if (value == true)
            {
                mainwindow.wbMain.InvokeScript("EnableLoop");
                mainwindow.loopMusicMode = value;

            }
            else
            {
                mainwindow.wbMain.InvokeScript("DisableLoop");
                mainwindow.loopMusicMode = value;

            }
        }

        public void GetVolumeChanged(double scriptres)
        {
            Properties.Settings.Default.volume = scriptres;
            Properties.Settings.Default.Save();
        }

    }
}
