public enum AnimatedUIElementState { Neutral, Appear, Hide, Released, Wait, Pushed, Hovered, Disabled, Enabled };

public interface IAnimatedUIElement
{
    void Reveal();
    void Hide();
}
