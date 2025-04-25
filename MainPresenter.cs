using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class MainPresenter {
    private readonly IMainView _view;
    private readonly FileSync _model;

    public MainPresenter(IMainView view) {
      _view = view;
      _model = new FileSync();

      _view.SyncClicked += OnSyncClicked;
    }

    private void OnSyncClicked(object sender, EventArgs e) {
      _model.SyncFolders(_view.SourceFolder, _view.TargetFolder, _view.IsSourcePriority, _view.LogMessage);
    } 
  }
}
