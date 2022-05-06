using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UXM
{
    class ArchiveDictionary
    {
        private const uint PRIME = 37;

        private Dictionary<ulong, string> hashes;

        public ArchiveDictionary(string dictionary, Util.Game game)
        {
            hashes = new Dictionary<ulong, string>();
            foreach (string line in Regex.Split(dictionary, "[\r\n]+"))
            {
                if (line.StartsWith("#"))
                    continue;

                string trimmed = line.Trim();
                if (trimmed.Length > 0)
                {
                    ulong hash = ComputeHash(trimmed, game);
                    hashes[hash] = trimmed;
                }
            }
        }

        private static ulong ComputeHash(string path, Util.Game game)
        {
            string hashable = path.Trim().Replace('\\', '/').ToLowerInvariant();
            if (!hashable.StartsWith("/"))
                hashable = '/' + hashable;
            return hashable.Aggregate(0u, (ulong i, char c) => i * (game == Util.Game.EldenRing ? 0x85ul : 37ul) + c);
        }

        public bool GetPath(ulong hash, out string path)
        {
            return hashes.TryGetValue(hash, out path);
        }
    }
}
