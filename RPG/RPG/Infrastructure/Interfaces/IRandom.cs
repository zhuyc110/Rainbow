namespace RPG.Infrastructure.Interfaces
{
    public interface IRandom
    {
        int Next();
        /// <summary>
        /// 一个[0, max)的随机值
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        int Next(int max);
        /// <summary>
        /// 一个[min, max)的随机值
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        int Next(int min, int max);
    }
}