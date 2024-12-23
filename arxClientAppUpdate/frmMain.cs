﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace arxClientAppUpdater
{
    public partial class frmMain : Form
    {
        const string updateJson = "update.json";
        const string serverUri = "https://github.com/aaronhu6028/arxClientAppUpdate/raw/main/";

        public frmMain()
        {
            InitializeComponent();
            LoadProject();
        }

        private void LoadProject()
        {
            using (StreamReader r = new StreamReader(updateJson))
            {
                string json = r.ReadToEnd();
                Global.listItems = JsonConvert.DeserializeObject<List<ClsProjItem>>(json);
            }


            lbProject.Items.Clear();
            foreach (var item in Global.listItems)
            {
                lbProject.Items.Add(item.appID);
            }

            if (lbProject.Items.Count > 0)
                lbProject.SelectedIndex = 0;
        }

        private void lbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                UpdateProjectInfo(project);
            }
        }

        private void UpdateProjectInfo(string project)
        {
            ClsProjItem item = Global.getItem(project);
            if (item == null) return;

            lbRemote.Text = item.version;
            lbLocal.Text = GetFlutterVersion(item.projPath);
        }

        private static string GetVersion(string exename)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(exename);
            Version ver = new Version(versionInfo.ProductVersion);
            DateTime buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(TimeSpan.TicksPerDay * ver.Build)); // days since 1 January 2000
            return string.Format("v{0:yy.MM.dd}.{1:00000}", buildDateTime, ver.Revision);
        }

        private void MakeProject(ClsProjItem item)
        {
            string project = item.appID;
            lbLocal.Text = item.version;
            lbRemote.Text = item.version;
            string apkFile = Path.Combine(item.projPath, "build/app/outputs/apk/release/app-release.apk");
            string dstFile1 = string.Format("{0}/{1}.apk", project, project);
            string dstFile2 = string.Format("{0}/{1}_{2}.apk", project, project, item.version);
            item.url = serverUri + dstFile2.Replace('\\', '/');
            item.sha256 = ""; // CalcSha256(apkFile);

            string jsonString = JsonConvert.SerializeObject(Global.listItems, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(updateJson, jsonString);
        }

        private string CalcSha256(string fname)
        {
            string sha256;
            using (Stream s = new FileStream(fname, FileMode.Open))
            {
                byte[] hash = SHA256.Create().ComputeHash(s);
                sha256 = BitConverter.ToString(hash).Replace("-", String.Empty).ToLower();
            }
            return sha256;
        }

        private String GetFlutterVersion(string projPath, bool inc = false)
        {
            string pubspec = Path.Combine(projPath, "pubspec.yaml");
            StringBuilder sb = new StringBuilder();
            String line;
            String ver = "";
            using (StreamReader sr = new StreamReader(pubspec))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string vv = CheckVersion(line, inc);
                    if (vv!="")
                    {
                        ver = vv;
                        if (!inc) return ver.Replace('+', '.');
                        line = "version: " + ver; 
                    }
                    sb.AppendLine(line);
                }
            }
            File.WriteAllText("ver.txt", sb.ToString());
            File.Copy("ver.txt", pubspec, true);

            return ver.Replace('+', '.');
        }

        private string CheckVersion(string line, bool inc=false)
        {
            if (line.Length < 10) return "";
            if (line.Substring(0, 8) != "version:") return "";

            string[] vers = line.Substring(8).Split(new char[] { '.', '+' });
            int nver = 0;
            for (int i=0; i<vers.Length; ++i)
            {
                nver += int.Parse(vers[i]);
                if (i < 2) nver *= 10;
                else if (i == 2) nver *= 100;
            }

            if (inc) nver += 1;
            string strVer = string.Format("{0}.{1}.{2}+{3}",
                nver / 10000, nver / 1000 % 10, nver / 100 % 10, nver % 100);

            return strVer;
        }

        private void BuildAndSubmit(ClsProjItem item)
        {
            lbLocal.Text = item.version;
            lbRemote.Text = item.version;
            string curdir = Directory.GetCurrentDirectory();

            string cmd = string.Format("/C echo BUILD Version={0} & cd \"{1}\" & flutter build apk & cd \"{2}\"",
                item.version, item.projPath, curdir);

            string apkFile = Path.Combine(item.projPath, "build\\app\\outputs\\apk\\release\\app-release.apk");
            apkFile = apkFile.Replace('/', '\\');
            string dstFile1 = string.Format("{0}\\{1}.apk", item.appID, item.appID);
            string dstFile2 = string.Format("{0}\\{1}_{2}.apk", item.appID, item.appID, item.version);
            string copyfile = string.Format("copy /y {0} {1} & copy /y {0} {2} ",
                apkFile, dstFile1, dstFile2);

            string comment = string.Format("-m \"{0}_{1}\"", lbProject.Text, lbRemote.Text);
            String submit = string.Format("choice /C Y /N /D Y /T 4 & git add -A & git commit {0} & git pull & git push & pause", comment);

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = cmd + " & " + copyfile + " & " + submit;
            Info.FileName = "cmd.exe";
            Info.CreateNoWindow = true;
            Process.Start(Info);
        }

        private void btnAllInOne_Click(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                var item = Global.getItem(project);
                if (item == null) return;

                item.version = GetFlutterVersion(item.projPath, true);
                MakeProject(item);
                BuildAndSubmit(item);
                // await Task.Delay(10000);
                // await Task.Delay(10000);
                // Submit(project);
            }
        }
    }
}
