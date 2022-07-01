using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UXM
{
    public static class Util
    {
        public static Game GetExeVersion(string exePath)
        {
            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException($"Executable not found at path: {exePath}\r\n"
                    + "Please browse to an existing executable.");
            }

            string filename = Path.GetFileName(exePath);
            switch (filename)
            {
                case "DARKSOULS.exe":
                    return Game.DarkSouls;
                    break;
                case "DarkSoulsRemastered.exe":
                    throw new Exception("Why you trying to unpack a game that's already unpacked? :thinkrome:");
                    break;
                case "DarkSoulsII.exe":
                    {
                        using (FileStream fs = File.OpenRead(exePath))
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            fs.Position = 0x3C;
                            uint peOffset = br.ReadUInt32();
                            fs.Position = peOffset + 4;
                            ushort architecture = br.ReadUInt16();

                            if (architecture == 0x014C)
                            {
                                return Game.DarkSouls2;
                            }
                            else if (architecture == 0x8664)
                            {
                                return Game.Scholar;
                            }
                            else
                            {
                                throw new InvalidDataException("Could not determine version of DarkSoulsII.exe.\r\n"
                                    + $"Unknown architecture found: 0x{architecture:X4}");
                            }
                        }
                    }

                case "DarkSoulsIII.exe":
                    return Game.DarkSouls3;
                case "sekiro.exe":
                    return Game.Sekiro;
                case "DigitalArtwork_MiniSoundtrack.exe":
                    return Game.SekiroBonus;
                case "eldenring.exe":
                    return Game.EldenRing;
                default:
                    throw new ArgumentException($"Invalid executable name given: {filename}\r\n"
                + "Executable file name is expected to be DarkSoulsII.exe, DarkSoulsIII.exe, sekiro.exe, or DigitalArtwork_MiniSoundtrack.exe.");
            }
        }

        public enum Game
        {
            DarkSouls,
            DarkSoulsRemastered,
            DarkSouls2,
            Scholar,
            DarkSouls3,
            Sekiro,
            SekiroBonus,
            EldenRing
        }

        static (string path, string value)[] _keyPaths = new (string path, string value)[]
        {
                (@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath"),
                (@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath"),
                (@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath"),
                (@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Valve\Steam", "SteamPath")
        };

        public static string GetSteamPath(string gamePath)
        {
            //if (!gamePath.Contains("{0}"))
            //    return gamePath;

            string installPath = null;

            foreach ((string path, string value) item in _keyPaths)
            {
                string registryKey = item.path;
                installPath = (string)Registry.GetValue(registryKey, item.value, null);

                if (installPath != null)
                    break;
            }
     
            if (string.IsNullOrWhiteSpace(installPath))
                return null;

            string[] libraryFolders = File.ReadAllLines($@"{installPath}/SteamApps/libraryfolders.vdf");
            char[] seperator = new char[] { '\t' };

            foreach (string line in libraryFolders)
            {
                if (!line.Contains("\"path\""))
                    continue;

                string[] split = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                string libraryPath = string.Format(gamePath, split.FirstOrDefault(x=> x.ToLower().Contains("steam")).Replace("\"", ""));

                if (File.Exists(libraryPath))
                    return libraryPath.Replace("\\\\","\\");
            }

            return null;
        }

        public static IEnumerable<TreeNode> Traverse(this IEnumerable<TreeNode> root)
        {
            var stack = new Stack<TreeNode>(root);

            while (stack.Any())
            {
                var node = stack.Pop();
                yield return node;

                foreach (TreeNode child in node.Nodes)
                {
                    stack.Push(child);
                }
            }
        }
    }
}
