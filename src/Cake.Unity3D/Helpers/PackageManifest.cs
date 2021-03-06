﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cake.Unity3D.Helpers
{
    public class PackageManifest
    {
        public Dictionary<string, string> dependencies;

        public static PackageManifest ReadFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<PackageManifest>(json);
        }

        public static bool TryReadFile(string path, out PackageManifest manifest)
        {
            if (System.IO.File.Exists(path))
            {
                try
                {
                    manifest = ReadFile(path);
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: {0}\n\r{1}", ex.Message, ex.StackTrace);
                }
            }
            manifest = null;
            return false;
        }

        public static void WriteFile(string path, PackageManifest manifest)
        {
            string json = JsonConvert.SerializeObject(manifest);
            System.IO.File.WriteAllText(path, json);
        }
    }
}
