namespace OOPCommando;

public interface IBreakable
{
    protected bool GetStatus();
    protected int GetMaxHits();
    protected int GetCurentHits();
}