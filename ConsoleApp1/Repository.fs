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

