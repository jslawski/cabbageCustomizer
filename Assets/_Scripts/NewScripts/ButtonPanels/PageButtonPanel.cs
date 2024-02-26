using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonPanel : ButtonPanel
{
    public int previousPage;
    public int currentPage;

    private int _maxPages;

    protected override void RevealButtonsCallback()
    {
        this.EnableAllButtons();
        this.UpdatePageButtons();
    }

    public void SetupPageButtons(int startingPage, int maxPageNum)
    {
        this.currentPage = startingPage;
        this._maxPages = maxPageNum;
    }
   
    private void UpdatePageButtons()
    {
        if (this.currentPage <= 0)
        {
            this.panelButtons[0].DisableButton(true);
            this.panelButtons[1].EnableButton();
        }
        else if (this.currentPage >= this._maxPages)
        {
            this.panelButtons[1].DisableButton(true);
            this.panelButtons[0].EnableButton();
        }
        else
        {
            this.panelButtons[0].EnableButton();
            this.panelButtons[1].EnableButton();
        }
    }

    public void PrevPagePressed()
    {
        if (this.currentPage > 0)
        {
            this.previousPage = this.currentPage;    
            this.currentPage--;
        }

        this.UpdatePageButtons();
    }

    public void NextPagePressed()
    {
        if (this.currentPage < this._maxPages)
        {
            this.previousPage = this.currentPage;
            this.currentPage++;
        }

        this.UpdatePageButtons();
    }
}
