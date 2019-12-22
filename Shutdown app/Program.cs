using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shutdown_app
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
        }
    }
}

//How do I shutdown - restart - logoff Windows via a bat file
//Here's how to do the shutdown functions via a batch file:

//shutdown -r — restarts
//shutdown -s — shutsdown
//shutdown -l — logoff
//shutdown -t xx — where xx is number of seconds to wait till shutdown/restart/logoff
//shutdown -i — gives you a dialog box to fill in what function you want to use
//shutdown -a — aborts the previous shutdown command....very handy!
//shutdown -h — hibernate.Easy mistake - it's not for help
//shutdown -y — Removes all prompts at shutdown(Help not available in any documentation)
//Additional options:

//-f — Force the selected action
//-t<seconds> — Set time to shutdown.Use -t 0 for "now"
//-c<message> — Adds Message to Shutdown
//How to cancel a shutdown /t command in Windows
//C:\> shutdown /a should stop the currently pending shutdown; unless it has already begun, in which case it will alert you that it can't.

//From the shutdown.exe help:

///a - Abort a system shutdown.