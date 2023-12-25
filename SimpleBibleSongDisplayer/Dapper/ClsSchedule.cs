using Dapper.Contrib.Extensions;

namespace SimpleBibleSongDisplayer.Dapper
{
	[Table("schedule")]
	public class ClsSchedule
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Schedule { get; set; }
	}
}
