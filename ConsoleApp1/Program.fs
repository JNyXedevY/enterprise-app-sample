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
    let storageRepo = JsonStorageRepository() :> StorageRepository

    deviceInfoRepo.getInfo() |> storageRepo.saveDeviceInfoList
    osInfoRepo.getInfo() |> storageRepo.saveOsInfoList
    networkInfoRepo.getInfo() |> storageRepo.saveNetworkInfoList
    diskInfoRepo.getInfo() |> storageRepo.saveDiskInfoList
    userInfoRepo.getInfo() |> storageRepo.saveUserInfoList
    batteryInfoRepo.getInfo() |> storageRepo.saveBatteryInfo
    //appInfoRepo.getInfo() |> storageRepo.saveAppInfo
    hotFixInfoRepo.getInfo() |> storageRepo.saveHotFixInfo
    serviceInfoRepo.getInfo() |> storageRepo.saveServiceInfo

    0
