using Microsoft.Win32;
using SoulsFormats;
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
                case "DarkSoulsRemastered.exe":
                    throw new Exception("Why you trying to unpack a game that comes pre-unpacked? :thinkrome:");
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
                + "Executable file name is expected to be DARKSOULS.exe DarkSoulsII.exe, DarkSoulsIII.exe, sekiro.exe, or DigitalArtwork_MiniSoundtrack.exe.");
            }
        }

        public enum Game
        {
            DarkSouls,
            DarkSouls2,
            Scholar,
            DarkSouls3,
            Sekiro,
            SekiroBonus,
            EldenRing
        }

        static (string, string)[] _pathValueTuple = new (string, string)[]
        {
                (@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath"),
                (@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath"),
                (@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath"),
                (@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Valve\Steam", "SteamPath"),
        };

        public static string TryGetGameInstallLocation(string gamePath)
        {
            if (!gamePath.Contains("{0}"))
                return gamePath;

            string steamPath = GetSteamInstallPath();

            if (string.IsNullOrWhiteSpace(steamPath))
                return null;

            string[] libraryFolders = File.ReadAllLines($@"{steamPath}/SteamApps/libraryfolders.vdf");
            char[] seperator = new char[] { '\t' };

            foreach (string line in libraryFolders)
            {
                if (!line.Contains("\"path\""))
                    continue;

                string[] split = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                string libraryPath = string.Format(gamePath, split.FirstOrDefault(x => x.ToLower().Contains("steam")).Replace("\"", ""));

                if (File.Exists(libraryPath))
                    return libraryPath.Replace("\\\\", "\\");
            }

            return null;
        }

        private static string GetSteamInstallPath()
        {
            string installPath = null;

            foreach ((string Path, string Value) pathValueTuple in _pathValueTuple)
            {
                string registryKey = pathValueTuple.Path;
                installPath = (string)Registry.GetValue(registryKey, pathValueTuple.Value, null);

                if (installPath != null)
                    break;
            }

            return installPath;
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
        public static string GetExtensions(byte[] bytes)
        {
            BinaryReaderEx br = new BinaryReaderEx(false, bytes);
            if (bytes.Length >= 3 && br.GetASCII(0, 3) == "GFX")
                return ".gfx";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "FSB5")
                return ".fsb";
            else if (bytes.Length >= 0x19 && br.GetASCII(0xC, 0xE) == "ITLIMITER_INFO")
                return ".itl";
            else if (bytes.Length >= 0x10 && br.GetASCII(8, 8) == "FEV FMT ")
                return ".fev";
            else if (bytes.Length >= 4 && br.GetASCII(1, 3) == "Lua")
                return ".lua";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "DDS ")
                return ".dds";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "#BOM")
                return ".txt";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "BND4")
            {
                if (BND3.IsRead(bytes, out BND3 bnd3))
                {
                    return $"{GetBNDExtensions(bnd3)}.bnd";
                }
                else if (BND4.IsRead(bytes, out BND4 bnd4))
                {
                    return $"{GetBNDExtensions(bnd4)}.bnd";
                }
            }
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "BHF4")
                return ".bhd";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "BDF4")
                return".bdt";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "PSC ")
                return ".pipelinestatecache";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "ENFL")
                return ".entryfilelist";
            else if (bytes.Length >= 4 && br.GetASCII(0, 4) == "DCX\0")
            {
                byte[] decompressedBytes = DCX.Decompress(bytes);
                string subextension = GetExtensions(decompressedBytes);
                return $"{subextension}.dcx";
            }
            br.Stream.Close();
            return ".unk";
        }

        private static string GetBNDExtensions(IBinder bnd)
        {
            List<string> extensions = new List<string>();

            foreach (BinderFile file in bnd.Files)
            {
                string extension = Path.GetExtension(file.Name);
                if (!extensions.Contains(extension))
                    extensions.Add(extension);
            }

            return string.Join("", extensions);
        }
    }
}
