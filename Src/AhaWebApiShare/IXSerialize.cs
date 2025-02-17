namespace AVMHomeAutomation

internal interface IXSerialize

{

    
    public static Device? ToDevice(this string? value)
    {
        if (value is null)
        {
            return null;
        }

        var res = new Device();
        var doc = XDocument.Parse(value);
        var device = doc.Element("device");

        res.Identifier = device.GetStringAttribute("identifier");
        res.Id = device.GetStringAttribute("id");
        res.FirmwareVersion = device.GetStringAttribute("fwversion");
        res.Manufacturer = device.GetStringAttribute("manufacturer");
        res.ProductName = device.GetStringAttribute("productname");
        res.FunctionBitMask = device.GetEnumAttribute<Functions>("functionbitmask");

        res.IsPresent = device.GetBoolElement("present");
        res.IsTXBusy = device.GetBoolElement("txbusy");
        res.Name = device.GetStringElement("name");
        res.IsBatteryLow = device.GetBoolElement("batterylow");
        res.Battery = device.GetIntElement("batterylow");

        var _switch = new Switch();
        var switchElm = device?.Element("switch");
        //_switch.State = switchElm
        //TODO
        res.Switch = _switch;
        return res;
    }
}
