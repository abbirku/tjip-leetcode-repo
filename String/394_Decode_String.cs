public class StackResult
{
    public string GeneratedStr {get; set;}
    public int VisitedPos {get; set;}
}

public class Solution {
    public StackResult Decoder(int startPosition, 
                          string originalStr,
                          int generatedNumber)
    {
        var result = string.Empty;
        var strNum = string.Empty;
        
        for(int i = startPosition; i < originalStr.Length; i++)
        {
            var ch = originalStr[i];
            if(Char.IsDigit(ch))
                strNum += ch;
            else if(ch == '[')
            {
                var num = 0;
                
                if(!string.IsNullOrEmpty(strNum))
                {
                    num = int.Parse(strNum);
                    strNum = string.Empty;
                }
                
                var stackRes = Decoder(i+1, originalStr, num);
                result += stackRes.GeneratedStr;
                i = stackRes.VisitedPos;
            }
            else if(ch == ']')
            {
                var stackRes = new StackResult();
                
                stackRes.GeneratedStr = new StringBuilder(result.Length * generatedNumber)
                            .Insert(0, result, generatedNumber)
                            .ToString();
                
                stackRes.VisitedPos = i;
                
                return stackRes;
            }
            else
                result += ch;
        }
        
        
        return new StackResult{
            GeneratedStr = result
        };
    }
    
    public string DecodeString(string s) {
        return Decoder(0, s, 0).GeneratedStr;
    }
}