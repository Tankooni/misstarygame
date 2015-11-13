namespace MissTarryEditor
{
	public class CommandData
	{
		public string Name { get; set; }
		//public Action[] Actions { get; set; }
		//public GameEvent[] Dependencies { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}