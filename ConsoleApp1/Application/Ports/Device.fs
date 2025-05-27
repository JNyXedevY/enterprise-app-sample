namespace ConsoleApp.Application.Ports

module Device =
    type IDeviceService =
        abstract member GetDeviceInfo : unit -> unit 