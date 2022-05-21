// TC: O(M * N)
// MC: O(N)
public class Logger {
    private readonly Dictionary<string, int> _presentlyLogged;

	public Logger()
	{
		_presentlyLogged = new Dictionary<string, int>();
	}

	public bool shouldPrintMessage(int time, string message)
	{
		if (_presentlyLogged.ContainsKey(message))
		{
			var timestamp = _presentlyLogged[message] + 10;
			if (time < timestamp)
				return false;
			else
			{
				_presentlyLogged[message] = timestamp;
				return true;
			}
		}
		else
		{
			_presentlyLogged.Add(message, time);
			return true;
		}
	}
}