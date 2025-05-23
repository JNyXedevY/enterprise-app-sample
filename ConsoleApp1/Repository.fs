module Repository
    open Domain

    type DeviceInfoRepository =
        abstract member getInfo: unit -> DeviceInfo list

    type OsInfoRepository =
        abstract member getInfo: unit -> OsInfo list

    type NetworkInfoRepository =
        abstract member getInfo: unit -> NetworkInfo list

    type DiskInfoRepository =
        abstract member getInfo: unit -> DiskInfo list

    type UserInfoRepository =
        abstract member getInfo: unit -> UserInfo list

    type HotFixInfoRepository =
        abstract member getInfo: unit -> HotFixInfo list

    type ServiceInfoRepository =
        abstract member getInfo: unit -> ServiceInfo list

    type AppInfoRepository =
        abstract member getInfo: unit -> AppInfo list

    type BatteryInfoRepository =
        abstract member getInfo: unit -> BatteryInfo list

    type StorageRepository =
        abstract member saveDeviceInfoList: DeviceInfo list -> unit
        abstract member saveOsInfoList: OsInfo list -> unit
        abstract member saveNetworkInfoList: NetworkInfo list -> unit
        abstract member saveDiskInfoList: DiskInfo list -> unit
        abstract member saveUserInfoList: UserInfo list -> unit
        abstract member saveHotFixInfo: HotFixInfo list -> unit
        abstract member saveServiceInfo: ServiceInfo list -> unit
        abstract member saveAppInfo: AppInfo list -> unit
        abstract member saveBatteryInfo: BatteryInfo list -> unit
