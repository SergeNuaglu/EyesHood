public class ProjectileProduct : Product
{
    private Quiver _quiver;

    public override bool TryBuy()
    {
        if (_quiver.ItemsCount < _quiver.CurentCapacity)
        {
            _quiver.AddItem();
            _quiver.SaveLastItemCount();
            return true;
        }

        return false;
    }

    public void Init(Quiver quiver)
    {
        _quiver = quiver;
    }
}
