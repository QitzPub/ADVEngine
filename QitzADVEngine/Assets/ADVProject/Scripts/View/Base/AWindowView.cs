
namespace Qitz.ADVGame
{
    public abstract class AWindowView:ADVGameView
    {
        abstract public void SetWindowVO(IWindowVO vo);
        abstract public void Hide();
        abstract public void Show();
    }
}
