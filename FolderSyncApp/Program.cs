using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSyncApp {
  public static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainForm view = new MainForm();

      MainPresenter presenter = new MainPresenter(view);

      Application.Run(view);
    }
  }
}
