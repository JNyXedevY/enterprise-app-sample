namespace ConsoleApp.Domain

module Disk =
    type DiskInfo = {
        deviceId: string
        fileSystemName: string
        maxSize: uint64
        freeSize: uint64
    }

    type IDiskRepository =
        abstract member GetDisk : unit -> DiskInfo list 
