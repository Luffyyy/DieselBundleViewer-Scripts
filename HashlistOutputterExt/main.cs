﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieselBundleViewer;
using DieselEngineFormats;
using DieselBundleViewer.Services;
using DieselEngineFormats.Bundle;
using DieselEngineFormats.ScriptData;
using System.Xml;

public class main
{
    public void register()
    {
        Console.WriteLine("Register");
        ScriptActions.RegisterScript(new HashlistOutputterExt());
    }
}

public class HashlistOutputterExt
{
    public string key = "hashlist_outputter_ext";
    public string title = "Hashlist Outputter Ext";

    public HashSet<string> Extensions = new HashSet<string>();

    public void execute()
    {
        var window = Utils.CurrentWindow;
        foreach(var file in window.FileEntries)
        {
            Extensions.Add(file.Value.ExtensionIds.UnHashed);
            if (file.Value.LanguageIds != null && file.Value.LanguageIds.HasUnHashed)
                Extensions.Add(file.Value.LanguageIds.UnHashed);
        }

        string path = Path.Combine(Definitions.DataDir, "exts");

        using (StreamWriter strw = new StreamWriter(path, false))
        {
            foreach (string str in Extensions)
            {
                strw.Write(str + "\n");
            }
        }
    }
}
