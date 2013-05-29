using System;

class ProgLangs
{
    static void Main()
    {
        string strCmdText;
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.FileName = "File.txt";
        startInfo.Arguments = "File.txt";
        process.StartInfo = startInfo;
        process.Start();
    }
}