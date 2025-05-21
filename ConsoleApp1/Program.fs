open System
open Adapter
open Repository

[<EntryPoint>]
let main args =

    let deviceInfoRepo = WmiDeviceInfoRepository() :> DeviceInfoRepository
    let osInfoRepo = WmiOsInfoRepository() :> OsInfoRepository
    let networkInfoRepo = WmiNetworkInfoRepository() :> NetworkInfoRepository
    let diskInfoRepo = WmiDiskInfoRepository() :> DiskInfoRepository
    let userInfoRepo = WmiUserInfoRepository() :> UserInfoRepository
    let hotFixInfoRepo = WmiHotFixInfoRepository() :> HotFixInfoRepository
    let serviceInfoRepo = WmiServiceInfoRepository() :> ServiceInfoRepository
    let appInfoRepo = WmiAppInfoRepository() :> AppInfoRepository
    let batteryInfoRepo = WmiBatteriInfoRepository() :> BatteryInfoRepository

    deviceInfoRepo.getInfo() |> Console.WriteLine
    osInfoRepo.getInfo() |> Console.WriteLine
    networkInfoRepo.getInfo() |> Console.WriteLine
    diskInfoRepo.getInfo() |> Console.WriteLine
    userInfoRepo.getInfo() |> Console.WriteLine
    hotFixInfoRepo.getInfo() |> Console.WriteLine
    serviceInfoRepo.getInfo() |> Console.WriteLine
    appInfoRepo.getInfo() |> Console.WriteLine
    batteryInfoRepo.getInfo() |> Console.WriteLine

    0
