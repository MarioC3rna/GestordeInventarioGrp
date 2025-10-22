using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Base_de_Datos
{
    public static class ImageHelper
    {
        // 🔹 Directorios en orden de prioridad
        // ⚠️ IMPORTANTE: Si la IP de tu VM cambió, actualízala aquí
        private static readonly string[] PossibleDirectories = {
    @"Z:\",
      @"\\172.16.92.128\ImagenesDB",   // 👈 Cambia esta IP si es necesario
     @"C:\ImagenesDB",
          Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ImagenesDB")
        };

        private static string _workingDirectory = null;

        static ImageHelper()
        {
            InitializeWorkingDirectory();
   }

        private static void InitializeWorkingDirectory()
    {
 foreach (string directory in PossibleDirectories)
 {
          if (TrySetupDirectory(directory))
      {
      _workingDirectory = directory;
                 Console.WriteLine($"✅ Usando directorio: {directory}");
   return;
                }
       }

      _workingDirectory = PossibleDirectories[PossibleDirectories.Length - 1];
            Console.WriteLine($"⚠️ Usando directorio por defecto: {_workingDirectory}");
    }

     private static bool TrySetupDirectory(string directory)
    {
            try
         {
    if (!directory.StartsWith(@"\\") && !Directory.Exists(directory))
    {
       Directory.CreateDirectory(directory);
             }

                if (!Directory.Exists(directory)) return false;

   string testFile = Path.Combine(directory, $"test_{Guid.NewGuid()}.tmp");
      File.WriteAllText(testFile, "test");
          File.Delete(testFile);
return true;
       }
        catch
    {
         return false;
       }
        }

        public static string GetWorkingDirectory()
        {
    return _workingDirectory ?? PossibleDirectories[0];
        }

    public static bool SetWorkingDirectory(string directory)
 {
 if (TrySetupDirectory(directory))
            {
     _workingDirectory = directory;
           return true;
  }
            return false;
        }

        public static string SaveProductImage(Image image, string productCode)
        {
       try
            {
   if (image == null) return null;

    string workingDir = GetWorkingDirectory();

                if (!Directory.Exists(workingDir))
     {
         MessageBox.Show($"❌ Directorio no disponible:\n{workingDir}\n\nVerifica la conexión a la VM.",
         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return null;
                }

      string fileName = $"{SanitizeFileName(productCode)}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(workingDir, fileName);

     image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);

        if (File.Exists(fullPath))
           {
        Console.WriteLine($"✅ Imagen guardada: {fullPath}");
 return fullPath;
        }

       throw new IOException("Error al guardar la imagen");
            }
          catch (Exception ex)
       {
        MessageBox.Show($"❌ Error al guardar imagen:\n{ex.Message}",
   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         return null;
    }
        }

        public static Image LoadProductImage(string fullPath)
        {
            try
        {
    if (string.IsNullOrWhiteSpace(fullPath) || !File.Exists(fullPath))
               return null;

  using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
   return Image.FromStream(stream);
        }
  }
     catch (Exception ex)
      {
                Console.WriteLine($"❌ Error cargando imagen: {ex.Message}");
           return null;
       }
        }

        public static bool DeleteProductImage(string fullPath)
        {
  try
         {
if (string.IsNullOrWhiteSpace(fullPath) || !File.Exists(fullPath))
         return false;

      File.Delete(fullPath);
          return true;
          }
    catch
    {
             return false;
          }
     }

public static string UpdateProductImage(Image newImage, string productCode, string oldImagePath)
        {
try
       {
    string newPath = SaveProductImage(newImage, productCode);

  if (newPath != null && !string.IsNullOrWhiteSpace(oldImagePath) && oldImagePath != newPath)
      {
        DeleteProductImage(oldImagePath);
      }

      return newPath ?? oldImagePath;
            }
      catch
            {
    return oldImagePath;
  }
   }

        public static bool ImageExists(string fullPath)
        {
   return !string.IsNullOrWhiteSpace(fullPath) && File.Exists(fullPath);
        }

        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return "product";

            foreach (char c in Path.GetInvalidFileNameChars())
    {
 fileName = fileName.Replace(c, '_');
       }

     return fileName;
   }

        public static string GetImageDirectoryInfo()
        {
          try
    {
      string workingDir = GetWorkingDirectory();

           if (Directory.Exists(workingDir))
          {
        var files = Directory.GetFiles(workingDir, "*.png");
           return $"📁 Directorio: {workingDir}\n" +
             $"✅ Estado: Accesible\n" +
         $"📸 Archivos: {files.Length}\n" +
        $"✍️ Escritura: {(CanWriteToDirectory(workingDir) ? "OK" : "No")}";
    }
      else
   {
            return $"❌ Directorio: {workingDir}\n⚠️ Estado: No accesible";
      }
     }
            catch (Exception ex)
            {
 return $"❌ Error: {ex.Message}";
            }
  }

 private static bool CanWriteToDirectory(string directory)
        {
    try
    {
      string testFile = Path.Combine(directory, $"test_{Guid.NewGuid()}.tmp");
   File.WriteAllText(testFile, "test");
  File.Delete(testFile);
    return true;
            }
            catch
            {
                return false;
            }
    }

      public static void DiagnosticInfo()
        {
            string info = "=== DIAGNÓSTICO IMÁGENES ===\n\n";
      info += $"📂 En uso: {GetWorkingDirectory()}\n\n";
   info += "Directorios probados:\n\n";

            for (int i = 0; i < PossibleDirectories.Length; i++)
      {
      string dir = PossibleDirectories[i];
    bool exists = Directory.Exists(dir);
     bool canWrite = exists && CanWriteToDirectory(dir);

       info += $"{i + 1}. {dir}\n";
       info += $"   Existe: {(exists ? "✅" : "❌")} | Escritura: {(canWrite ? "✅" : "❌")}\n\n";
   }

            info += GetImageDirectoryInfo();

       MessageBox.Show(info, "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    }
}