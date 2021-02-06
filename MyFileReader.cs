using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SMTP_Emails
{
    class MyFileReader
    {
        public string from { get; set; }
        public string to { get; set; }
        public string password { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public string[] lines { get; set; }
        public string[] path { get; set; }

        public MyFileReader(string path) {
            lines = System.IO.File.ReadAllLines(path);
            from = lines[0];
            to = lines[1];
            password = lines[2];
            subject = lines[3];
            content = lines[4];
        }
        
        public void Read() {
            foreach (string line in lines) {
                Console.WriteLine(line);
            }
        }
    }
}
