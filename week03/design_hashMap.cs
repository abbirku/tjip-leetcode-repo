// TC: O(N)
// MC: O(1)

public class Entry
{
	public int Key { get; set; }
	public int Val { get; set; }
}

public class MyHashMap
{
	public List<List<Entry>> map;
	public int size = 10007;
	public MyHashMap()
	{
		map = new List<List<Entry>>();
		for (int i = 0; i < size; i++)
			map.Add(null);
	}

	public int CalculateHash(int key)
		=> key % size;

	public void Put(int key, int value)
	{
		var index = CalculateHash(key);
		if (map[index] == null || (map[index] != null && map[index].Count == 0))
		{
			map[index] = new List<Entry>();
			map[index].Add(new Entry
			{
				Key = key,
				Val = value
			});
		}
		else
		{
			foreach (var entry in map[index])
			{
				if (entry.Key == key)
				{
					entry.Val = value;
					return;
				}
			}

			map[index].Add(new Entry
			{
				Key = key,
				Val = value
			});
		}
	}

	public int Get(int key)
	{
		var index = CalculateHash(key);
		if (map[index] == null || (map[index] != null && map[index].Count == 0))
			return -1;
		else
		{
			foreach (var entry in map[index])
			{
				if (entry.Key == key)
					return entry.Val;
			}
		}
		return -1;
	}

	public void Remove(int key)
	{
		var index = CalculateHash(key);
		if (map[index] != null && map[index].Count > 0)
		{
			var length = map[index].Count;
			for (int i = 0; i < length; i++)
			{
				if (map[index][i].Key == key)
				{
					map[index].RemoveAt(i);
					return;
				}
			}
		}
	}
}