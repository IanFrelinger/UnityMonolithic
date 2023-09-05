using System.IO;
using UnityEngine;

namespace HelperClasses.IO
{
    public static class FileHelper
    {
        /// <summary>
        /// Checks if a designated path is available for writing.
        /// </summary>
        /// <param name="filePath">The file path to check.</param>
        /// <returns>True if the path is available, otherwise false.</returns>
        public static bool IsPathAvailable(string filePath)
        {
            // Check if the file already exists.
            if (File.Exists(filePath))
            {
                Debug.LogWarning($"File already exists at: {filePath}");
                return false;
            }

            // Check the directory.
            string directoryPath = Path.GetDirectoryName(filePath);
            if (Directory.Exists(directoryPath))
            {
                return true;
            }

            // If the directory doesn't exist, try to create it.
            try
            {
                Directory.CreateDirectory(directoryPath);
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to create directory at {directoryPath}. Error: {ex.Message}");
                return false;
            }
        }
    }
}