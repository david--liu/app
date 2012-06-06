using System;

namespace app.specs.code_kata.RecentList
{
    public class File : IEquatable<File>
    {
        readonly int fileId;

        public File(int fileId)
        {
            this.fileId = fileId;
        }

        public bool Equals(File other)
        {
            return fileId == other.fileId;
        }
    }
}