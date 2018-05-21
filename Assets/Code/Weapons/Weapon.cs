namespace Code.Weapons
{
    public interface Weapon
    {
        float Inaccuracy { get; }
        void Shoot();
    }
}
