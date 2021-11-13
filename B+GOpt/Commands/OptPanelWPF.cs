using Rhino;
using Rhino.Commands;
using RhinoWindows;
using System.Windows.Interop;

namespace B_GOpt.Commands
{
    public class OptPanelWPF : Command
    {
        public override string EnglishName => "OptPanelWPF";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            //var dialog = new Views.SampleCsWpfDialog();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            var dialog = new Views.MainWindow();
            //dialog.ShowSemiModal(RhinoApp.MainWindowHandle());
            //dialog.ShowDialog();

            new System.Windows.Interop.WindowInteropHelper(dialog).Owner = Rhino.RhinoApp.MainWindowHandle();
            WindowInteropHelper wih = new WindowInteropHelper(dialog);
            wih.Owner = Rhino.RhinoApp.MainWindowHandle();
            dialog.Show();

            return Result.Success;
        }
    }
}