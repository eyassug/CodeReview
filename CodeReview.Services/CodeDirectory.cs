using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CodeReview.Services
{
    public class CodeDirectory
    {
        private DirectoryInfo _codeDirectory;
        private List<FileInfo> _cSharpFiles;

        public CodeDirectory(string directoryPath)
        {
            _codeDirectory = new DirectoryInfo(directoryPath);
        }

        public List<FileInfo> CSharpFiles
        {
            get
            {
                if (_cSharpFiles == null) GetAllCodeFiles();
                return _cSharpFiles;
            }
        }

        private List<FileInfo> GetAllCodeFiles()
        {
            _cSharpFiles = new List<FileInfo>();
            GetFileListFromDirectory(_codeDirectory);
            return _cSharpFiles;
        }

        private void GetFileListFromDirectory(DirectoryInfo directory)
        {
            var subDirectories = directory.EnumerateDirectories();
            _cSharpFiles.AddRange(directory.EnumerateFiles());
            foreach (var dir in subDirectories)
            {
                GetFileListFromDirectory(dir);
            }
        }
    }
}