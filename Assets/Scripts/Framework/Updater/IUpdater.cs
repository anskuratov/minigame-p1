namespace P1.Framework
{
	public interface IUpdater
	{
		void Add(IUpdatable updatable);
		void Remove(IUpdatable updatable);
	}
}