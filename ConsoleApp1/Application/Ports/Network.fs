namespace ConsoleApp.Application.Ports

module Network =
    type INetworkService =
        abstract member GetNetworkInfo : unit -> unit 