using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readCd
{
    class Reader
    {
        public string Dir;
        public string NewDrive;
        public string CdNumber;
        public int step = 0;
        public string newFile;
        public Reader(string dir, string newDrive, string cdNumber)
        {
            Dir = dir;
            NewDrive = newDrive;
            CdNumber = cdNumber;
        }
        public void getFilesFrom(string fdir, StringBuilder sb, string newFile)
        {
            foreach (string f in Directory.GetFiles(fdir))
            {
                FileInfo info = new FileInfo(f);
                sb.Append(CdNumber);
                sb.Append(";");
                sb.Append(info.Name);
                sb.Append(";");
                sb.Append(info.CreationTime);
                sb.Append(";");
                sb.Append(info.LastWriteTime);
                sb.Append(";");
                sb.Append(info.Length);
                sb.AppendLine(";");
                //info.CopyTo(info.FullName.Replace(Dir, Path.Combine(NewDrive, CdNumber)));
                info.CopyTo(Path.Combine(newFile,info.Name));
                Progress();
                Console.WriteLine(" > " + info.FullName.Replace(Dir, Path.Combine(NewDrive, CdNumber)));
            }
        }

        public void Progress()
        {
            Console.SetCursorPosition(0, 2);
            switch (step)
            {
                case 0:
                    Console.Write("|");
                    break;
                case 1:
                    Console.Write("/");
                    break;
                case 2:
                    Console.Write("-");
                    break;
                case 3:
                    Console.Write(@"\");
                    break;
            }
            step++;
            if (step == 4) { step = 0; }
        }
        public void readAll(string dir, StringBuilder sb, string newDriver)
        {
            //Console.WriteLine("Feldolgozás alatt álló mappa: " + dir);
            Progress();
            //Console.WriteLine(dir.Replace(Dir, Path.Combine(NewDrive, CdNumber)));
            Directory.CreateDirectory(dir.Replace(Dir, Path.Combine(NewDrive, CdNumber)));
            newFile = dir.Replace(Dir, Path.Combine(NewDrive, CdNumber));
            getFilesFrom(dir, sb, newFile);
            foreach (string kdir in Directory.GetDirectories(dir))
            {
                readAll(kdir, sb, newDriver);
            }
        }
    }
}
