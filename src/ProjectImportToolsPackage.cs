using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

using ProjectImportTools.Commands;

namespace ProjectImportTools
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]       
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(ProjectImportToolsPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class ProjectImportToolsPackage : Package
    {
        public const string PackageGuidString = "0d25ea8f-216b-4893-b5b1-61b29f7f4d1a";

        public ProjectImportToolsPackage()
        {
        }

        #region Package Members

        protected override void Initialize()
        {
            base.Initialize();

            // Solution Commands
            AddExistingProjectsCommand.Initialize(this);
            LoadReferenceFilesCommand.Initialize(this);
            CreateProjectReferencesCommand.Initialize(this);

            // Project Commands
            ResolveReferencesCommand.Initialize(this);
        }

        #endregion
    }
}
