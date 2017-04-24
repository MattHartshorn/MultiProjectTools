using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ProjectImportTools.Commands
{
    internal sealed class LoadReferenceFilesCommand :BaseCommand
    {
        private LoadReferenceFilesCommand(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public static LoadReferenceFilesCommand Instance
        {
            get;
            private set;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Instance = new LoadReferenceFilesCommand(serviceProvider);
        }

        protected override void SetupCommands()
        {
            AddCommand(PackageGuids.guidSolutionCmdSet, PackageIds.cmdLoadReferenceFiles, OnInvoke);
        }

        private void OnInvoke(object sender, EventArgs e)
        {
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "LoadReferenceFilesCommand";

            VsShellUtilities.ShowMessageBox(
                this.ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
