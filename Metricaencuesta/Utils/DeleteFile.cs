using System;
using System.IO;

namespace Metricaencuesta.Utils
{
    public class DeleteFile
    {
        public void deleteFile(String patch)
        {
            var files = System.IO.Directory.EnumerateFiles(patch);
            foreach (var item in files)
            {
                FileInfo info = new FileInfo(item);
                if(info.CreationTime < DateTime.Now.AddDays(-1))
                {
                    File.Delete(@item);
                }
            }
        }
    }
}
