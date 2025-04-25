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
  public partial class MainForm : Form, IMainView {
    public MainForm() {
      InitializeComponent();
    }
    public string SourceFolder => textSource.Text;
    public string TargetFolder => textTarget.Text;
    public bool IsSourcePriority => chkSourcePriority.Checked;
    public event EventHandler SyncClicked;

    public void LogMessage(string message) {
      txtLog.AppendText(message + Environment.NewLine);
    }

    // не надо обращать внимание на название методов ниже 
    // я вообще не разобрался как менять их название - из-за этого ломается сама форма
    private void textSource_TextChanged(object sender, EventArgs e) { // не смог удалить

    }

    private void btnBrowseSource_Click(object sender, EventArgs e) {
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textSource.Text = folderDialog.SelectedPath;
      }
    }

    private void button2_Click(object sender, EventArgs e) { // не смог переименовать в btnBrowseTarget_Click
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textTarget.Text = folderDialog.SelectedPath;
      }
    }

    private void btnSync_Click(object sender, EventArgs e) {
      SyncClicked?.Invoke(this, EventArgs.Empty);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) { // не смог удалить
    }
  }
} //всё также не понял как поменять имя методов
