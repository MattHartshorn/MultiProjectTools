using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace MultiProjectTools.Commands
{
    internal sealed class CreateProjectReferencesCommand :BaseCommand
    {
        private CreateProjectReferencesCommand(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public static CreateProjectReferencesCommand Instance
        {
            get;
            private set;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Instance = new CreateProjectReferencesCommand(serviceProvider);
        }

        protected override void SetupCommands()
        {
            AddCommand(PackageGuids.guidSolutionCmdSet, PackageIds.cmdCreateProjectReferences, OnInvoke);
        }

        private void OnInvoke(object sender, EventArgs e)
        {
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "CreateProjectReferencesCommand";

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
