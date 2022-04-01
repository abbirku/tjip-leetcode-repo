public class RandomizedSet {
    
    Dictionary<int, int> dic;
    Random rand;
    
    public RandomizedSet() {
        dic = new Dictionary<int, int>();
        rand = new Random();
    }
    
    public bool Insert(int val) {
        if(!dic.ContainsKey(val)){
            dic.Add(val, val);
            return true;
        }
        return false;
    }
    
    public bool Remove(int val) {
        if(dic.ContainsKey(val)){
            dic.Remove(val);
            return true;
        }
        return false;
    }
    
    public int GetRandom() {
        return dic.ElementAt(rand.Next(0, dic.Count)).Value;
    }
}