using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BottleRocket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //https://support.microsoft.com/en-us/help/307966/how-to-provide-file-drag-and-drop-functionality-in-a-visual-c-applicat

            var s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            var filepath = s[0];

            LoadROM(new FileInfo(filepath));
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lblFilepath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //load the ROM
            var dialog = new OpenFileDialog
            {
                Title = "Please select a ROM.",
                Filter = "NES Cartridge Dumps (*.nes)|*.nes"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;
            LoadROM(new FileInfo(dialog.SafeFileName));
        }

        private void LoadROM(FileInfo file)
        {
            MessageBox.Show("this probably doesn't work yet");
            if (!HexHelpers.Validate(file.DirectoryName)) return;

            HexHelpers.LoadInfo(file.DirectoryName);
            label2.Text = file.DirectoryName;
            Text = file.Name;
        }

        //TODO: Use JSON instead of YML
        //private void btnCreateItemYML_Click(object sender, EventArgs e)
        //{
        //    if (!HexHelpers.ROMisLoaded()) return;

        //    using (var reader = new BinaryReader(File.Open(HexHelpers.ROMpath, FileMode.Open)))
        //    {
        //        //Read the item configuration table, and parse its entries into Item objects. Serialize them into YAML
        //        var itemTableContents = new List<Item>();
        //        var i = Item.START_OFFSET;
        //        while (i < Item.END_OFFSET)
        //        {
        //            var tableEntry = reader.ReadBytes(8);
        //            itemTableContents.Add(Item.ParseHex(tableEntry));
        //            i = i + 8;
        //        }
        //        Item.ExportYml(itemTableContents.ToArray());
        //    }
        //}

        //private void btnApplyItemYML_Click(object sender, EventArgs e)
        //{
        //    if (!HexHelpers.ROMisLoaded()) return;

        //    //load the YML

        //    //convert the YML into a list of Item objects

        //    //foreach, write to the ROM - item.GenerateTableEntry();


        //}
    }
}

