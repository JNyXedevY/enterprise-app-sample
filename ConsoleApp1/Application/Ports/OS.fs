namespace ConsoleApp.Application.Ports

module OS =
    type IOsService =
        abstract member GetOsInfo : unit -> unit
