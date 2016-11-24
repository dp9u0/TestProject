// Manager class records the various blocks so it can split them up
using Microsoft.VisualStudio.TextTemplating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Manager {

    private class Block {
        public string Name;
        public int Start, Length;
    }

    private Block currentBlock;
    private List<Block> files = new List<Block>();
    private Block footer = new Block();
    private Block header = new Block();
    private ITextTemplatingEngineHost host;
    private StringBuilder template;
    protected List<string> generatedFileNames = new List<string>();

    public static Manager Create(ITextTemplatingEngineHost host, StringBuilder template) {
        return (host is IServiceProvider) ? new VSManager(host, template) : new Manager(host, template);
    }

    public void StartNewFile(string name) {
        if (name == null)
            throw new ArgumentNullException("name");
        CurrentBlock = new Block { Name = name };
    }

    public void StartFooter() {
        CurrentBlock = footer;
    }

    public void StartHeader() {
        CurrentBlock = header;
    }

    public void EndBlock() {
        if (CurrentBlock == null)
            return;
        CurrentBlock.Length = template.Length - CurrentBlock.Start;
        if (CurrentBlock != header && CurrentBlock != footer)
            files.Add(CurrentBlock);
        currentBlock = null;
    }

    public virtual void Process(bool split) {
        if (split) {
            EndBlock();
            string headerText = template.ToString(header.Start, header.Length);
            string footerText = template.ToString(footer.Start, footer.Length);
            string outputPath = Path.GetDirectoryName(host.TemplateFile);
            files.Reverse();
            foreach (Block block in files) {
                string fileName = Path.Combine(outputPath, block.Name);
                string content = headerText + template.ToString(block.Start, block.Length) + footerText;
                generatedFileNames.Add(fileName);
                CreateFile(fileName, content);
                template.Remove(block.Start, block.Length);
            }
        }
    }

    protected virtual void CreateFile(string fileName, string content) {
        if (IsFileContentDifferent(fileName, content))
            File.WriteAllText(fileName, content);
    }

    public virtual string GetCustomToolNamespace(string fileName) {
        return null;
    }

    public virtual string DefaultProjectNamespace {
        get {
            return null;
        }
    }

    protected bool IsFileContentDifferent(string fileName, string newContent) {
        return !(File.Exists(fileName) && File.ReadAllText(fileName) == newContent);
    }

    private Manager(ITextTemplatingEngineHost host, StringBuilder template) {
        this.host = host;
        this.template = template;
    }

    private Block CurrentBlock {
        get {
            return currentBlock;
        }
        set {
            if (CurrentBlock != null)
                EndBlock();
            if (value != null)
                value.Start = template.Length;
            currentBlock = value;
        }
    }

    private class VSManager : Manager {
        private EnvDTE.ProjectItem templateProjectItem;
        private EnvDTE.DTE dte;
        private Action<string> checkOutAction;
        private Action<IEnumerable<string>> projectSyncAction;

        public override string DefaultProjectNamespace {
            get {
                return templateProjectItem.ContainingProject.Properties.Item("DefaultNamespace").Value.ToString();
            }
        }

        public override string GetCustomToolNamespace(string fileName) {
            return dte.Solution.FindProjectItem(fileName).Properties.Item("CustomToolNamespace").Value.ToString();
        }

        public override void Process(bool split) {
            if (templateProjectItem.ProjectItems == null)
                return;
            base.Process(split);
            projectSyncAction.EndInvoke(projectSyncAction.BeginInvoke(generatedFileNames, null, null));
        }

        protected override void CreateFile(string fileName, string content) {
            if (IsFileContentDifferent(fileName, content)) {
                CheckoutFileIfRequired(fileName);
                File.WriteAllText(fileName, content);
            }
        }

        internal VSManager(ITextTemplatingEngineHost host, StringBuilder template)
            : base(host, template) {
            var hostServiceProvider = (IServiceProvider)host;
            if (hostServiceProvider == null)
                throw new ArgumentNullException("Could not obtain IServiceProvider");
            dte = (EnvDTE.DTE)hostServiceProvider.GetService(typeof(EnvDTE.DTE));
            if (dte == null)
                throw new ArgumentNullException("Could not obtain DTE from host");
            templateProjectItem = dte.Solution.FindProjectItem(host.TemplateFile);
            checkOutAction = (string fileName) => dte.SourceControl.CheckOutItem(fileName);
            projectSyncAction = (IEnumerable<string> keepFileNames) => ProjectSync(templateProjectItem, keepFileNames);
        }

        private static void ProjectSync(EnvDTE.ProjectItem templateProjectItem, IEnumerable<string> keepFileNames) {
            var keepFileNameSet = new HashSet<string>(keepFileNames);
            var projectFiles = new Dictionary<string, EnvDTE.ProjectItem>();
            var originalFilePrefix = Path.GetFileNameWithoutExtension(templateProjectItem.get_FileNames(0)) + ".";
            foreach (EnvDTE.ProjectItem projectItem in templateProjectItem.ProjectItems)
                projectFiles.Add(projectItem.get_FileNames(0), projectItem);

            // Remove unused items from the project
            foreach (var pair in projectFiles)
                if (!keepFileNames.Contains(pair.Key) && !(Path.GetFileNameWithoutExtension(pair.Key) + ".").StartsWith(originalFilePrefix))
                    pair.Value.Delete();

            // Add missing files to the project
            foreach (string fileName in keepFileNameSet)
                if (!projectFiles.ContainsKey(fileName))
                    templateProjectItem.ProjectItems.AddFromFile(fileName);
        }

        private void CheckoutFileIfRequired(string fileName) {
            var sc = dte.SourceControl;
            if (sc != null && sc.IsItemUnderSCC(fileName) && !sc.IsItemCheckedOut(fileName))
                checkOutAction.EndInvoke(checkOutAction.BeginInvoke(fileName, null, null));
        }
    }
}