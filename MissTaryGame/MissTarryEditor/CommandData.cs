using System.Collections.Generic;

namespace MissTarryEditor
{
	public class CommandData
	{
		public string Name { get; set; }
		public List<CommandAction> Actions { get; set; }
		public List<string> Dependencies { get; set; }

		public CommandData()
		{
			Actions = new List<CommandAction>();
			Dependencies = new List<string>();
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public class CommandAction
	{
		public string Name { get; set; }
		public Dictionary<string, string> Args { get; set; }
	}
}