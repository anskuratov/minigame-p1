namespace P1.Core
{
	public interface IDraggable
	{
		void StartDrag();
		void EndDrag();
		void Drag(IPointer pointer);
	}
}