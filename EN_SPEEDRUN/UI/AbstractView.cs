using EN_SPEEDRUN.DataAccess;
using EN_SPEEDRUN.DataAccess.Dtos;
using EN_SPEEDRUN.UI.Enums;
using EN_SPEEDRUN.UI.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.UI;
public abstract class AbstractView<TDTO> : Form, IView<TDTO> where TDTO : IDTO {

    private TDTO? workingInstance;
    private ViewIntent? workingIntent;

    protected TDTO WorkInstance { 
        get { return this.workingInstance ?? throw new Exception("No work DTO instance set!"); } 
        set { this.workingInstance = value; }
    }

    protected ViewIntent WorkIntent {
        get { return this.workingIntent ?? throw new Exception("No work intent set!"); }
        set { this.workingIntent = value; }
    }


    protected AbstractView() : base() {

    }


    public void OpenWithIntent(ViewIntent intent, TDTO dtoToWorkWith) {
        // TODO: null check
        this.WorkIntent = intent;
        this.WorkInstance = dtoToWorkWith;
        switch (intent) {
            case ViewIntent.CREATION:
                this.RenderForCreation();
                break;
            case ViewIntent.DISPLAY:
                this.RenderForDisplay();
                break;
            case ViewIntent.EDITION:
                this.RenderForEdition();
                break;
            case ViewIntent.DELETION:
                this.RenderForDeletion();
                break;
        }
    }

    protected abstract void RenderForCreation();

    protected abstract void RenderForDisplay();

    protected abstract void RenderForEdition();

    protected abstract void RenderForDeletion();

    protected abstract void TriggerDtoCreation();

    protected abstract void TriggerDtoModificationsSave();

    protected abstract void TriggerDtoDeletion();

}
