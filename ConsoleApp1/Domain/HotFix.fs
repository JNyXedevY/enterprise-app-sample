namespace ConsoleApp.Domain

module HotFix =
    type HotFixInfo = {
        hotFixId: string
        installDateTime: string
    }

    type IHotFixRepository =
        abstract member GetHotFix : unit -> HotFixInfo list 

