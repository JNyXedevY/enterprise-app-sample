namespace ConsoleApp.Domain

module OS =
    type OsInfo = {
        osName: string
        osVersion: string
        osArch: string
     }

     type IOsRepository =
        abstract member GetOs : unit -> OsInfo list 
