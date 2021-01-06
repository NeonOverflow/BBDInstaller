﻿using System;
using System.Windows.Forms;

namespace BandagedBD.Panels {
    public partial class InstallConfigPanel : UserControl, IPanel {

        private FormMain Window;
        public void SetWindow(FormMain formMain) => Window = formMain;

        public string Title => "Installation Setup";
        public UserControl Control => this;

        public PanelTypes PreviousPanel => PanelTypes.Action;
        public PanelTypes NextPanel => PanelTypes.Install;

        public bool shouldRestart => cbShouldRestart.Checked;
        public string[] paths => Utilities.GetLocalPaths(discordLocator.stable, discordLocator.canary, discordLocator.ptb, discordLocator.development);
        public string[] executables => Utilities.GetExecutables(discordLocator.stable, discordLocator.canary, discordLocator.ptb, discordLocator.development);
        public string[] roamings => Utilities.GetRoamingPaths(discordLocator.stable, discordLocator.canary, discordLocator.ptb, discordLocator.development);

        public InstallConfigPanel() {
            InitializeComponent();
            discordLocator.setLabel("BandagedBD will be installed to the locations below. Click browse if the locations are incorrect.");
            discordLocator.setCheckboxLabel(Discord.Stable, "Install To Stable");
            discordLocator.setCheckboxLabel(Discord.Canary, "Install To Canary");
            discordLocator.setCheckboxLabel(Discord.PTB, "Install To PTB");
            discordLocator.setCheckboxLabel(Discord.Development, "Install to Development");
            discordLocator.OnCheckedChange += OnCheckedChange;
        }

        public void OnShow() {
            Window.btnBack.ShowEnable();
            Window.btnCancel.ShowEnable("Cancel");
            Window.btnNext.ShowDisable("Install");
        }

        private void OnCheckedChange(object sender, EventArgs e) {
            if (discordLocator.stable || discordLocator.canary || discordLocator.ptb || discordLocator.development) Window.btnNext.ShowEnable("Install");
            else Window.btnNext.ShowDisable("Install");
        }

        private void InstallConfigPanel_Load(object sender, EventArgs e) {

        }

        private void discordLocator_Load(object sender, EventArgs e)
        {

        }
    }
}
