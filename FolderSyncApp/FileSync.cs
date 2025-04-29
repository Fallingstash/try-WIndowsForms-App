using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSyncApp {
  public class FileSync {
    public void SyncFolders(string sourceDir, string targetDir, bool isSourcePriority, Action<string> logAction) {
      if (!Directory.Exists(sourceDir) || !Directory.Exists(targetDir)) {
        logAction("Ошибка: одна из папок не существует!");
        return;
      }

      logAction("Синхронизация начата...");

      if (isSourcePriority) {
        SyncDirectory(sourceDir, targetDir, logAction);
        DeleteExtraFiles(sourceDir, targetDir, logAction);
      } else {
        SyncDirectory(targetDir, sourceDir, logAction);
        DeleteExtraFiles(targetDir, sourceDir, logAction); 
      }

      logAction("Синхронизация завершена!");
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

    private static void DeleteExtraFiles(string source, string target, Action<string> logAction) {
      foreach (string targetFile in Directory.GetFiles(target)) {
        string fileName = Path.GetFileName(targetFile);
        string sourceFile = Path.Combine(source, fileName);

        if (!File.Exists(sourceFile)) {
          File.Delete(targetFile);
          logAction($"Файл {targetFile} удалён из неприоритетной папки"); 
        }
      }
    }
  }
}
