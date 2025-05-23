module Adapter
    open System.Management
    open System.IO
    open System.Text.Json
    open Repository
    open Domain

    type WmiDeviceInfoRepository() =
        interface DeviceInfoRepository with
            member _.getInfo (): DeviceInfo list  = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    manufacturer = obj.["Manufacturer"] :?> string
                    model = obj.["Model"] :?> string
                    userName = obj.["UserName"] :?> string
                    systemType = obj.["SystemType"] :?> string
                })
                |> Seq.toList

    type WmiOsInfoRepository() =
        interface OsInfoRepository with
            member _.getInfo (): OsInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    name = obj.["Caption"] :?> string
                    version = obj.["Version"] :?> string
                    arch = obj.["OSArchitecture"] :?> string
                    installDateTime = obj.["InstallDate"] :?> string
                })
                |> Seq.toList

    type WmiNetworkInfoRepository() =
        interface NetworkInfoRepository with
            member _.getInfo (): NetworkInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    ipAddr = obj.["IPAddress"] :?> string[] |> List.ofArray
                    macAddr = obj.["MACAddress"] :?> string
                })
                |> Seq.toList

    type WmiDiskInfoRepository() =
        interface DiskInfoRepository with
            member _.getInfo (): DiskInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 3")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    deviceId = obj.["DeviceID"] :?> string
                    fileSystem = obj.["FileSystem"] :?> string
                    maxSize = obj.["Size"] :?> uint64
                    freeSize = obj.["FreeSpace"] :?> uint64
                })
                |> Seq.toList

    type WmiUserInfoRepository() =
        interface UserInfoRepository with
            member _.getInfo (): UserInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    userName = obj.["Name"] :?> string
                    userDomain = obj.["Domain"] :?> string
                })
                |> Seq.toList

    type WmiHotFixInfoRepository() =
        interface HotFixInfoRepository with
            member _.getInfo (): HotFixInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_QuickFixEngineering")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    hotFixId = obj.["HotFixID"] :?> string
                    installDateTime = obj.["InstalledOn"] :?> string
                })
                |> Seq.toList

    type WmiServiceInfoRepository() =
        interface ServiceInfoRepository with
            member _.getInfo (): ServiceInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    name = obj.["Name"] :?> string
                    displayName = obj.["DisplayName"] :?> string
                    state = obj.["State"] :?> string
                    startMode = obj.["StartMode"] :?> string
                })
                |> Seq.toList

    type WmiAppInfoRepository() =
        interface AppInfoRepository with
            member _.getInfo (): AppInfo list = 
                use searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Product")
                searcher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    name = obj.["Name"] :?> string
                    version = obj.["Version"] :?> string
                    installDate = obj.["InstallDate"] :?> string
                })
                |> Seq.toList

    type WmiBatteriInfoRepository() =
        interface BatteryInfoRepository with
            member _.getInfo (): BatteryInfo list = 
                use seacher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery")
                seacher.Get()
                |> Seq.cast<ManagementObject>
                |> Seq.map(fun obj -> {
                    name = obj.["Name"] |> Option.ofObj |> Option.map(fun x -> x :?> string) |> Option.defaultValue "Uknown"
                    status = obj.["Status"] |> Option.ofObj |> Option.map(fun x-> x :?> string) |> Option.defaultValue "Uknown"
                    designCapacity = obj.["DesignCapacity"] |> Option.ofObj |> Option.map(fun x -> x :?> int64)
                    fullChargeCapacity = obj.["FullChargeCapacity"] |> Option.ofObj |> Option.map(fun x-> x :?> int64)
                })
                |> Seq.toList

    type JsonStorageRepository() =
        interface StorageRepository with
            member _.saveDeviceInfoList (dataList: DeviceInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("deviceInfo.json",jsonData)
            member _.saveOsInfoList (dataList: OsInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("osInfo.json",jsonData)
            member _.saveNetworkInfoList (dataList: NetworkInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("networkInfo.json", jsonData)
            member _.saveDiskInfoList (dataList: DiskInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("diskInfo.json", jsonData)
            member _.saveUserInfoList (dataList: UserInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("userInfo.json", jsonData)
            member _.saveHotFixInfo (dataList: HotFixInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("hotfixInfo.json", jsonData)
            member _.saveServiceInfo (dataList: ServiceInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("serviceInfo.json", jsonData)
            member _.saveAppInfo (dataList: AppInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("appInfo.json", jsonData)
            member _.saveBatteryInfo (dataList: BatteryInfo list): unit = 
                let jsonData = JsonSerializer.Serialize(dataList)
                File.WriteAllText("batteryInfo.json", jsonData)
