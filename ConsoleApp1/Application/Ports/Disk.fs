namespace ConsoleApp.Application.Ports

module Disk =
    type IDiskService =
        abstract member GetDiskInfo : unit -> unit 