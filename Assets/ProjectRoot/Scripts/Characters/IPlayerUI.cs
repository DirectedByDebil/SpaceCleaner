using Combat;
using Pickables.Bonuses;
using Views;

//#TODO replace to ui namespace
namespace Characters
{
    public interface IPlayerUI : IHealthView, IBonusView, IScreen
    {
    }
}
