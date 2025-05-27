namespace ConsoleApp.Application.Ports

module HotFix =
    type IHotFixService =
        abstract member GetHotFixInfo : unit -> unit 