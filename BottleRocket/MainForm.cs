using System;
using System.IO;
using System.Windows.Forms;
using BottleRocket.Tables;

namespace BottleRocket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
        }

        #region Methods for opening the ROM
        private void LoadROM(FileSystemInfo file) //TODO: Declutter all of this stuff so I don't have to have System.IO in this cs file
        {
            if (!FileStuff.RomIsGood(file.FullName)) return;

            label2.Text = file.FullName;
            Text = file.Name;
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
            LoadROM(new FileInfo(dialog.FileName));
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //https://support.microsoft.com/en-us/help/307966/how-to-provide-file-drag-and-drop-functionality-in-a-visual-c-applicat
            var s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var filepath = s[0];

            LoadROM(new FileInfo(filepath));
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }
        #endregion

        private void btnExportItemJSON_Click(object sender, EventArgs e)
        {
            if (!FileStuff.ROMisLoaded()) return;

            var itemData = FileStuff.LoadItemDataFromROM();
            Item.ExportJSON(itemData);
        }

        private void btnImportItemJSON_Click(object sender, EventArgs e)
        {
            if (!FileStuff.ROMisLoaded()) return;

            var itemData = FileStuff.LoadItemDataFromJson();
            FileStuff.SaveToROM(itemData);
        }

        private void btnExportTeleport_Click(object sender, EventArgs e)
        {
            if (!FileStuff.ROMisLoaded()) return;

            var teleportData = FileStuff.LoadTeleportDataFromROM();
            TeleportLocation.ExportJson(teleportData);
        }

        private void btnImportTeleport_Click(object sender, EventArgs e)
        {
            if (!FileStuff.ROMisLoaded()) return;

            var teleportData = FileStuff.LoadTeleportDataFromJson();
            FileStuff.SaveToROM(teleportData);
        }
    }
}

