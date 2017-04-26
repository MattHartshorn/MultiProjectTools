using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace MultiProjectTools.Commands
{
    internal sealed class ResolveReferencesCommand : BaseCommand
    {
        private ResolveReferencesCommand(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public static ResolveReferencesCommand Instance
        {
            get;
            private set;
        }

        public static void Initialize(IServiceProvider provider)
        {
            Instance = new ResolveReferencesCommand(provider);
        }

        protected override void SetupCommands()
        {
            AddCommand(PackageGuids.guidProjectCmdSet, PackageIds.cmdResolveReferences, OnInvoke);
        }

        private void OnInvoke(object sender, EventArgs e)
        {
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "ResolveReferencesCommand";

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
