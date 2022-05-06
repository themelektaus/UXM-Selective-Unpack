using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UXM
{

    class GameInfo
    {
        public long RequiredGB;
        public BHD5.Game BHD5Game;
        public List<string> Archives;
        public ArchiveDictionary Dictionary;
        public List<string> BackupDirs;
        public List<string> DeleteDirs;
        public List<string> Replacements;
        public static readonly string ExeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public GameInfo(string xmlStr, string dictionaryStr, Util.Game game)
        {
            Dictionary = new ArchiveDictionary(dictionaryStr, game);
            XDocument xml = XDocument.Parse(xmlStr);
            RequiredGB = long.Parse(xml.Root.Element("required_gb").Value);
            BHD5Game = (BHD5.Game)Enum.Parse(typeof(BHD5.Game), xml.Root.Element("bhd5_game").Value);
            Archives = xml.Root.Element("archives").Elements().Select(element => element.Value).ToList();
            BackupDirs = xml.Root.Element("backup_dirs").Elements().Select(element => element.Value).ToList();
            DeleteDirs = xml.Root.Element("delete_dirs").Elements().Select(element => element.Value).ToList();
            Replacements = xml.Root.Element("replacements").Elements().Select(element => element.Value).ToList();
        }

        public static GameInfo GetGameInfo(Util.Game game)
        {

            string prefix = GetPrefix(game);

#if DEBUG
            string gameInfo = File.ReadAllText($@"..\..\dist\res\{prefix}GameInfo.xml");
            string dictionary = File.ReadAllText($@"..\..\dist\res\{prefix}Dictionary.txt");
#else
            string gameInfo = File.ReadAllText($@"{ExeDir}\res\{prefix}GameInfo.xml");
            string dictionary = File.ReadAllText($@"{ExeDir}\res\{prefix}Dictionary.txt");
#endif
            return new GameInfo(gameInfo, dictionary, game);
        }

        public static string GetPrefix(Util.Game game)
        {
            string prefix;
            if (game == Util.Game.DarkSouls2)
                prefix = "DarkSouls2";
            else if (game == Util.Game.Scholar)
                prefix = "Scholar";
            else if (game == Util.Game.DarkSouls3)
                prefix = "DarkSouls3";
            else if (game == Util.Game.Sekiro)
                prefix = "Sekiro";
            else if (game == Util.Game.SekiroBonus)
                prefix = "SekiroBonus";
            else if (game == Util.Game.EldenRing)
                prefix = "EldenRing";
            else
                throw new ArgumentException("Invalid game type.");
            return prefix;
        }
    }
}
