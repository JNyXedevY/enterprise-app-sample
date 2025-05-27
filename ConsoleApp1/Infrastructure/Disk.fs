namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.Disk

module Disk =
    type WmiDiskRepository() =
        interface IDiskRepository with
            member _.GetDisk (): DiskInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 3")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    deviceId = obj.["DeviceID"] :?> string
                    fileSystemName = obj.["FileSystem"] :?> string
                    maxSize = obj.["Size"] :?> uint64
                    freeSize = obj.["FreeSpace"] :?> uint64
                })
                |> Seq.toList
