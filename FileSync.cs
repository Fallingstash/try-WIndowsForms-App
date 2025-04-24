using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class FileSync {

    public static void SyncFolders(string sourceDir, string targetDir, Action<string> logAction) {
      if (!Directory.Exists(sourceDir) || !Directory.Exists(targetDir)) {
        logAction("Ошибка: одна из папок не существует!");
        return;
      }

      // 1. Копируем новые и изменённые файлы из source в target
      SyncDirectory(sourceDir, targetDir, logAction);

      // 2. (Позже добавим обратную синхронизацию)
    }

    private static void SyncDirectory(string source, string target, Action<string> logAction) {
      foreach (string sourceFile in Directory.GetFiles(source)) {
        string fileName = Path.GetFileName(sourceFile);
        string targetFile = Path.Combine(target, fileName);

        if (!File.Exists(targetFile)) {
          File.Copy(sourceFile, targetFile, true);
          logAction($"Файл {targetFile} создан");
        } else if (File.GetLastWriteTime(sourceFile) > File.GetLastWriteTime(targetFile)) {
          File.Copy(sourceFile, targetFile, true);
          logAction($"Файл {targetFile} изменен");
        }
      }
    }
  }
}
