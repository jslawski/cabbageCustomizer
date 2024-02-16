public enum AnimatedUIElementState { Neutral, Appear, Hide, Released, Wait, Pushed, Hovered };

public interface IAnimatedUIElement
{
    void Reveal();
    void Hide();
}
