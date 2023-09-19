﻿using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMAppBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class MainViewModel : AppViewModel
    {
        public MainViewModel()
        {
            //OnRefresh();
        }

        public override async Task OnStartup()
        {
            await FillAsync();
        }

        protected override async Task OnRefresh()
        {
            await FillAsync();
        }

        private async Task FillAsync()
        {
            using var client = new HomeAutomation("Demo", "Demo-1234");

            XmlDocument deviceListXml = await client.GetDeviceListInfosXmlAsync();
            DeviceList deviceList = await client.GetDeviceListInfosAsync();

            //    XmlDocument templateListXml = await client.GetTemplateListInfosXmlAsync();
            //    TemplateList templateList = await client.GetTemplateListInfosAsync();

            //    XmlDocument triggerListXml = await client.GetTriggerListInfosXmlAsync();
            //    TriggerList triggerList = await client.GetTriggerListInfosAsync();


            this.DeviceListVersion = deviceList.Version;
            this.DeviceListFirmwareVersion = deviceList.FirmwareVersion;
            this.Devices = deviceList.Devices.Select(d => new DeviceViewModel(d, deviceListXml)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();

        //    //this.Groups = deviceList.GroupsTree.Select(g => new GroupViewModel(g, deviceListXml)).ToList();
        //    this.SelectedGroup = this.Groups.FirstOrDefault();

        //    this.TriggerListVersion = triggerList.Version;
        //    this.Triggers = triggerList.Triggers.Select(t => new TriggerViewModel(t, triggerListXml)).ToList();

        //    this.TemplateListVersion = templateList.Version;
        //    this.Templates = templateList.Templates.Select(t => new TemplateViewModel(t, this.Devices, this.Templates, this.Triggers, templateListXml)).ToList();
        }

        [ObservableProperty]
        public Version deviceListVersion;

        [ObservableProperty]
        public Version deviceListFirmwareVersion;        

        [ObservableProperty]
        public List<DeviceViewModel> devices;

        [ObservableProperty]
        private DeviceViewModel selectedDevice;



        [ObservableProperty]
        public List<GroupViewModel> groups;

        [ObservableProperty]
        private DeviceViewModel selectedGroup;



        [ObservableProperty]
        public Version templateListVersion;

        [ObservableProperty]
        public List<TemplateViewModel> templates;

        [ObservableProperty]
        private TemplateViewModel selectedTemplate;



        [ObservableProperty]
        public Version triggerListVersion;

        [ObservableProperty]
        public List<TriggerViewModel> triggers;

        [ObservableProperty]
        private TriggerViewModel selectedTrigger;

    }
}
