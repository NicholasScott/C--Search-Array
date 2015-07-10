using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefixSearch
{
    public partial class Form1 : Form
    {
        //Stub list of stations
        string[] stationSet = { "Liverpool", "Liverpool Lime Street", "London", "Euston", "Manchester" };
        StationSearcher mainSearch;
        public Form1()
        {
            InitializeComponent();
            mainSearch = new StationSearcher(stationSet);
            PopulateForm();
        }

        private void PopulateForm()
        {
            //List of stations which match the entered prefix
            List<string> result = mainSearch.stationsMatchingPrefix(SearchBox.Text);
            listBox1.DataSource = result;
            //HashSet containing valid next characters, hashset is used to avoid duplicates
            HashSet<string> validNext = mainSearch.validNextCharacters(result, SearchBox.Text);
            listBox2.DataSource = validNext.ToList();
        }
        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            PopulateForm();
        }
    }
}
