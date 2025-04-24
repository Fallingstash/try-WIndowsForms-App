using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSyncApp {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
    }

    private void textSource_TextChanged(object sender, EventArgs e) {

    }

    private void btnBrowseSource_Click(object sender, EventArgs e) {
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textSource.Text = folderDialog.SelectedPath;
      }
    }

    private void button2_Click(object sender, EventArgs e) { // не смог переименовать в btnBrowseTarget_Click, всё ломается..
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textTarget.Text = folderDialog.SelectedPath;
      }
    }

    private void btnSync_Click(object sender, EventArgs e) {
      bool isSourcePriority = chkSourcePriority.Checked;
      txtLog.AppendText("Синхронизация начата!" + Environment.NewLine);
      FileSync.SyncFolders(textSource.Text, textTarget.Text, isSourcePriority, log => txtLog.AppendText(log + Environment.NewLine));
      txtLog.AppendText("Синхронизация завершена!" + Environment.NewLine); 
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) { //я снова случайно нажал, и если удалить, то всё ломается :(
    }
  }
}
