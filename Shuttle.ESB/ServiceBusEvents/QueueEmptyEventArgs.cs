using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb
{
	public class QueueEmptyEventArgs : PipelineEventEventArgs
	{
		public QueueEmptyEventArgs(PipelineEvent pipelineEvent, IQueue queue)
			: base(pipelineEvent)
		{
			Queue = queue;
		}

		public IQueue Queue { get; private set; }
	}
}