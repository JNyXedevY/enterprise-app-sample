namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.OS

module OS =
    type WmiOsRepository() =
        interface IOsRepository with
            member _.GetOs (): OsInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    osName = obj.["Caption"] :?>  string
                    osVersion = obj.["Version"] :?> string
                    osArch = obj.["OSArchitecture"] :?> string
                })
                |> Seq.toList
