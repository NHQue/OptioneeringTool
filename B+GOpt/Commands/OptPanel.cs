//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Rhino;
//using Rhino.Commands;
//using Rhino.Geometry;
//using Rhino.Collections;
//using Rhino.Input;
//using Rhino.Input.Custom;
//using Rhino.DocObjects;
//using Rhino.Geometry.Collections;
//using RhinoWindows;

//namespace B_GOpt.Commands
//{
//    public class OptPanel : Command
//    {
//        private Forms.Form2 Panelform { get; set; }     //Keeps track on the state of the form (if it is open or not)

//        static OptPanel _instance;
//        public OptPanel()
//        {
//            _instance = this;
//        }

//        ///<summary>The only instance of the MyCommand1 command.</summary>
//        public static OptPanel Instance
//        {
//            get { return _instance; }
//        }

//        public override string EnglishName
//        {
//            get { return "OptPanel"; }
//        }

//        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
//        {
//            //Creates a new Dashboard if there is none
//            if(null == Panelform)
//            {
//                Panelform = new Forms.Form2(doc);
//                Panelform.FormClosed += OnFormClosed;       //Event handler (associating the event with one's own function): when the form closed it calls the function "OnFormClosed" (in this case withou argument)
//                Panelform.Show(RhinoWinApp.MainWindow);
//            }
//            /*
//            var form = new Forms.Dashboard { StartPosition = FormStartPosition.CenterParent };          // curly brackets -> Object initialize syntax: instanciate a class by immediately initialzing some of its fields or properties
//            var formRes = form.ShowDialog(RhinoWinApp.MainWindow);

//            if (formRes == DialogResult.Cancel)
//            {
//                RhinoApp.WriteLine("The dialog closed with the cancel or the x-button");
//                return Result.Failure;
//            }
//            else if (formRes == DialogResult.OK)
//            {
//                RhinoApp.WriteLine("The dialog closed with the OK-button");
//                return Result.Success;
//            }*/
//            return Result.Success;
//        }

//        private void OnFormClosed(object sender, FormClosedEventArgs e) //object sender: refers to the instance that raises the event; FormClosedEventArgs: holds the event data
//        {
//            Panelform.Dispose();
//            Panelform = null;
//        }
//    }
//}