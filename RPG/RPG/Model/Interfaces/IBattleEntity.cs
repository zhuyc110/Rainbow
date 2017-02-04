namespace RPG.Model.Interfaces
{
    public interface IBattleEntity
    {
        int CurrentHp { get; set; }
        double CurrentHpPercentage { get; }
        int CurrentAttack { get; set; }
    }
}