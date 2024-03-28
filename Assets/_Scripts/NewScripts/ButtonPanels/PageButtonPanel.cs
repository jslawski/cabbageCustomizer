using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonPanel : ButtonPanel
{
    [HideInInspector]
    public int currentPage;

    private int _maxPages;

    private SpriteButtonPanel _spriteButtonPanel;

    public void Setup(int startingPage, int maxPageNum)
    {
        this.currentPage = startingPage;
        this._maxPages = maxPageNum;

        this._spriteButtonPanel = GetComponentInParent<SpriteButtonPanel>();

        this.UpdatePageButtons();
    }

    public override void ButtonSelected(PanelButtonController selectedButton)
    {
        base.ButtonSelected(selectedButton);

        if (this.selectedButtonIndex_ == 0)
        {
            this.PreviousPagePressed();
        }
        else
        {
            this.NextPagePressed();
        }

        this.UpdatePageButtons();

        this._spriteButtonPanel.PageUpdated();
    }
    
    private void PreviousPagePressed()
    {
        if (this.currentPage > 0)
        {
            this.currentPage--;
        }

        this.UpdatePageButtons();
    }

    private void NextPagePressed()
    {
        if (this.currentPage < this._maxPages)
        {
            this.currentPage++;
        }

        this.UpdatePageButtons();
    }

    private void UpdatePageButtons()
    {
        if (this.currentPage <= 0)
        {
            this.panelButtons_[0].DisableButton();
            this.panelButtons_[1].EnableButton();
        }
        else if (this.currentPage >= this._maxPages)
        {
            this.panelButtons_[1].DisableButton();
            this.panelButtons_[0].EnableButton();
        }
        else
        {
            this.panelButtons_[0].EnableButton();
            this.panelButtons_[1].EnableButton();
        }
    }
}
