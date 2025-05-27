namespace ConsoleApp.Application.Service

open System.Text.Json
open System.IO
open ConsoleApp.Domain.Device
open ConsoleApp.Application.Ports.Device

module Device =
    type DeviceService(repo: IDeviceRepository) =
       interface IDeviceService with 
        member _.GetDeviceInfo (): unit = 
            repo.GetDevice()
            |> JsonSerializer.Serialize
            |> (fun x -> File.WriteAllText("deviceInfo.json", x))
