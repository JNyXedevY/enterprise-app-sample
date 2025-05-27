namespace ConsoleApp.Infrastructure

open System.Management
open ConsoleApp.Domain.Device

module Device =
    type WmiDeviceRepository() =
        interface IDeviceRepository with
            member _.GetDevice() : DeviceInfo list  = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    modelName = obj.["Model"] :?> string 
                    userName = obj.["UserName"] :?> string
                    systemType = obj.["SystemType"] :?> string
                })
                |> Seq.toList
