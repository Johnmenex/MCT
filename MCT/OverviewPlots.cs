using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCT {
    public partial class OverviewPlots : Form {
        public OverviewPlots(List<string> LogFilePaths) {

            InitializeComponent();
            
            SetInterface(LogFilePaths);
            
        }

        private void SetInterface(List<string> _LogFilePaths) {
            Location = new Point(0, 0);
            Height = (Screen.PrimaryScreen.WorkingArea.Height * 5) / 7;
            Width = (Screen.PrimaryScreen.WorkingArea.Width * 5) / 7;


            ParseFiles(_LogFilePaths);
        }
        //Parse to be done here
        private List<List<string>> ParseFiles(List<string> FilesToParse) {
            List<List<string>> FileContents = new List<List<string>>();

            int _sessionIndex = 0;
            foreach (string _file in FilesToParse) {
                StreamReader _rdr = new StreamReader(_file);
                FileContents.Add(new List<string>());
                do {
                    string _line = _rdr.ReadLine();
                    if(_line!="")
                        FileContents[_sessionIndex].Add(_line);
                } while (!_rdr.EndOfStream);
            }
            
            return FileContents;

        }
    }
}
