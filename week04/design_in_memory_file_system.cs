public class DirectoryNode
{
	public string DirPath { get; set; }
	public Dictionary<string, DirectoryNode> ChildDirectories { get; set; }//DirName, Child Location
	public Dictionary<string, string> Files { get; set; }//FileName, Content

	public DirectoryNode()
	{
		DirPath = "/";
		ChildDirectories = new Dictionary<string, DirectoryNode>();
		Files = new Dictionary<string, string>();
	}
}

public class FileSystem
{
	DirectoryNode rootDir;
	public FileSystem()
		=> rootDir = new DirectoryNode();

	private DirectoryNode NavigateAndCreate(string path, bool pathHasFile = false, bool isOnlyNavigation = false)
	{
		string[] parts;
		string fileName = string.Empty;
		var currentPath = "/";
		var currentDir = rootDir;

		if (path.Equals("/"))
			return rootDir;

		if (pathHasFile)
		{
			var allParts = path.Split('/').Where(x=> !string.IsNullOrEmpty(x)).ToArray();
			parts = allParts.ToList().GetRange(0, allParts.Length - 1).ToArray();
			fileName = allParts[allParts.Length - 1];
		}
		else
			parts = path.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();

		for (int i = 0; i < parts.Length; i++)
		{
			var part = parts[i];

			var subPath = i == 0 ? $"{part}" : $"/{part}";
			currentPath += subPath;

			if (!currentDir.ChildDirectories.ContainsKey(part) && !isOnlyNavigation)
			{
				var dir = new DirectoryNode
				{
					DirPath = currentPath,
					Files = new Dictionary<string, string>(),
					ChildDirectories = new Dictionary<string, DirectoryNode>()
				};
				currentDir.ChildDirectories.Add(part, dir);
			}

			if (currentDir.ChildDirectories.ContainsKey(part))
				currentDir = currentDir.ChildDirectories[part];
		}

		if (pathHasFile && !string.IsNullOrWhiteSpace(fileName) && 
			!currentDir.Files.ContainsKey(fileName))
		{
			currentDir.Files.Add(fileName, string.Empty);
		}

		return currentDir;
	}

	public IList<string> Ls(string path)
	{
		var dirInfos = new List<string>();
		var currentDir = NavigateAndCreate(path, false, true);

		if (currentDir != null && !currentDir.DirPath.Equals(path)) //Is a file path
		{
			var parts = path.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
			var fileName = parts[parts.Length - 1];

			dirInfos.AddRange(currentDir.Files.Select(x => x.Key));
			dirInfos = dirInfos.Where(x => x.Equals(fileName)).ToList();
		}
		else
		{
			dirInfos.AddRange(currentDir.ChildDirectories.Select(x => x.Key));
			dirInfos.AddRange(currentDir.Files.Select(x => x.Key));
		}

		return dirInfos.OrderBy(x => x).ToList();
	}

	public void Mkdir(string path)
	{
		NavigateAndCreate(path);
	}

	public void AddContentToFile(string filePath, string content)
	{
		var parts = filePath.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
		var fileName = parts[parts.Length - 1];
		var currentDir = NavigateAndCreate(filePath, true);
		
		if(currentDir != null && currentDir.Files.ContainsKey(fileName))
			currentDir.Files[fileName] += content;
	}

	public string ReadContentFromFile(string filePath)
	{
		var parts = filePath.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
		var fileName = parts[parts.Length - 1];
		var currentDir = NavigateAndCreate(filePath, true, true);

		if (currentDir != null && currentDir.Files.ContainsKey(fileName))
			return currentDir.Files[fileName];
		else
			return string.Empty;
	}
}