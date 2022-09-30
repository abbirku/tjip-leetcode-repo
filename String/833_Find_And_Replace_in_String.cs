public class ReplaceInfo
    {
        public int Index { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }

    public class Solution
    {
        public List<ReplaceInfo> ReverseOrder(int[] indices, string[] sources, string[] targets)
        {
            var replaceInfos = new List<ReplaceInfo>();

            for (int i = 0; i < indices.Count(); i++)
            {
                replaceInfos.Add(new ReplaceInfo
                {
                    Index = indices[i],
                    Source = sources[i],
                    Target = targets[i],
                });
            }

            replaceInfos = replaceInfos.OrderByDescending(x => x.Index).ToList();

            return replaceInfos;
        }

        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            var replaceInfos = ReverseOrder(indices, sources, targets);
            var operableLength = s.Length;

            foreach (var info in replaceInfos)
            {
                //Checking weather provided info is valid to do a sub string
                //Ex: s = "abcde", index = 4 and Source.Length = 3. 
                //So, can not cut a string of length 3 from index 4
                if (operableLength - info.Index >= info.Source.Length)
                {
                    var prefix = string.Empty;
                    if (info.Index > 0)
                        prefix = s.Substring(0, info.Index);

                    var cut = s.Substring(info.Index, info.Source.Length);

                    var postfix = string.Empty;
                    if (s.Length - (prefix.Length + cut.Length) > 0)
                        postfix = s.Substring(prefix.Length + cut.Length,
                                              s.Length - (prefix.Length + cut.Length));

                    if (cut.Equals(info.Source))
                    {
                        s = $"{prefix}{info.Target}{postfix}";
                        operableLength = prefix.Length;
                    }
                }
            }

            return s;
        }
    }